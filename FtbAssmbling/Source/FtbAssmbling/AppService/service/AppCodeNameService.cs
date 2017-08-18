using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ftd.service;
using System.Collections;
using System.Collections.Specialized;
using ftd.data;
using ftd.nsql;

namespace ftd.service
{
    public class AppCodeNameService : FtdCodeNameService
    {
        //protected override void dynamicLoadCodeType(string codeTypeName, IDictionary codeNames)
        //{
        //    if (codeTypeName == AppCodeTypeName.CTN_WMCT_CalcTypeId)
        //    {
        //        var dt = NsDmHelper.WM_CalcType.query((q, t1) => { });
        //        foreach (var row in dt)
        //        {
        //            codeNames.Add(row.WMCT_CalcTypeId, row.WMCT_TypeName);
        //        }
        //        return;
        //    }

        //    base.dynamicLoadCodeType(codeTypeName, codeNames);
        //}
    }
}
