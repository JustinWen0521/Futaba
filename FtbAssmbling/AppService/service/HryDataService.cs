using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd;
using ftd.query.model;


namespace ftd.service
{
    /// <summary>
    /// 
    /// </summary>
    public class HryDataService : FtdServiceBase
    {
        public static readonly HryDataService Instance;

        static HryDataService()
        {
            FtdCreatorService.Instance.createObject<HryDataService>(ref Instance);
        }

        /// <summary>
        /// 20170826字串轉為日期格式
        /// </summary>
        /// <param name="date"></param>
        /// <param name="resultDate"></param>
        public void getDateFromString(string date, ref DateTime resultDate)
        {
            if (!date.isNullOrEmpty())
            {
                var yy = Convert.ToInt32(date.Substring(0, 4));
                var mm = Convert.ToInt32(date.Substring(4, 2));
                var dd = Convert.ToInt32(date.Substring(6, 2));
                resultDate = new DateTime(yy, mm, dd);
            }
        }

        /// <summary>
        /// 統計一天的時間範圍
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dteDateS"></param>
        /// <param name="dteDateE"></param>
        public void getOneDayForAssemblingDetail(string strDate, ref DateTime dteDateS, ref DateTime dteDateE)
        {
            DateTime dteTmp = DateTime.Today;
            if (!strDate.isNullOrEmpty())
            {
                getDateFromString(strDate , ref dteTmp);
                dteDateS = dteTmp.AddDays(-1).AddHours(19);
                dteDateE = dteTmp.AddHours(18);
            }            
        }


        public List<PrdEditDetail> getArrayForAssemblingDetail(ref String[] arrTimeWork)
        {
            arrTimeWork = new String[]{
                "07","08","09","10","11","12","13","14","15","16","17","18","Morning小計",
                "19","20","21","22","23","00","01","02","03","04","05","06","Night小計" ,"Day合計"};

            //String[,] arrMCCode = new String[27, 4];
            List<PrdEditDetail> listMCCode = new List<PrdEditDetail>();
            for (var i = 0; i < arrTimeWork.Length; i++)
            {
                int outNum = 0;
                PrdEditDetail prdDetail = new PrdEditDetail();
                prdDetail.index = (arrTimeWork[i]);

                if (int.TryParse(arrTimeWork[i], out outNum))
                {
                    prdDetail.dateHr = (arrTimeWork[i] + ":30");
                }
                else if(arrTimeWork[i].Contains("小計"))
                {
                    prdDetail.dateHr = ("小計");
                }
                else if (arrTimeWork[i].Contains("合計"))
                {
                    prdDetail.dateHr = ("日合計");
                }
                listMCCode.Add(prdDetail);
            }
            return listMCCode;
        }




    }
}
