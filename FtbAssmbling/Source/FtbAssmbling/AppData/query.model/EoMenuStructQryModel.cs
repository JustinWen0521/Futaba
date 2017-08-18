using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_MenuStruct
    /// </summary>
    public class EoMenuStructQryModel : AppQryModel
    {
        public EoMenuStructQryModel()
        {
        }

        public string Q_NodeId { get; set; }
        public int? Q_BrotherCount_XX { get; set; }
        public int? Q_ChildCount_XX { get; set; }
        public string Q_ClickMode { get; set; }
        public string Q_Code { get; set; }
        public string Q_CustAttr1 { get; set; }
        public string Q_CustAttr2 { get; set; }
        public string Q_CustAttr3 { get; set; }
        public int? Q_LevelNo_XX { get; set; }
        public string Q_MatchSiteId_XX { get; set; }
        public string Q_Name { get; set; }
        public string Q_NodeType_XX { get; set; }
        public string Q_Note { get; set; }
        public string Q_ParentId { get; set; }
        public string Q_RootId_XX { get; set; }
        public int? Q_SortNo { get; set; }
        public int? Q_TreeLeftNo_XX { get; set; }
        public int? Q_TreeRightNo_XX { get; set; }
        public string Q_Url { get; set; }
        public string Q_UrlTarget { get; set; }
        public string Q_WinClass { get; set; }
        public string Q_WinParam { get; set; }
        public string Q_Viewable { get; set; }

    }
}
