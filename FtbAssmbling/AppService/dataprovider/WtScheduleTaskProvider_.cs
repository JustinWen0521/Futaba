using System;
using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// &lt;WTST&gt;排程工作{ScheduleTask}
    /// </summary>
    public partial class WtScheduleTaskProvider
    {
        protected override void onSchemaLoaded()
        {
            //addTypedSqlHandler()
            //    .setColumns(AppDataName.WTST_IsEnableName_XX)
            //    .setHandler(
            //        t => t.WTST_IsEnable.decode("A", "啟用", "B", "停止", t.WTST_IsEnable)
            //    );

            addTypedSqlHandler()
                .setColumns(AppDataName.WTST_ExecuteStateName_XX)
                .setHandler(
                    t => t.WTST_ExecuteState.decode("A", "成功", "B", "失敗", t.WTST_ExecuteState)
                );

            addTypedCalcHandler()
                .setColumns(AppDataName.WTST_ExecuteSeconds_XX)
                .setReferences(AppDataName.WTST_ExecuteBeginDate, AppDataName.WTST_ExecuteEndDate)
                .setHandler(dt =>{
                    foreach (var row in dt)
                    {
                        if (row.WTST_ExecuteBeginDate != null && row.WTST_ExecuteEndDate != null)                        
                            row.WTST_ExecuteSeconds_XX = Math.Round(Convert.ToDecimal(((TimeSpan)(row.WTST_ExecuteEndDate - row.WTST_ExecuteBeginDate)).TotalSeconds), 1);                        
                        else
                            row.WTST_ExecuteSeconds_XX = 0;
                    }
                });            

            base.onSchemaLoaded();
        }
    }
}
