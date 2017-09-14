using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.service
{
    /// <summary>
    /// AC 市議員備詢管理系統
    /// </summary>
    public class AcDataService : FtdServiceBase
    {
        public static readonly AcDataService Instance;

        static AcDataService()
        {
            FtdCreatorService.Instance.createObject<AcDataService>(ref Instance);
        }
    }
}
