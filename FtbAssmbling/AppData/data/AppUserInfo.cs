using System;
using System.Data;
using System.Configuration;
using ftd.dataaccess;
using ftd.data;
using System.Diagnostics;
using System.Collections.Generic;
using ftd.service;
using ftd.nsql;

namespace ftd.data
{
    /// <summary>
    /// 使用者資訊
    /// 提供Win Client傳遞密碼變更
    /// </summary>
    [Serializable]
    public class AppUserInfo
    {

        public AppUserInfo()
        {
        }

        public string UserId
        {
            get;
            set;
        }

        public string LoginAccount
        {
            get;
            set;
        }

        public string OldPassword
        {
            get;
            set;
        }

        public string NewPassword
        {
            get;
            set;
        }

    }
}
