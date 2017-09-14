using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ftd.nsql;
using ftd.service;
using ftd.data.nstable;
namespace ftd.data
{
    /// <summary>
    /// {T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}
    /// </summary>
    public interface EO_MenuPermSet : INsTable
    {
        /// <summary>
        /// [DIRECT]*授權功能ID{ MenuPermSetId}：【PK&lt;EOMPS&gt;】
        /// </summary> 
        NsColumn EOMPS_MenuPermSetId { get; }
        /// <summary>
        /// [DIRECT]*功能表ID{MenuId}：【FK&lt;EOM&gt;】&lt;br/&gt;
        /// </summary> 
        NsColumn EOMPS_MenuId_XX { get; }
        /// <summary>
        /// [DIRECT]*功能項目No{MenuItemNo:50}：【Report.1】
        /// </summary> 
        NsColumn EOMPS_MenuItemNo { get; }
        /// <summary>
        /// #功能項目No{MenuItemNoName_XX}：【個人紀錄報表】
        /// </summary> 
        NsColumn EOMPS_MenuItemNoName_XX { get; }
        /// <summary>
        /// [DIRECT]*授權對象ID{MenuPermId}：【FK&lt;EOMP&gt;】
        /// </summary> 
        NsColumn EOMPS_MenuPermId { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_MenuPermSetNsTable : NsTable, EO_MenuPermSet
        {
            public NsColumn EOMPS_MenuPermSetId
            {
                  get { return this["EOMPS_MenuPermSetId"]; }
            }
            public NsColumn EOMPS_MenuId_XX
            {
                  get { return this["EOMPS_MenuId_XX"]; }
            }
            public NsColumn EOMPS_MenuItemNo
            {
                  get { return this["EOMPS_MenuItemNo"]; }
            }
            public NsColumn EOMPS_MenuItemNoName_XX
            {
                  get { return this["EOMPS_MenuItemNoName_XX"]; }
            }
            public NsColumn EOMPS_MenuPermId
            {
                  get { return this["EOMPS_MenuPermId"]; }
            }
        }
    }
}
