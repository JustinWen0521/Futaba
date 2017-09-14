using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_UserEvent
    /// </summary>
    public class EoUserEventQryModel : AppQryModel
    {
        public EoUserEventQryModel()
        {
        }

        public string Q_UserEventId { get; set; }
        public string Q_Description { get; set; }
        public string Q_EventCode { get; set; }
        public string Q_KindName { get; set; }
        public int? Q_ListOrder { get; set; }

    }
}
