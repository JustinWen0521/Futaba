using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ftd.service;
using Newtonsoft.Json;

namespace ftd.mvc.Controllers
{
    public class AssmblingController : Controller
    {

        public AssmblingController() 
        {
            
        }

        //
        // GET: /Assmbling/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 預設選取多筆資料
        /// </summary>
        /// <returns></returns>
        public String Get()
        {
            //return new System.Net.Http.HttpResponseMessage()
            //{
            //    StatusCode = System.Net.HttpStatusCode.OK,
            //    Content = new StringContent("Test",Encoding.GetEncoding("UTF-8")),
                
            //};

            //return new string[] 
            //{
            //    "Value1",
            //    "Value2"
            //};


            return "OK";
        }

        public string GetAllLineInfo() 
        {
            var alservice = AlDataService.Instance;
            var dt = alservice.AL_Assmbling_getAllList(string.Empty);

            Dictionary<string, Dictionary<string, List<MachineClass>>> data = new Dictionary<string, Dictionary<string, List<MachineClass>>>();
            for (int j = 0; j < 7; j++)
            {

                Dictionary<string, List<MachineClass>> MachineProduct = new Dictionary<string, List<MachineClass>>();
                List<MachineClass> machineList = new List<MachineClass>();
                for (int i = 0; i < 5; i++)
                {
                    MachineClass Machinedata = new MachineClass();
                    int number = i + 1;
                    Machinedata.MachineId = number.ToString();
                    Machinedata.MachineName = "Machine" + number;
                    Machinedata.MachineCol = (j + 1).ToString();
                    Machinedata.MachineRow = number.ToString();
                    Machinedata.MachineSun = (number * 100).ToString();
                    Machinedata.MachineNight = (number * 100).ToString();
                    machineList.Add(Machinedata);
                }
                MachineProduct.Add("ABCDEFG001", machineList);
                data.Add((j + 1).ToString(), MachineProduct);
            }
            return JsonConvert.SerializeObject(data);
        }

        [HttpGet]
        public string GetLineInfo(int Id)
        {
            Dictionary<string, Dictionary<string, List<MachineClass>>> data = new Dictionary<string, Dictionary<string, List<MachineClass>>>();
            for (int j = 0; j < 1; j++)
            {

                Dictionary<string, List<MachineClass>> MachineProduct = new Dictionary<string, List<MachineClass>>();
                List<MachineClass> machineList = new List<MachineClass>();
                for (int i = 0; i < 5; i++)
                {
                    MachineClass Machinedata = new MachineClass();
                    int number = i + 1;
                    Machinedata.MachineId = number.ToString();
                    Machinedata.MachineName = "Machine" + number;
                    Machinedata.MachineCol = (Id + 1).ToString();
                    Machinedata.MachineRow = number.ToString();
                    Machinedata.MachineSun = (number * 100).ToString();
                    Machinedata.MachineNight = (number * 100).ToString();
                    machineList.Add(Machinedata);
                }
                MachineProduct.Add("ABCDEFG001", machineList);
                data.Add((Id + 1).ToString(), MachineProduct);
            }
            return JsonConvert.SerializeObject(data);
        }

        //[HttpGet]
        //public HttpResponseMessage GetLineInfo(int Id)
        //{
        //    Dictionary<string, Dictionary<string, List<MachineClass>>> data = new Dictionary<string, Dictionary<string, List<MachineClass>>>();
        //    for (int j = 0; j < 1; j++)
        //    {

        //        Dictionary<string, List<MachineClass>> MachineProduct = new Dictionary<string, List<MachineClass>>();
        //        List<MachineClass> machineList = new List<MachineClass>();
        //        for (int i = 0; i < 5; i++)
        //        {
        //            MachineClass Machinedata = new MachineClass();
        //            int number = i + 1;
        //            Machinedata.MachineId = number.ToString();
        //            Machinedata.MachineName = "Machine" + number;
        //            Machinedata.MachineCol = (Id + 1).ToString();
        //            Machinedata.MachineRow = number.ToString();
        //            Machinedata.MachineSun = (number * 100).ToString();
        //            Machinedata.MachineNight = (number * 100).ToString();
        //            machineList.Add(Machinedata);
        //        }
        //        MachineProduct.Add("ABCDEFG001", machineList);
        //        data.Add((Id + 1).ToString(), MachineProduct);
        //    }
        //    //return JsonConvert.SerializeObject(data);

        //    return new HttpResponseMessage()
        //    {
        //        StatusCode = System.Net.HttpStatusCode.OK,
        //        Content = new StringContent(JsonConvert.SerializeObject(data)),
        //    };

        //}

    }

    public class MachineClass 
    {
        public string MachineId;
        public string MachineName;
        public string MachineCol;
        public string MachineRow;
        public string MachineSun;
        public string MachineNight;
    }

}
