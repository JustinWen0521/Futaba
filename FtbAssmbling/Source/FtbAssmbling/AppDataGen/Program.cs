using System;
using System.Linq;
using ftd.codegen;
using ftd.console;
using ftd.service;

namespace ftd.data
{
    class Program
    {
        static void Main(string[] args)
        {
            //設定服務           
            FtdCreatorService.Instance.CreateMethod = (objType) =>
            {
                if (objType == typeof(FdmService))
                {
                    return new AdmServiceII();
                }
                return null;
            };

            var menu = new FcoSimpleMenu();
            menu.Title = "AppDataGen";
            add_menu_dmdata_gen(menu.RootNode, '1');
            menu.start();
        }

        /// <summary>
        /// 強行別MENU清單
        /// </summary>
        private static void add_menu_dmdata_gen(FcoSimpleMenu.Node node_parent, char press_key)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.Title = "同步資料定義";
            node_parent.addNodes(node_0);

            var node_1 = new FcoSimpleMenu.Node();
            node_1.PressKey = '1';
            node_1.Title = "同步ALL系統";
            node_1.PressAction = x => do_dmdata_gen(null);
            node_0.addNodes(node_1);

            {
                var idx = 0;
                foreach (var sys in FdmService.Instance.AllSystems.OrderBy(x => x.Key))
                {
                    var sys_code = sys.Key;
                    var node_2 = new FcoSimpleMenu.Node();
                    node_2.PressKey =(char) ('2' + idx) ;
                    node_2.Title = "同步" + sys.Key + "系統";

                    node_2.PressAction = x => do_dmdata_gen(sys_code);
                    node_0.addNodes(node_2);
                    idx++;
                }
            }

            var node_3 = new FcoSimpleMenu.Node();
            node_3.PressKey = '2';
            node_3.Title = "同步WebService";
            node_3.PressAction = x => do_webservice_proxy_gen();
            node_parent.addNodes(node_3);

        }     

        /// <summary>
        /// 強行別資料產生
        /// </summary>
        private static void do_dmdata_gen(string sys_code)
        {
            {
                var codegen = new FdmServiceCodeGen();                
                codegen.DataOuputPath = @"{@AppPath}\..\..\..\AppData\table";                
                codegen.ProviderOuputPath = @"{@AppPath}\..\..\..\AppService\dataprovider";

                if (sys_code.isNullOrEmpty())
                {
                    foreach (var system in FdmService.Instance.AllSystems.Values)
                    {
                        codegen.renderSystem(system.SystemName);
                    }
                }
                else
                {
                    codegen.renderSystem(sys_code);
                }
            }

            {
                var codegen = new NsDmHelperCodeGen();
                codegen.OutputPath = @"{@AppPath}\..\..\..\AppService\helper";               
                codegen.generate();
            }

            //{
            //    var codegen = new FdmNameCodeGen();
            //    codegen.OutputPath = @"{@AppPath}\..\..\..\AppData\data";
            //    codegen.FileName = "DmName.cs";
            //    codegen.AppDataNameType = typeof(AppDataName);
            //    codegen.generate();
            //}
        }

        /// <summary>
        /// WebServiceProxy產生
        /// </summary>
        private static void do_webservice_proxy_gen()
        {
            var codegen = new FtdWebServieProxyCodeGen();
            codegen.OutputPath = @"{@AppPath}\..\..\..\AppService\webservice.proxy";
            codegen.addWebService("http://localhost:13010/webservice/StationService.asmx", "ftd.webservice.proxy.StationService");
            //codegen.addWebService("http://localhost:16888/SiteService.soap?WSDL", "ftd.webservice.proxy.EmSiteServiceSoapService");
            codegen.generate();
        }
    }
}
