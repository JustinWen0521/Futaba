using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ftd.data;
using ftd.dataaccess;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ftd.data.model.tag;
using ftd.nsql;

namespace ftd.service
{
    public class AppMailService : FtdMailService
    {
        protected override DataTable getMailQueues()
        {
            var qry = new NsDmQuery();
            qry.from<WT_MailQueue>();
            var dt = qry.queryData();
            return dt;
        }

        protected override FtdEmail deserializeMail(DataRow row)
        {
            var row1 = (WT_MailQueueRow)row;
            var ms = new MemoryStream(Convert.FromBase64String(row1.WTMQ_Content));
            using (ms)
            {
                var bf = new BinaryFormatter();
                var mail = (FtdEmail)bf.Deserialize(ms);
                return mail;
            }
        }

        protected override void serializeMail(DataRow row, FtdEmail mail)
        {
            var row1 = (WT_MailQueueRow)row;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, mail);
                row1.WTMQ_Content = Convert.ToBase64String(ms.ToArray());
            }
        }

        protected override void queueEmail(FtdEmail ftdEmail)
        {
            //推入Queue中
            var dt = new WT_MailQueueDataTable();
            var row = dt.newTypedRow();
            row.ns_AssignNewId();
            serializeMail(row, ftdEmail);
            dt.addTypedRow(row);           
            dt.ns_update();
            TaskThread.taskActive();
        }
    }
}
