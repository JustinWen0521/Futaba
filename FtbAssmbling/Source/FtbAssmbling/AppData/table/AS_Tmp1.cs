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
    /// &lt;AST&gt;測試 {TMP1}
    /// </summary>
    public interface AS_Tmp1 : INsTable
    {
        /// <summary>
        /// [DIRECT]*TITM {DTN_NID}：【PK&lt;AST&gt;】
        /// </summary> 
        NsColumn AST_TITM { get; }
        /// <summary>
        /// [DIRECT]* {DTN_NVARCHAR10}：【100】
        /// </summary> 
        NsColumn AST_TQTY { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class AS_Tmp1NsTable : NsTable, AS_Tmp1
        {
            public NsColumn AST_TITM
            {
                  get { return this["AST_TITM"]; }
            }
            public NsColumn AST_TQTY
            {
                  get { return this["AST_TQTY"]; }
            }
        }
    }
}
