using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_PermissionSetting
    /// </summary>
    public class EoPermissionSettingQryModel : AppQryModel
    {
        public EoPermissionSettingQryModel()
        {
        }

        public string Q_PermissionSettingId { get; set; }
        public string Q_PermissionUserId { get; set; }
        public string Q_PermissionUserName_XX { get; set; }
        public string Q_PermissionId { get; set; }
        public string Q_PermissionCode_XX { get; set; }
        public string Q_PermissionName_XX { get; set; }
        public string Q_ObjectId { get; set; }
        public string Q_ObjectName_XX { get; set; }
        public string Q_IsObjectNeed_XX { get; set; }
        public string Q_IsEveryOneAllow_XX { get; set; }

    }
}
