using System;
using System.Data;
using System.Linq;
using ftd.data.model;
using ftd.nsql;
using ftd.service;

namespace ftd.upgrade
{
    public static class Upgrade_StringNull
    {
        /// <summary>
        /// 將所有的空字串改成NULL
        /// </summary>
        public static void step1()
        {            
            foreach (var table in FdmService.Instance.AllTables)
            {
                var t1 = table.Value;
                if (t1.IsSessionTable)
                    continue;
                if (t1.TableKind != FdmTableKindEnum.Table)
                    continue;

                var cols = t1.Columns.Where(x => x.DataType.DotNetType == typeof(string)).Select(x => x).ToArray();
                var dmqry = new NsDmQuery();
                var t2 = dmqry.from(t1.TableName);
                var dt = dmqry.queryData();
                foreach (DataRow row in dt.Rows)
                    row.SetModified();
                dt.ns_update();
                Console.WriteLine(t1.TableName);
            }           
        }
    }
}
