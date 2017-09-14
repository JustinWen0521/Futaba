using System;
using System.Data;
using System.Configuration;

namespace ftd.data
{
    public class AppUserEventName
    {
        #region [EO]
        /// <summary>
        /// 會員登入
        /// </summary>
        public const string EO_UserLogin = "EO_UserLogin";

        /// <summary>
        /// 會員網頁SessionEnd
        /// </summary>
        public const string EO_LoginUserSessionEnd = "EO_LoginUserSessionEnd";
      
        #endregion
   
        #region [EP]

        /// <summary>
        /// 電子公佈欄
        /// </summary>
        public const string EP_PublicMessage = "EP_PublicMessage";

        /// <summary>
        /// 行事曆
        /// </summary>
        public const string EP_Calendar = "EP_Calendar";

        /// <summary>
        /// 我的會議
        /// </summary>
        public const string EP_Meeting = "EP_Meeting";        

        /// <summary>
        /// 討論區(需指定討論區)
        /// </summary>
        public const string EP_Forum = "EP_Forum";

      
        #endregion 

    }    
}
