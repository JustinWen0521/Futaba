using System;
using System.Collections.Generic;
using System.Text;
using ftd.data;
using ftd.dataaccess;
using ftd.nsql;

namespace ftd.service
{
    public class AppWebFolderService : FtdWebFolderService
    {
        protected override FtdDbFile getDatabaseFile(string fileId)
        {
            var qry = new NsDmQuery();
            if (fileId.StartsWith("WTWF_"))
            {
                var t1 = qry.from<WT_WebFile>();
                qry.selectAll(t1.WTWF_StorageFullName_XX);
                qry.Where = t1.WTWF_WebFileId == fileId.toConstReq1();
                var row = qry.queryData<WT_WebFileDataTable>().FirstRow;
                FtdDbFile dfile = new FtdDbFile();
                dfile.FileId = fileId;
                dfile.FileFullName = row.WTWF_StorageFullName_XX;
                return dfile;
            }
            return base.getDatabaseFile(fileId);
        }
    }
}
