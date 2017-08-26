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
    public class AlDataService : FtdServiceBase
    {
        public static readonly AlDataService Instance;

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

        public AL_AssmblingDataTable AL_Assmbling_getAllList(string colId)
        {
            var dt = NsDmHelper.AL_Assmbling
                .selectAll(t => t.AllExt)
                .where(t => t.ALA_SEQCol == colId.toConstOpt1())
                .query();

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
                s.orderBy(new[] { t1.ALA_MCID.Asc, t2.ALAD_DATE.Asc });
            });

            var dt = qry.queryData();
            return dt;


        }
        #endregion

    }
}
