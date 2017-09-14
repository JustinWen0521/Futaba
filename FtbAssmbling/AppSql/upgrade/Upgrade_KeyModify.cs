using System.Collections;
using System.Data;
using System.Linq;
using ftd.data.model;
using ftd.nsql;
using ftd.service;

namespace ftd.upgrade
{
    public static class Upgrade_KeyModify
    {

        /// <summary>
        /// 當資料庫建值前置名稱有異動時，可呼叫此程序變更之。
        /// 將以Link關係自動找出所有應改異動的件值
        /// <param node_4="primayr_key_fieldName">ex.EODM_DeptMemberId</param>
        /// <param node_4="oldKeyPrefix">ex.EODE_</param>
        /// </summary>
        public static void alterKeyPrefixName(string primary_key_fieldName, string oldKeyPrefix)
        {
            var fields = FdmService.Instance.AllColumns
                .Select(x => x.Value)
                .Where(x => !x.Table.IsSessionTable && x.Table.TableKind == FdmTableKindEnum.Table)
                .Where(x => x.ColumnKind == FdmColumnKind.Link && x.Links.exists(x2 => x2.LinkKey.ColumnName == primary_key_fieldName))
                .ToList();

            fields.Add(FdmService.Instance.AllColumns[primary_key_fieldName]);

            //逐一修正每一個鍵值
            var o_table = FdmService.Instance.AllColumns[primary_key_fieldName].Table;
            foreach (var field in fields)
            {
                var qry = new NsDmQuery();
                var t1 = qry.from(field.Table.TableName);
                qry.Where = t1[field.ColumnName].left(oldKeyPrefix.Length) == oldKeyPrefix;
                var dt = qry.queryData();

                foreach (DataRow row in dt.Rows)
                {
                    var keynew = o_table.KeyPrefix + row.getString(field.ColumnName).Substring(oldKeyPrefix.Length);
                    row[field.ColumnName] = keynew;
                }
                dt.ns_update();
            }
        }
    }
}
