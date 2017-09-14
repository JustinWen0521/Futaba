using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// EO_FunPermSet
    /// </summary>
    public class EoFunPermSetQryModel : AppQryModel
    {
        public EoFunPermSetQryModel()
        {
        }

        public string Q_FunPermSetId { get; set; }
        public string Q_MenuPermSetId { get; set; }
        public string Q_MenuId_XX { get; set; }
        public string Q_MenuItemNo_XX { get; set; }
        public string Q_MenuItemNoName_XX { get; set; }
        public string Q_MenuFunId { get; set; }
        public string Q_FunctionCode_XX { get; set; }
        public string Q_FunctionName_XX { get; set; }
        public string Q_FunctionSeqNo_XX { get; set; }

    }
}
