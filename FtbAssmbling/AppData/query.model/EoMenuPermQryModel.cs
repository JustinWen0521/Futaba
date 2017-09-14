using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_MenuPerm
    /// </summary>
    public class EoMenuPermQryModel : AppQryModel
    {
        public EoMenuPermQryModel()
        {
        }

        public string Q_MenuPermId { get; set; }
        public string Q_MenuId { get; set; }
        public string Q_TargetKind { get; set; }
        public string Q_TargetKindName_XX { get; set; }
        public string Q_TargetId { get; set; }
        public string Q_TargetCode_XX { get; set; }
        public string Q_TargetName_XX { get; set; }
        public string Q_ViewKind { get; set; }
        public string Q_ViewKindName_XX { get; set; }

    }
}
