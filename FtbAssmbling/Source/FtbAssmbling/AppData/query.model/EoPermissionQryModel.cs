using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_Permission
    /// </summary>
    public class EoPermissionQryModel : AppQryModel
    {
        public EoPermissionQryModel()
        {
        }

        public string Q_PermissionId { get; set; }
        public string Q_PermissionCode { get; set; }
        public string Q_PermissionName { get; set; }
        public string Q_Description { get; set; }
        public string Q_IsEveryOneAllow { get; set; }
        public string Q_IsEveryOneAllowName_XX { get; set; }
        public string Q_IsObjectNeed { get; set; }
        public string Q_IsObjectNeedName_XX { get; set; }

    }
}
