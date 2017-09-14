using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// AL_AssmblingLog
    /// </summary>
    public class AlAssmblingLogQryModel : AppQryModel
    {
        public AlAssmblingLogQryModel()
        {
        }

        public string Q_AssmblingLogId { get; set; }
        public string Q_MCID { get; set; }
        public int? Q_SEQRow { get; set; }
        public int? Q_SEQCol { get; set; }
        public DateTime? Q_EffectDate { get; set; }
        public DateTime? Q_InvalidDate { get; set; }
        public string Q_CreatorId { get; set; }
        public string Q_CreatorName_XX { get; set; }
        public DateTime? Q_CreateDate { get; set; }
        public string Q_UpdaterId { get; set; }
        public string Q_UpdaterName_XX { get; set; }
        public DateTime? Q_UpdateDate { get; set; }

    }
}
