﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.nsql.provider;
namespace ftd.dataaccess
{
    /// <summary>
    /// {T}組立機臺主檔Log {AL_AssmblingLog}
    /// </summary>
    public partial class AlAssmblingLogProvider : NsTpDmTypedTableProvider<AL_AssmblingLog,AL_AssmblingLogDataTable>
    {
        protected override void onSchemaLoaded()
        {
            //addDataMap(AppDataName.AS_Tmp1, "TMP1");
            //addDataMap(AppDataName.AST_TITM, "TITM");
            //addDataMap(AppDataName.AST_TQTY, "TQTY");

        }
    }
}
