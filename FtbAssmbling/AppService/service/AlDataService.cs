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
    public class AlDataService : FtdServiceBase
    {
        public static readonly AlDataService Instance;

        /// <summary>
        /// 每條線別第一台機器位置
        /// </summary>
        private static int FirstLocation = 0;

        static AlDataService()
        {            
            FtdCreatorService.Instance.createObject<AlDataService>(ref Instance);
        }

        #region [AL_Assmbling]
        public AL_AssmblingDataTable AlAssmbling_getList(AlAssmblingQryModel qm)
        {

            var dt = NsDmHelper.AL_Assmbling
                .selectAll(t => t.AllExt)            
                .query();

            return dt;
        }

        public AL_AssmblingDataTable AlAssmbling_create(int rowCount = 1)
        {
            var dt = new AL_AssmblingDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public AL_AssmblingDataTable AlAssmbling_getById(string id)
        {
            var row = NsDmHelper.AL_Assmbling
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool AlAssmbling_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.AL_Assmbling
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }

        /// <summary>
        /// 取得該線別的所有機台資訊
        /// </summary>
        /// <param name="colId">線別ID(0~6線)</param>
        /// <returns>AL_AssmblingDataTable</returns>
        public AL_AssmblingDataTable AL_Assmbling_getAllList(int colId)
        {
            if (colId == null || colId < 0)
                return null;

            var dt = NsDmHelper.AL_Assmbling
                .selectAll(t => t.AllExt)
                .where(t => t.ALA_SEQCol == colId.toConstReq1())                
                .orderby(t => t.ALA_SEQRow.Asc)
                .query();

            return dt;
        }

        /// <summary>
        /// 取得目前生產線所有線別
        /// </summary>
        /// <param name="colId">哪條線(不傳就取全部)</param>
        /// <returns>線別數量</returns>
        public AL_AssmblingDataTable AL_Assmbling_getProductLine(int? colId)
        {
            AL_AssmblingDataTable dt = NsDmHelper.AL_Assmbling
                                                    .selectAll(t => t.AllExt)
                                                    .where(t => t.ALA_SEQCol == colId.toConstOpt1())
                                                    .orderby(t => t.ALA_SEQCol.Asc)
                                                    .query();

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt;
        }

        #endregion

        #region [AL_AssmblingLog]
        public AL_AssmblingLogDataTable AlAssmblingLog_getList(AlAssmblingLogQryModel qm)
        {
            var dt = NsDmHelper.AL_AssmblingLog
                .selectAll(t => t.AllExt)
                .query();

            return dt;
        }

        public AL_AssmblingLogDataTable AlAssmblingLog_create(int rowCount = 1)
        {
            var dt = new AL_AssmblingLogDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public AL_AssmblingLogDataTable AlAssmblingLog_getById(string id)
        {
            var row = NsDmHelper.AL_AssmblingLog
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool AlAssmblingLog_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.AL_AssmblingLog
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [AL_AssmblingDetail]
        public DataTable AlAssmblingDetail_getDayList(AlAssmblingDetailQryModel qm)
        {
            DateTime dteTmp = DateTime.Today; 
            DateTime dteDateS = DateTime.MinValue;
            DateTime dteDateE = DateTime.Today;
            HryDataService.Instance.getOneDayForAssemblingDetail(qm.Q_Date, ref dteDateS, ref dteDateE);

            var qry = new NsDbQuery();
            qry.setSelect(s =>
            {
                var t1 = s.from<AL_Assmbling>();
                var t2 = s.leftJoin<AL_AssmblingDetail>().on(t => t.ALAD_MCID == t1.ALA_MCID);
                s.select( t1.ALA_MCID , t1.ALA_MCCode , t1.ALA_MCName , t2.ALAD_DATE , t2.ALAD_ITEM , t2.ALAD_QTY );
                s.Where = t1.ALA_MCCode.contains(qm.Q_MCCode.toConstOpt1())
                          & t2.ALAD_DATE >= dteDateS
                          & t2.ALAD_DATE <= dteDateE;
                s.groupBy(t1.ALA_MCID, t1.ALA_MCCode, t1.ALA_MCName, t2.ALAD_DATE, t2.ALAD_ITEM, t2.ALAD_QTY);
                s.orderBy(new[] { t1.ALA_MCName.Asc, t2.ALAD_DATE.Asc });
            });

            var dt = qry.queryData();
            return dt;
        }
        #endregion

        #region [AL_AssmblingDetail_ByMCID]
        /// <summary>
        /// 取得日期內的所有機台ID的資料
        /// </summary>
        /// <param name="iDate">日期(哪一天)</param>
        /// <param name="iMCIDList">要查的機台ID</param>
        /// <returns>機台該日期所有資料</returns>
        public DataTable AlAssmblingDetail_getDayTotalByMCID(string iDate,List<string> iMCIDList)
        {
            DateTime dteTmp = DateTime.Today;
            DateTime dteDateS = DateTime.MinValue;
            DateTime dteDateE = DateTime.Today;
            HryDataService.Instance.getOneDayForAssemblingDetail(iDate, ref dteDateS, ref dteDateE);

            var qry = new NsDbQuery();
            qry.setSelect(s =>
            {
                var t1 = s.from<AL_Assmbling>();
                var t2 = s.leftJoin<AL_AssmblingDetail>().on(t => t.ALAD_MCID == t1.ALA_MCID);
                s.select(t1.ALA_MCID, t1.ALA_MCCode, t1.ALA_MCName, t2.ALAD_DATE, t2.ALAD_ITEM, t2.ALAD_QTY);
                s.Where = t1.ALA_MCID.@in(iMCIDList)
                          & t2.ALAD_DATE >= dteDateS
                          & t2.ALAD_DATE <= dteDateE;
                s.groupBy(t1.ALA_MCID, t1.ALA_MCCode, t1.ALA_MCName, t2.ALAD_DATE, t2.ALAD_ITEM, t2.ALAD_QTY);
                s.orderBy(new[] { t1.ALA_MCID.Asc, t2.ALAD_DATE.Asc });
            });
            var dt = qry.queryData();
            return dt;
        }
        #endregion
    }
}
