using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using ftd.data;
using ftd.nsql;
using ftd.query.model;
using ftd.web;

namespace ftd.service
{
    public class AppFileService
    {
        public static readonly AppFileService Instance;

        static AppFileService()
        {
            Instance = FtdCreatorService.Instance.createObject<AppFileService>();
        }

        public virtual byte[] processReport<T>(T para) where T : AppQryModel
        {
            AppQryModel qm = para as AppQryModel;
            if (qm == null || qm.ReportId.isNullOrEmpty())
                throw new Exception("無效的參數");

            return null;
        }


    }
}
