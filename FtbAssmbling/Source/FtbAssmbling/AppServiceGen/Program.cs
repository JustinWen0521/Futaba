using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using ftd;
using ftd.codegen;
using ftd.console;
using ftd.data;
using ftd.data.model;
using ftd.dataaccess;
using ftd.deploy;
using ftd.nsql;
using ftd.service;


namespace AppServiceGen
{
    class Program
    {
        public class CWebSite
        {
           
            public string DeployUrl;

            public string Package_RootName;

            public string Package_PrefixFileName;

            public Action<FdpFolder> filter_proc;

            public CWebSite()
            {
               
                filter_proc = x => {                    
                Console.Write(".");
                x.remove("*.svn");
                x.remove("_svn");
                x.remove("*.cs");

                if (x.FullName.equalIgnoreCase("."))
                {
                    x.remove("dll");
                    x.remove("FtdConfig.cfg");
                    x.remove("Web.config");
                    x.remove("obj");
                    x.addFromWeb("Web.config");

                    x.remove("*.csproj");
                    x.remove("*.csproj.user");
                }

                if (x.FullName.equalIgnoreCase(@".\bin"))
                {
                    x.remove("FtdConfig.cfg");
                    x.addFromWeb("FtdConfig.cfg");
                }          
                };
            }
        }

        static string P_Local_Upgrade_Folder;
        static string P_Local_AppWeb_Folder;

        static CWebSite getWebSite(string site_name)
        {
            if (site_name == "FtbAssmbling")
            {
                var site = new CWebSite();
                site.DeployUrl = "http://192.168.160.16/FtbAssmbling/webservice/FdpDeployService.asmx";
                site.Package_RootName = "Web";
                site.Package_PrefixFileName = "FtbAssmbling_";
                return site;
            }

            if (site_name == "local")
            {
                var site = new CWebSite();
                site.DeployUrl = "";
                site.Package_RootName = "Web";
                site.Package_PrefixFileName = "local_";
                site.filter_proc = x =>
                {
                    Console.Write(".");
                    x.remove("*.svn");
                    x.remove("_svn");
                    x.remove("*.cs");

                    if (x.FullName.equalIgnoreCase("."))
                    {
                        x.remove("dll");
                        x.remove("FtdConfig.cfg");
                        //x.remove("Web.config");
                        x.remove("obj");
                        //x.addFromWeb("Web.config");

                        x.remove("*.csproj");
                        x.remove("*.csproj.user");
                    }

                    if (x.FullName.equalIgnoreCase(@".\bin"))
                    {
                        //x.remove("FtdConfig.cfg");
                        //x.addFromWeb("FtdConfig.cfg");
                    }
                };
                return site;
            }

            return null;
        }

        static void Main(string[] args)
        {
            //設定服務
            
            FtdCreatorService.Instance.CreateMethod = (objType) =>
            {
                if (objType == typeof(FtdLogService))                
                    return new AppLogServiceII();               
                if (objType == typeof(FdmService))               
                    return new AdmService();                
                if (objType == typeof(FtdCodeNameService))                
                    return new AppCodeNameService();               
                if (objType == typeof(FtdSerialNumberService))
                    return new AppSerialNumberService();               
                return null;
            };            

            var menu = new FcoSimpleMenu();
            menu.Title = "AppServiceGen";

            P_Local_Upgrade_Folder = @"..\..\..\..\Upgrade";
            P_Local_AppWeb_Folder = @"..\..\..\AppWeb";

            add_menu_dmdata_gen(menu.RootNode, '1');
            add_menu_data_gen(menu.RootNode, '2');
            add_menu_package(menu.RootNode, '3', "local");

            add_menu_package(menu.RootNode, '4', "FtbAssmbling");

            add_menu_upload(menu.RootNode, 'a', "FtbAssmbling");

            add_menu_webwin_gen(menu.RootNode, 'w');
            add_menu_mvc_gen(menu.RootNode, 'v');

            menu.start();            
        }

        private static void add_menu_db_clone(FcoSimpleMenu.Node node_parent, char press_key)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.Title = "Clone資料到SERVERII";
            node_0.PressAction = x => do_db_clone();
            node_parent.addNodes(node_0);           
        }

        private static void do_db_clone()
        {
            var db_ctx = new FdbConfigContext();
            var dbii_ctx = new FdbConfigContext();
            foreach (var sys in FdmService.Instance.AllSystems.Values)
            {
                var cn = FtdConfigService.Instance.ConfigData.DbConns.findKey(sys.SystemName + "_II");
                dbii_ctx.setSystemConn(sys.SystemName, cn);
            }

            //Copy所有SERVERII表格
            var qry = new NsDmQuery();
            //var is_cont = false;
            foreach (var table in FdmService.Instance.AllTables.Values.OrderBy(x=>x.TableName))
            {
                //if (table.System.SystemName == "EO")
                //    continue;

                if (table.IsSessionTable)
                    continue;
                if (table.TableKind != FdmTableKindEnum.Table)
                    continue;
                if (table.TableProvider.DbReadOnly)
                    continue;
                //if (table.TableName == AppDataName.HC_VitalSignLimit)
                //{
                //    is_cont = true;
                //}
                //if (!is_cont)
                //    continue;

                qry.from(table.TableName);
                qry.selectAll();
                var dt = qry.queryData();               

                using (dbii_ctx.Use)
                {
                    var provider = table.TableProvider;                    
                    Console.WriteLine("Truncate Table : " + table.TableName);
                    provider.DbAccess.truncateTable(provider.DbTableName);

                    Console.WriteLine("Import Table : " + table.TableName);
                    foreach (DataRow row in dt.Rows)
                    {
                        row.SetAdded();
                    }
                    dt.ns_update_import_mode();
                }
            }
            Console.WriteLine("Import OK");
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
                    node_2.PressKey = (char)('2' + idx);
                    node_2.Title = "同步" + sys.Key + "系統";

                    node_2.PressAction = x => do_dmdata_gen(sys_code);
                    node_0.addNodes(node_2);
                    idx++;
                }
            }
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
        /// 
        /// </summary>
        private static void add_menu_webwin_gen(FcoSimpleMenu.Node node_parent, char press_key)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.Title = "產生WebListItem模型視窗";
            node_parent.addNodes(node_0);

            var node_1 = new FcoSimpleMenu.Node();
            node_1.PressKey = '1';
            node_1.Title = "產生ALL系統視窗";
            node_1.PressAction = x => do_webwin_gen(null);
            node_0.addNodes(node_1);

            {
                var idx = 0;
                foreach (var sys in FdmService.Instance.AllSystems.OrderBy(x => x.Key))
                {
                    var sys_code = sys.Key;
                    var node_2 = new FcoSimpleMenu.Node();
                    node_2.PressKey = (char)('2' + idx);
                    node_2.Title = "產生" + sys.Key + "系統視窗";

                    node_2.PressAction = x => do_webwin_gen(sys_code);
                    node_0.addNodes(node_2);
                    idx++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void do_webwin_gen(string sys_code)
        {
            //make sure output folder exists and clear

            var out_folder = FtdConfigService.Instance.replaceEnvironments(@"{@AppPath}\..\..\gen_web_listitem");
            {
                if (!Directory.Exists(out_folder))
                    Directory.CreateDirectory(out_folder);
                //清空目錄
                var dir = new DirectoryInfo(out_folder);
                dir.GetFiles().forEach(x => x.Delete());
                
            }

            var codegen = new FcgWebListItemModeCodeGen();
            codegen.OutputPath = out_folder;

            Action<string> _gen_system = (sys) =>
            {
                var system = FdmService.Instance.AllSystems[sys];
                foreach (var table in system.Tables)
                {
                    if (table.IsSessionTable)
                        continue;
                    codegen.TableName = table.TableName;
                    codegen.generate();
                }
            };

            if (sys_code.isNullOrEmpty())
            {
                foreach (var system in FdmService.Instance.AllSystems.Values)
                {
                    _gen_system(system.SystemName);
                }
            }
            else
            {
                _gen_system(sys_code);
            }

            Console.WriteLine("檔案產生於" + new DirectoryInfo(out_folder).FullName);
        }
   
        /// <summary>
        /// 強行別MENU清單
        /// </summary>
        private static void add_menu_data_gen(FcoSimpleMenu.Node node_parent, char press_key)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.Title = "同步資料庫";
            node_parent.addNodes(node_0);

            var node_1 = new FcoSimpleMenu.Node();
            node_1.PressKey = '1';
            node_1.Title = "同步ALL系統Table";
            node_1.PressAction = x => do_data_gen(null);
            node_0.addNodes(node_1);

            {
                var idx = 0;
                foreach (var sys in FdmService.Instance.AllSystems.OrderBy(x => x.Key))
                {
                    var sys_code = sys.Key;
                    var node_2 = new FcoSimpleMenu.Node();
                    node_2.PressKey = (char)('2' + idx);
                    node_2.Title = "同步" + sys.Key + "系統Table";

                    node_2.PressAction = x => do_data_gen(sys_code);
                    node_0.addNodes(node_2);
                    idx++;
                }
            }
        }     

        /// <summary>
        /// 資料庫同步
        /// </summary>
        private static void do_data_gen(string sys_code)
        {            
            var codegen = new NsDatabaseSyncCodeGen();
            var sqlFile = FtdConfigService.Instance.replaceEnvironments(@"{@AppPath}\..\..\Upgrade.Sql");
            codegen.renderUpgradeSql(sys_code, sqlFile, Console.Out);
        }

        /// <summary>
        /// 強行別MENU清單
        /// </summary>
        private static void add_menu_package(FcoSimpleMenu.Node node_parent, char press_key, string site_name)
        {            
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.PressAction = x => do_package(site_name);
            node_0.Title = "Web更新檔產生(" + site_name + ")";
            node_parent.addNodes(node_0);            
        }     

        static public void do_package(string site_name)
        {
            var site = getWebSite(site_name);           

            var web_folder = new FdpWebFolder(site.DeployUrl);
            var folder = new FdpSourceFolder(P_Local_AppWeb_Folder, web_folder);
            folder.load(site.filter_proc);
            folder.package(P_Local_Upgrade_Folder, site.Package_PrefixFileName + DateTime.Now.ToString("yyyyMMdd_HHmmss"), site.Package_RootName);
        }

        /// <summary>
        /// 強行別MENU清單
        /// </summary>
        private static void add_menu_upload(FcoSimpleMenu.Node node_parent, char press_key, string site_name)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.PressAction = x => do_upload(site_name);
            node_0.Title = "Web更新檔打包與上傳(" + site_name + ")";
            node_parent.addNodes(node_0);
        }

        static public void do_upload(string site_name)
        {
            var site = getWebSite(site_name);
            Console.WriteLine("上傳至" + site_name);
            Console.WriteLine("URL:" + site.DeployUrl);

            var upgrade_folder = P_Local_Upgrade_Folder;
            var deploy_url = new FdpWebFolder(site.DeployUrl);

            var folder = new DirectoryInfo(upgrade_folder);

            //Search Last Folder
            var folder_upload = folder.GetDirectories()  
                .Where(x => site.Package_PrefixFileName.isNullOrEmpty() ? true : x.Name.StartsWith(site.Package_PrefixFileName))
                .OrderByDescending(x => x.LastWriteTime)
                .FirstOrDefault();

            if (folder_upload == null)
                return;
            
            var file_upload_zip = folder + @"\" + folder_upload.Name + ".zip";

            if (File.Exists(file_upload_zip))
                File.Delete(file_upload_zip);

            //壓縮檔案
            Console.WriteLine(">>壓縮檔案:" + file_upload_zip );
            FtdIoHelper.zipFile(folder_upload.FullName, file_upload_zip);

            Console.WriteLine(">>上傳檔案:" + file_upload_zip);
            deploy_url.upload_file(file_upload_zip, (pack_count, pack_upload, pack_size) =>
            {
                var percent = (pack_upload * 100) / pack_count;
                var size = FtdIoHelper.toFileSizeName(pack_upload * pack_size);
                Console.WriteLine("Percent:" + percent + "%, UploadSize=" + size);
            });

            Console.WriteLine(">>上傳完成:" + file_upload_zip);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void add_menu_mvc_gen(FcoSimpleMenu.Node node_parent, char press_key)
        {
            var node_0 = new FcoSimpleMenu.Node();
            node_0.PressKey = press_key;
            node_0.Title = "產生MVC模型";
            node_parent.addNodes(node_0);

            var node_1 = new FcoSimpleMenu.Node();
            node_1.PressKey = '1';
            node_1.Title = "產生ALL系統MVC";
            node_1.PressAction = x => do_mvc_gen(null);
            node_0.addNodes(node_1);

            {
                var idx = 0;
                foreach (var sys in FdmService.Instance.AllSystems.OrderBy(x => x.Key))
                {
                    var sys_code = sys.Key;
                    var node_2 = new FcoSimpleMenu.Node();
                    node_2.PressKey = (char)('2' + idx);
                    node_2.Title = "產生" + sys.Key + "系統MVC";

                    node_2.PressAction = x => do_mvc_gen(sys_code);
                    node_0.addNodes(node_2);
                    idx++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void do_mvc_gen(string sys_code)
        {
            //make sure output folder exists and clear
            var out_folder = FtdConfigService.Instance.replaceEnvironments(@"{@AppPath}\..\..\gen_MVC");
            {
                if (!Directory.Exists(out_folder))
                    Directory.CreateDirectory(out_folder);

                //清空目錄
                var dir = new DirectoryInfo(out_folder);
                dir.GetFiles().forEach(x => x.Delete());
            }

            //Generate Controller and View files
            var codegen = new FcgMvcCodeGen();
            codegen.OutputPath = out_folder;

            Action<string> genSystem = (sys) =>
            {
                var system = FdmService.Instance.AllSystems[sys];
                foreach (var table in system.Tables)
                {
                    if (table.IsSessionTable)
                        continue;

                    codegen.TableName = table.TableName;
                    codegen.generate();
                }
            };

            if (sys_code.isNullOrEmpty())
            {
                foreach (var system in FdmService.Instance.AllSystems.Values)
                {
                    genSystem(system.SystemName);
                }
            }
            else
            {
                genSystem(sys_code);
            }

            //Generate DataService file
            var codegenDataService = new FcgDataServiceGen();
            codegenDataService.OutputPath = out_folder;
            if (sys_code.isNullOrEmpty())
            {
                foreach (var system in FdmService.Instance.AllSystems.Values)
                {
                    codegenDataService.SystemName = system.SystemName;
                    codegenDataService.generate();
                }
            }
            else
            {
                codegenDataService.SystemName = sys_code;
                codegenDataService.generate();
            }

            //Generate Query Model file
            var codegenQueryModel = new FcgQueryModelGen();
            codegenQueryModel.OutputPath = out_folder;
            if (sys_code.isNullOrEmpty())
            {
                foreach (var system in FdmService.Instance.AllSystems.Values)
                {
                    codegenQueryModel.SystemName = system.SystemName;
                    codegenQueryModel.generate();
                }
            }
            else
            {
                codegenQueryModel.SystemName = sys_code;
                codegenQueryModel.generate();
            }

            Console.WriteLine("檔案產生於" + new DirectoryInfo(out_folder).FullName);
        }
    }
}

