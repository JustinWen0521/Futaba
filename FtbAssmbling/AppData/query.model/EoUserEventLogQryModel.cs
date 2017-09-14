using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_UserEventLog
    /// </summary>
    public class EoUserEventLogQryModel : AppQryModel
    {
        public EoUserEventLogQryModel()
        {
        }

        public string Q_UserEventLogId { get; set; }
        public DateTime? Q_EventDateFrom { get; set; }
        public DateTime? Q_EventDateTo { get; set; }
        public string Q_UserEventId { get; set; }
        public string Q_UserEventCode_XX { get; set; }
        public string Q_UserEventName_XX { get; set; }
        public string Q_UserId { get; set; }
        public string Q_UserName_XX { get; set; }
        public string Q_SourceIP { get; set; }
        public string Q_ObjectId { get; set; }
        public string Q_ObjectName_XX { get; set; }

    }
}
