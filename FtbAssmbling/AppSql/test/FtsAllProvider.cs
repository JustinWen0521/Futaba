using System;
using System.Collections.Generic;
using System.Data;
using ftd.nsql;
using ftd.service;

namespace ftd.test
{
    public class FtsAllProvider
    {
        public static void run()
        {
            var tables = new List<DataTable>();
            foreach (var sys in FdmService.Instance.AllSystems)
            {
                foreach (var table in sys.Value.Tables)
                {
                    if (table.IsSessionTable)
                        continue;

                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " " + table.TableName);
                    var qry = new NsDmQuery();
                    var t1 = qry.from(table.TableName);
                    qry.selectAll(t1.AllExt);
                    qry.queryData();                    
                }
            }
        }
    }
}
