using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// WT_ScheduleTask
    /// </summary>
    public class WtScheduleTaskQryModel : AppQryModel
    {
        public WtScheduleTaskQryModel()
        {
        }

        public string Q_ScheduleTaskId { get; set; }
        public string Q_TaskName { get; set; }
        public string Q_Description { get; set; }
        public string Q_IsEnable { get; set; }
        public string Q_IsEnableName_XX { get; set; }
        public DateTime? Q_ExecuteBeginDate { get; set; }
        public DateTime? Q_ExecuteEndDate { get; set; }
        public string Q_ExecuteState { get; set; }
        public string Q_ExecuteStateName_XX { get; set; }
        public string Q_ExecuteException { get; set; }
        public decimal? Q_ExecuteSeconds_XX { get; set; }
        public string Q_ObjectTypeName { get; set; }
        public string Q_Parameters { get; set; }

    }
}
