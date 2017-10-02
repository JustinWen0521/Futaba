﻿using System;
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
        /// 假帳號
        /// </summary>
        private string username = "futaba";
        /// <summary>
        /// 假密碼
        /// </summary>
        private string password = "1234";

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
            return "OK";
        }

        /// <summary>
        /// 取得目前所有機台資料(改為動態取)
        /// </summary>
        /// <param name="itoken">拿登入後的token來要資料</param>
        /// <param name="Id">線別(沒填值表示取全部)</param>
        /// <returns>取得所有機台資料</returns>
        [HttpGet]
        public string GetProductLineInfo(string itoken,string Id)                                             
        {
            if (itoken == null || itoken.equalIgnoreCase(string.Empty))
                return string.Empty;

            if (!itoken.equalIgnoreCase((username + password)))//token比對失敗,表示帳密輸入錯誤
                return string.Empty;

            List<MachineLineClass> data = new List<MachineLineClass>();
            int? LineID = null;
            if (Id != null) 
            {
                if (!Id.Equals(string.Empty))
                    LineID = Convert.ToInt32(Id);
            }
            AL_AssmblingDataTable dt = AlDataService.Instance.AL_Assmbling_getProductLine(LineID);
            List<string> MCIDList = new List<string>();
            foreach (AL_AssmblingRow item in dt.Rows) 
            {
                MCIDList.Add(item.ALA_MCID);//取得所有機台的MCID
            }
            string today = DateTime.Now.ToString("yyyyMMdd");
            var Detail_dt = AlDataService.Instance.AlAssmblingDetail_getDayTotalByMCID(today, MCIDList);
            Dictionary<string, SumValueClass> mQtyTotalList = SumTotalValue(Detail_dt);
            data = SelectLines(dt, mQtyTotalList);
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 轉換加總所有機台資訊
        /// </summary>
        /// <param name="idt">機台主檔</param>
        /// <param name="iSumValue">所有機台總合資料</param>
        /// <returns>所有機台資料</returns>
        private List<MachineLineClass> SelectLines(AL_AssmblingDataTable idt, Dictionary<string, SumValueClass> iSumValue) 
        {
            //<機台線別,所有機台加總資料>
            Dictionary<int,List<MachineClass>> lineList = new Dictionary<int,List<MachineClass>>();
            foreach (var item in iSumValue) 
            {
                foreach (AL_AssmblingRow idr in idt.Rows) 
                {
                    if (idr.ALA_MCID.Equals(item.Key))
                    {
                        MachineClass MachineData = new MachineClass
                        {
                            MachineId = idr.ALA_MCID,
                            MachineName = idr.ALA_MCName,
                            MachineCol = (idr.ALA_SEQCol.Value + 1).ToString(),//UI顯示從1開始
                            MachineRow = (idr.ALA_SEQRow.Value + 1).ToString(),//UI顯示從1開始
                            MachineDay = item.Value.Day_Value.ToString(),
                            MachineNight = item.Value.Night_Value.ToString()
                        };
                        if (lineList.ContainsKey(idr.ALA_SEQCol.Value))//已建立該線別
                            lineList[idr.ALA_SEQCol.Value].Add(MachineData);
                        else 
                        {
                            List<MachineClass> machineList = new List<MachineClass>();
                            machineList.Add(MachineData);
                            lineList.Add(idr.ALA_SEQCol.Value, machineList);
                        }
                    }
                }
            }          
            //線別排序
            var SorList = lineList.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            //機台位置排序
            foreach (var item in SorList.Values)
                item.Sort((x,y) => x.MachineRow.CompareTo(y.MachineRow));

            List<MachineLineClass> mlineList = new List<MachineLineClass>();
            foreach (var item in SorList) 
            {
                string mProductName = GetProductName(item.Value, iSumValue);
                MachineLineClass machineLineData = new MachineLineClass
                {
                    Line = (item.Key + 1).ToString(),//UI顯示從1開始                                   
                    MachineList = item.Value
                };
                //取得機台產品名稱
                if (mProductName != null && !mProductName.Equals(string.Empty))
                    machineLineData.Product = mProductName;

                mlineList.Add(machineLineData);
            }
            return mlineList;
        }

        /// <summary>
        /// 取得目前在Run的產品名稱
        /// </summary>
        /// <param name="iItemList">組好的MachineClass</param>
        /// <param name="iSumValue">機台的加總數值(含產品名稱)</param>
        /// <returns></returns>
        private string GetProductName(List<MachineClass> iItemList, Dictionary<string, SumValueClass> iSumValue) 
        {
            if (iSumValue == null || iSumValue.Count == 0 || iItemList == null || iItemList.Count == 0)
                return string.Empty;

            for (int i = 0; i < iItemList.Count; i++) 
            {
                string mProduct = iSumValue[iItemList[i].MachineId].ProductName.Replace("\0", string.Empty).Trim();
                if (mProduct != null && !mProduct.Equals(string.Empty))
                    return mProduct;
            }
            return string.Empty;
        }

        /// <summary>
        /// 加總機台日夜班數量總合(20170927 by TP夜班19~23時會自動先+1天,故先配合修改,之後有可能會拿掉 by Justin)
        /// </summary>
        /// <param name="idt">所有資料</param>
        /// <returns>機台日夜班數量總合</returns>
        //private Dictionary<string, SumValueClass> SumTotalValue(DataTable idt)
        //{
        //    if (idt == null || idt.Rows.Count == 0)
        //        return null;

        //    Dictionary<string, SumValueClass> mTotalList = new Dictionary<string, SumValueClass>();
        //    //夜班開始時間
        //    DateTime STime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, NINETEEN, 00, 00);//取當天日期的早上19點為開始
        //    //夜班結束時間
        //    DateTime ETime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, SEVEN, 00, 00);//取當天日期的晚上7點為結束            
        //    foreach (DataRow item in idt.Rows)
        //    {
        //        string MCID = item[AppDataName.ALA_MCID].ToString();
        //        DateTime mValueDateTime = Convert.ToDateTime(item[AppDataName.ALAD_DATE]);
        //        bool IsDay = true;
        //        if (mValueDateTime != null)
        //        {
        //            IsDay = mValueDateTime < STime &&
        //                    mValueDateTime >= ETime ? true : false;// True:日班 , False:夜班
        //        }

        //        if (!mTotalList.ContainsKey(MCID))
        //        {
        //            SumValueClass mNewSumValue = new SumValueClass
        //            {
        //                Day_Value = 0,
        //                Night_Value = 0
        //            };
        //            mTotalList.Add(MCID, mNewSumValue);
        //        }
        //        SumQtyValue(IsDay, mTotalList[MCID], item);
        //    }
        //    return mTotalList;
        //}

        /// <summary>
        /// 加總機台日夜班數量總合(20170927 by TP夜班19~23時會自動先+1天,故此方法先註解,之後可能會改回來,勿刪 by Justin)
        /// </summary>
        /// <param name="idt">所有資料</param>
        /// <returns>機台日夜班數量總合</returns>
        private Dictionary<string, SumValueClass> SumTotalValue(DataTable idt)
        {
            if (idt == null || idt.Rows.Count == 0)
                return null;

            Dictionary<string, SumValueClass> mTotalList = new Dictionary<string, SumValueClass>();
            DateTime NTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, SEVEN, 00, 00);//取當天日期的早上7點
            foreach (DataRow item in idt.Rows)
            {
                string MCID = item[AppDataName.ALA_MCID].ToString();
                bool IsDay = Convert.ToDateTime(item[AppDataName.ALAD_DATE]) < NTime ? false : true;//True : 日班,False:夜班
                if (!mTotalList.ContainsKey(MCID))
                {
                    SumValueClass mNewSumValue = new SumValueClass
                    {
                        Day_Value = 0,
                        Night_Value = 0
                    };
                    mTotalList.Add(MCID, mNewSumValue);
                }
                SumQtyValue(IsDay, mTotalList[MCID], item);
            }
            return mTotalList;
        }

        /// <summary>
        /// 加總日夜班的值
        /// </summary>
        /// <param name="iType">True:日班 , False:夜班</param>
        /// <param name="iSumValue">日夜班的值Class</param>
        /// <param name="iDr">該筆資料總合</param>
        private void SumQtyValue(bool iType,SumValueClass iSumValue,DataRow iDr)
        {
            int mQty = ChangeQtyValueType(iDr[AppDataName.ALAD_QTY].ToString());
            if (iType)
                iSumValue.Day_Value += mQty;
            else
                iSumValue.Night_Value += mQty;

            iSumValue.ProductName = iDr[AppDataName.ALAD_ITEM].ToString();
        }

        /// <summary>
        /// 字串轉換數字
        /// </summary>
        /// <param name="iQty">機台數量</param>
        /// <returns>return int</returns>
        private int ChangeQtyValueType(string iQty) 
        {
            if (iQty != null && !iQty.equalIgnoreCase(string.Empty))
                return Convert.ToInt32(iQty);
            else
                return 0;
        }

        /// <summary>
        /// Login_登入
        /// </summary>
        /// <param name="iUsername">帳號</param>
        /// <param name="iPassWord">密碼</param>
        /// <returns>token = 帳號+密碼(ErrorCode : (-1:帳密有空值),(-2:帳密錯誤))</returns>
        [HttpGet]
        public string Login(string iUsername,string iPassWord) 
        {
            string token = string.Empty;
            if (iUsername == null || iUsername.equalIgnoreCase(string.Empty) || iPassWord == null || iPassWord.equalIgnoreCase(string.Empty))
                return "-1";

            if (iUsername.equalIgnoreCase(username) && iPassWord.equalIgnoreCase(password))
                token = username + password;//token = futaba1234
            else
                token = "-2";

            return token;
        }

    }

    /// <summary>
    /// 計算機台數量總合
    /// </summary>
    class SumValueClass 
    {
        /// <summary>
        /// 該機台Run的產品名
        /// </summary>
        public string ProductName;
        /// <summary>
        /// 日夜總合
        /// </summary>
        public int Day_Value;
        /// <summary>
        /// 夜班總合
        /// </summary>
        public int Night_Value;
    }
    /// <summary>
    /// 該線別所有資料
    /// </summary>
    public class MachineLineClass 
    {
        /// <summary>
        /// 哪一條線
        /// </summary>
        public string Line;
        /// <summary>
        /// 該線別產品名
        /// </summary>
        public string Product;
        /// <summary>
        /// 該線別所有機台資料
        /// </summary>
        public List<MachineClass> MachineList;
    }
    /// <summary>
    /// 該線別所有機台資料
    /// </summary>
    public class MachineClass 
    {
        /// <summary>
        /// 機台MCID
        /// </summary>
        public string MachineId;
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string MachineName;
        /// <summary>
        /// 機台位置(列)
        /// </summary>
        public string MachineCol;
        /// <summary>
        /// 機台位置(行)
        /// </summary>
        public string MachineRow;
        /// <summary>
        /// 機台日班總合
        /// </summary>
        public string MachineDay;
        /// <summary>
        /// 機台夜班總合
        /// </summary>
        public string MachineNight;
    }

}
