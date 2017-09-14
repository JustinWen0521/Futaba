using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.nsql;
using ftd.data;
using System.Data;

namespace ftd.upgrade
{
    public class Upgrade200902
    {
        /// <summary>
        /// 修正部門順序
        /// </summary>
        public static void step1()
        {
            var parentIds = NsDmHelper.EO_Department.query().Select(x => x.EOD_ParentId).Distinct().ToArray();
            foreach (var parentId in parentIds)
            {
                var dt = NsDmHelper.EO_Department.where(t => t.EOD_ParentId == parentId)
                    .orderby(t => new [] { t.EOD_SortNo.Asc, t.EOD_DepartmentName.Asc})
                    .query();
                for (var i = 0; i < dt.Count; i++)
                    dt[i].EOD_SortNo = i + 1;
                dt.ns_update();
            }
        }

        /// <summary>
        /// 修正人員部門為群組者
        /// </summary>
        public static void step2()
        {
            var qry = new NsDbQuery();
            qry.setSelect(s => {
                var t1 = s.from<EO_Employee>();
                var t2 = s.join<EO_Department>()
                    .on(t => t1.EOE_DepartmentId == t.EOD_DepartmentId);
                s.Where = t2.EOD_DepartmentType == "B";
                s.select(t1.EOE_EmployeeId);
            });
            var pks = qry.queryKeys<string>();

            var dt = NsDmHelper.EO_Employee.wherepks(pks).query();
            foreach (var row in dt)
                row.EOE_DepartmentId = "";
            dt.ns_update();
        }

        /// <summary>
        /// 移除無人的群組清單
        /// </summary>
        public static void step3()
        {
            var qry = new NsDbQuery();
            qry.setSelect(s =>
            {
                var t1 = s.from<EO_DeptMember>();
                var t2 = s.leftJoin<EO_Employee>()
                    .on(t => t1.EODM_MemberId == t.EOE_EmployeeId);
                var t3 = s.leftJoin<EO_Department>()
                    .on(t => t1.EODM_DeptId == t.EOD_DepartmentId);
                s.Where = t2.EOE_EmployeeId == null | t3.EOD_DepartmentId == null;
                s.select(t1.AllPhysical);
            });
            var dt = qry.queryData<EO_DeptMemberDataTable>();
            foreach (DataRow row in dt.Rows)
                row.Delete();          
            dt.ns_update();
        }
    }
}
