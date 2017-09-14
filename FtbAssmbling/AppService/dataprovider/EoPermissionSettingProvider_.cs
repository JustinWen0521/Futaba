using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;EOPS&gt;權限設定表{PermissonSetting}
    /// </summary>
    public partial class EoPermissionSettingProvider 
    {
        protected override void onSchemaLoaded()
        {
            addTypedSqlHandler()
                .setColumns(AppDataName.EOPS_ObjectName_XX)
                .setHandler(t1 =>
                {
                    //var t2 = t1.tryLink<EM_Area>(t => t1.EOPS_ObjectId == t.EMA_AreaId);
                    //return (t2.PrimaryKey == null).istrue("", "[配置圖]" + t2.EMA_AreaName);
                    return "";
                });

            base.onSchemaLoaded();
        }

    }
}
