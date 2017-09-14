using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ftd.dataaccess;
using System.Data.Common;
using System.Data;
using Microsoft.VisualBasic;
using ftd.data;


using ftd.web;
using ftd.nsql;

namespace ftd.service
{
    public class AdmService : FdmService
    {

        protected override NsQueryContext createDefaultQueryContext()
        {
            var ctx = base.createDefaultQueryContext();

            //ctx.Params["NQC_IS_ADMIN"] = false.ToString();

            if (AppUserSession.User != null)
            {
                try
                {
                    ctx.UserId = AppUserSession.User.UserId;
                    //var is_admin = AppUserSession.User.containsPermission(AppPermissionName.APN_APP_SystemAdmin);
                    //ctx.Params["NQC_IS_ADMIN"] = is_admin.ToString();
                }
                catch { }
            }            

            return ctx;
        }

        protected override void onSchemaLoad()
        {
            loadSchemaFromClass(typeof(AppDataName));

            base.onSchemaLoad();
        }
    }
}
