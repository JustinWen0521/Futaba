using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ftd.service;
using Newtonsoft.Json;
using ftd.query.model;
using ftd.data;
using ftd.mvc.Areas.AL.Models;

namespace ftd.mvc.Areas.AL.Controllers
{
    /// <summary>
    /// 這是讀取組立工程明細 controller
    /// </summary>
    public class AssmblingDetailController : Controller
    {

        /// <summary>
        /// 預設選取多筆資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 取得此項目的資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetAssemblingDetailByDate(string code, string date)
        {
            AlAssmblingDetailQryModel qm = new AlAssmblingDetailQryModel();
            qm.Q_MCCode = code;
            qm.Q_Date = date;
            var dt = AlDataService.Instance.AlAssmblingDetail_getDayList(qm);


            List<PrdClass> data = new List<PrdClass>();
            PrdClass dataList = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                string codeIdxPast = null, codexPast= null;
                String[] arrTimeWork = null;
                var arrLine = HryDataService.Instance.getArrayForAssemblingDetail(ref arrTimeWork);
                Int32 sumMorning = 0, sumNighting = 0,index = 0;;

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    string codeIdx = Convert.ToString(row[AppDataName.ALA_MCID]);
                    string codex = Convert.ToString(row[AppDataName.ALA_MCCode]);
                    var hh = Convert.ToDateTime(row[AppDataName.ALAD_DATE]).Hour.ToString();
                    hh = (hh.Length == 1) ? String.Concat("0", hh) : hh;
                    index = -1;

                    #region 第一筆
                    if (codeIdxPast.isNullOrEmpty())
                    {
                        index = Array.IndexOf(arrTimeWork, hh);
                        if (index >= 0)
                        {
                            arrLine[index, 2] = Convert.ToString(row[AppDataName.ALAD_ITEM]);
                            arrLine[index, 3] = Convert.ToString(row[AppDataName.ALAD_QTY]);
                            if (Convert.ToInt32(hh) >= 7 && Convert.ToInt32(hh) <= 18)
                            {
                                sumMorning += Convert.ToInt32(arrLine[index, 3]);
                            }
                            if ((Convert.ToInt32(hh) >= 19 && Convert.ToInt32(hh) <= 23) || (Convert.ToInt32(hh) >= 0 && Convert.ToInt32(hh) <= 6))
                            {
                                sumNighting += Convert.ToInt32(arrLine[index, 3]);
                            }
                        }
                        codeIdxPast = codeIdx;
                        codexPast = codex;
                        continue;
                    }
                    #endregion

                    #region 下一條LINE
                    if (!codeIdxPast.equalIgnoreCase(codeIdx))
                    {
                        index = Array.IndexOf(arrTimeWork, "Morning小計");
                        arrLine[index, 3] = Convert.ToString(sumMorning);
                        index = Array.IndexOf(arrTimeWork, "Night小計");
                        arrLine[index, 3] = Convert.ToString(sumNighting);
                        index = Array.IndexOf(arrTimeWork, "Day合計");
                        arrLine[index, 3] = Convert.ToString(sumMorning + sumNighting);
                        dataList = new PrdClass(codexPast, arrLine);
                        data.Add(dataList);
                        sumMorning = 0;
                        sumNighting = 0;
                        codeIdxPast = codeIdx;
                        codexPast = codex;
                        arrLine = HryDataService.Instance.getArrayForAssemblingDetail(ref arrTimeWork);
                    }
                    #endregion

                    #region 下一筆
                    index = Array.IndexOf(arrTimeWork, hh);
                    if (index >= 0)
                    {
                        arrLine[index, 2] = Convert.ToString(row[AppDataName.ALAD_ITEM]);
                        arrLine[index, 3] = Convert.ToString(row[AppDataName.ALAD_QTY]);
                        if (Convert.ToInt32(hh) >= 7 && Convert.ToInt32(hh) <= 18)
                        {
                            sumMorning += Convert.ToInt32(arrLine[index, 3]);
                        }
                        if ((Convert.ToInt32(hh) >= 19 && Convert.ToInt32(hh) <= 23) || (Convert.ToInt32(hh) >= 0 && Convert.ToInt32(hh) <= 6))
                        {
                            sumNighting += Convert.ToInt32(arrLine[index, 3]);
                        }
                    }
                    #endregion

                }

                index = Array.IndexOf(arrTimeWork, "Morning小計");
                arrLine[index, 3] = Convert.ToString(sumMorning);
                index = Array.IndexOf(arrTimeWork, "Night小計");
                arrLine[index, 3] = Convert.ToString(sumNighting);
                index = Array.IndexOf(arrTimeWork, "Day合計");
                arrLine[index, 3] = Convert.ToString(sumMorning + sumNighting);
                dataList = new PrdClass(codexPast, arrLine);
                data.Add( dataList);

            }
            return JsonConvert.SerializeObject(data);

            //return "value";
        }


     
        // POST api/assmblingdetail
        public void Post(string value)
        {
        }

        // PUT api/assmblingdetail/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/assmblingdetail/5
        public void Delete(int id)
        {
        }


    }

    

}
