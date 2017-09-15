using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.service;
using Newtonsoft.Json;
using ftd.query.model;
using System.Data;

namespace ftd.mvc.Controllers
{
    public class AssmblingController : Controller
    {
        /// <summary>
        /// 早上7點
        /// </summary>
        private static int SEVEN = 07;
        /// <summary>
        /// 晚上7點
        /// </summary>
        private static int NINETEEN = 19;

        /// <summary>
        /// 取得早班小計或晚班小計
        /// </summary>
        private enum eDayType 
        {
            Morning,
            Night,
        }

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

        /// <summary>
        /// 計算日,夜班總合
        /// </summary>
        /// <param name="dt">機台當天所有的資料</param>
        /// <param name="DayType">取日班 or 夜班</param>
        /// <returns>總合</returns>
        private int GetMachineTotalValue(DataTable dt ,eDayType DayType) 
        {
            int totalValue = 0;
            if (dt == null || dt.Rows.Count == 0)
                return totalValue;
         
            DateTime NTime = new DateTime(2017, 02, 24, SEVEN, 00, 00);//之後改取當天日期的早上7點
            switch (DayType) 
            {
                case eDayType.Morning:
                    DateTime MTime = new DateTime(2017,02,24,NINETEEN,00,00);//之後改取當天日期的晚上7點
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rowData = dt.Rows[i];
                        if(Convert.ToDateTime(rowData[AppDataName.ALAD_DATE]) >= NTime 
                            && Convert.ToDateTime(rowData[AppDataName.ALAD_DATE]) < MTime)
                        {
                            string qty = rowData[AppDataName.ALAD_QTY].ToString().Trim();
                            if (qty != null && !qty.equalIgnoreCase(string.Empty))
                                totalValue += Convert.ToInt32(qty);
                        }
                    }
                    break;
                case eDayType.Night:
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rowData = dt.Rows[i];
                        if (Convert.ToDateTime(rowData[AppDataName.ALAD_DATE]) < NTime)
                        {
                            string qty = rowData[AppDataName.ALAD_QTY].ToString().Trim();
                            if (qty != null && !qty.equalIgnoreCase(string.Empty))
                                totalValue += Convert.ToInt32(rowData[AppDataName.ALAD_QTY]);
                        }
                    }
                    break;
                default:
                    //Error 傳入不存在的Type
                    break;
            }
            return totalValue;
        }

        /// <summary>
        /// 取得產品名稱
        /// </summary>
        /// <param name="dt">生產資料</param>
        /// <returns>產品名稱</returns>
        private string GetProductName(DataTable dt) 
        {
            if (dt == null || dt.Rows.Count == 0)
                return string.Empty;

            //取最後一台機台的產品名稱
            string productName = dt.Rows[(dt.Rows.Count - 1)]["ALAD_ITEM"].ToString().Replace("\0",string.Empty);
            if (productName != null && !productName.equalIgnoreCase(string.Empty))
                return productName;
            else
                return string.Empty;
        }

        /// <summary>
        /// 取得該線別所有機台資料
        /// </summary>
        /// <param name="Id">線別ID(0~6)</param>
        /// <returns>線別機台所有資料</returns>
        private MachineLineClass getMachineListClassData(int ColId)
        {
            List<MachineClass> machineList = new List<MachineClass>();
            var alservice = AlDataService.Instance;
            AL_AssmblingDataTable dtData = alservice.AL_Assmbling_getAllList(ColId);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                //Error
                return null;
            }
            string ProductName = string.Empty;
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                string MachineName = string.Empty;
                AL_AssmblingRow rowData = dtData.Rows[i].cast_as<AL_AssmblingRow>();
                //取得機台名稱
                MachineName = rowData.ALA_MCName;
                AlAssmblingDetailQryModel adq = new AlAssmblingDetailQryModel 
                {
                    Q_MCID = rowData.ALA_MCID,//用機台ID取得資料
                    Q_Date = "20170224"//目前還沒有實際日期資料
                    //Q_Date = DateTime.Now.ToString("yyyy-MM-dd")
                };
                var data = alservice.AlAssmblingDetail_getDayTotalByMCID(adq);
                //取得產品名稱
                if(ProductName.equalIgnoreCase(string.Empty))
                    ProductName = GetProductName(data);

                MachineClass Machinedata = new MachineClass();
                int number = i + 1;
                Machinedata.MachineId = number.ToString();
                if (MachineName != null && !MachineName.Equals(string.Empty))
                    Machinedata.MachineName = MachineName;
                else
                    Machinedata.MachineName = "Machine" + number;
                Machinedata.MachineCol = (ColId + 1).ToString();
                Machinedata.MachineRow = number.ToString();
                Machinedata.MachineDay = GetMachineTotalValue(data, eDayType.Morning).ToString();
                Machinedata.MachineNight = GetMachineTotalValue(data, eDayType.Night).ToString();
                machineList.Add(Machinedata);
            }
            MachineLineClass LineData = new MachineLineClass
            {
                Line = (ColId + 1).ToString(),
                Product = ProductName,
                MachineList = machineList
            };
            return LineData;
        }

        /// <summary>
        /// 取得目前所有機台資料(改為動態取)
        /// </summary>
        /// <param name="Id">取某一線別(不傳取全部)</param>
        /// <returns>線別資料</returns>
        [HttpGet]
        public string GetProductLineInfo(string Id)
        {
            List<MachineLineClass> data = new List<MachineLineClass>();
            int? LineID = null;
            if (Id != null) 
            {
                if (!Id.Equals(string.Empty))
                    LineID = Convert.ToInt32(Id);
            }
            AL_AssmblingDataTable dt = AlDataService.Instance.AL_Assmbling_getProductLine(LineID);
            foreach (AL_AssmblingRow item in dt.Rows) 
            {
                int? col = item.ALA_SEQCol;
                data.Add(getMachineListClassData(col.Value));
            }
            return JsonConvert.SerializeObject(data);
        }
    }

    public class MachineLineClass 
    {
        public string Line;
        public string Product;
        public List<MachineClass> MachineList;
    }

    public class MachineClass 
    {
        public string MachineId;
        public string MachineName;
        public string MachineCol;
        public string MachineRow;
        public string MachineDay;
        public string MachineNight;
    }

}
