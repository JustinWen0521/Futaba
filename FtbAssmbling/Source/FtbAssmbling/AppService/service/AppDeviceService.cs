using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.nsql;
using ftd.data;
using System.Runtime.CompilerServices;

namespace ftd.service
{
    public class AppDeviceService : FtdServiceBase
    {
        private static object _lockObj = new object();

        #region [Static]

        /// <summary>
        /// 
        /// </summary>
        public static readonly AppDeviceService Instance;

        /// <summary>
        /// 
        /// </summary>
        static AppDeviceService()
        {
            FtdCreatorService.Instance.createObject<AppDeviceService>(ref Instance);
        }

        #endregion

        public string getDeviceCode(string devName, string uid)
        {
            //確保一次只有一個client進行註冊
            lock (_lockObj)
            {
                // uiD 必需有值
                if (string.IsNullOrEmpty(uid))
                    throw new Exception("必需指定裝置唯一識別碼");

                //取得所有裝置
                var dt = NsDmHelper.SY_Device
                    .query();

                //找出指定的裝置
                string uid2 = uid.Replace(":", "").ToUpper();
                var dev = dt.Where(x => 
                        x.SYD_UID.Replace(":", "").ToUpper() == uid2
                    ).FirstOrDefault<SY_DeviceRow>();
                if (dev != null)
                {
                    //記錄登入時間
                    dev.SYD_LastCheckinTime = DateTime.Now;
                    dev.ns_update();
                    return dev.SYD_Code;
                }

                //目前最大的編號
                string currentMaxCode = dt.Max(x => x.SYD_Code);
                if (string.IsNullOrEmpty(currentMaxCode))
                    currentMaxCode = "000";

                //日期
                DateTime today = DateTime.Today;
                string prefix = (today.Year - 1911).ToString() + today.ToString("MMdd");

                //新增裝置
                var newDev = dt.newTypedRow();
                newDev.ns_AssignNewId();
                newDev.SYD_Code = (int.Parse(currentMaxCode) + 1).ToString("000");
                newDev.SYD_Name = devName;
                newDev.SYD_UID = uid2;
                newDev.SYD_LastCheckinTime = DateTime.Now;
                newDev.SYD_TransactionNoPrefix = prefix;
                newDev.SYD_TransactionNoSeq = 0;
                dt.addTypedRow(newDev);
                dt.ns_update();

                return newDev.SYD_Code;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string getNewTransactionNo(string devCode)
        {
            var dev = NsDmHelper.SY_Device
                .selectAll()
                .where(t => t.SYD_Code == devCode.toConstReq1())
                .queryFirst();

            if (dev == null)
                throw new Exception("裝置尚未註冊");
            
            DateTime today = DateTime.Today;
            string prefix = (today.Year - 1911).ToString() + today.ToString("MMdd");

            //日期不同 --> 重新編號
            if (dev.SYD_TransactionNoPrefix != prefix)
            {
                dev.SYD_TransactionNoPrefix = prefix;
                dev.SYD_TransactionNoSeq = 0;
            }

            //序號加1
            dev.SYD_TransactionNoSeq++;

            //更新資料庫
            dev.ns_update();

            //產生新的交易序號：民國年月日7碼+裝置代號3碼+流水號4碼
            int seq = dev.SYD_TransactionNoSeq.Value;
            string newNo = prefix + dev.SYD_Code + seq.ToString("0000");
            return newNo;
        }
    }
}
