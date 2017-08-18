using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_MenuFun
    /// </summary>
    public class EoMenuFunQryModel : AppQryModel
    {
        public EoMenuFunQryModel()
        {
        }

        public string Q_MenuFunId { get; set; }
        public string Q_ItemNo { get; set; }
        public string Q_FunctionCode { get; set; }
        public string Q_FunctionName { get; set; }
        public int? Q_SeqNo { get; set; }
        public string Q_ToolbarLevel { get; set; }

    }
}
