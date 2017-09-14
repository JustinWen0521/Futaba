using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd;

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

    }
}
