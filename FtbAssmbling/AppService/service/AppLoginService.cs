using System;
using System.Globalization;
using System.Web;
using System.Web.Security;
using ftd.data;
using ftd.nsql;
using ftd.web;

namespace ftd.service
{
    /// <summary>
    /// 登入程序
    /// </summary>
    public class AppLoginService
    {
        /// <summary>
        /// 登入訊息回應格式
        /// </summary>
        /// <param name="messageType">A:帳號問題 P:密碼問題 M:訊息</param>
        /// <param name="messageContent">訊息內容</param>
        public delegate void WhenValidateFailure(string messageType, string messageContent);

        public static readonly AppLoginService Instance;

        static AppLoginService()
        {
            Instance = FtdCreatorService.Instance.createObject<AppLoginService>();
        }

        /// <summary>
        /// 登入資料驗證
        /// </summary>
        public virtual bool accountValidate(string account, string password, ref string empId, out string errorMsg)
        {
            errorMsg = "";

            var qry = new NsDmQuery();
            var t1 = qry.from<EO_LoginAccount>();
            qry.Where = t1.EOLA_LoginAccount == account.toConstReq1();
            var rowa = ((EO_LoginAccountDataTable)qry.queryData()).FirstRow;
            if (rowa == null)
            {
                //資安考量：勿明確說明哪一種錯誤
                errorMsg = "帳號或密碼錯誤";
                return false;
            }

            //停用
            if (rowa.EOLA_IsEnable == "F")
            {
                errorMsg = "帳號已停用";
                return false;
            }

            //登入次數太多招致停權五分鐘
            if (rowa.EOLA_FailureDate.HasValue)
            {
                if (rowa.EOLA_FailureDate.Value > DateTime.Now)
                {
                    errorMsg = string.Format("登入失敗超過三次停權五分鐘，請於「{0}」後再試。", rowa.EOLA_FailureDate.Value.ToString("HH:mm", CultureInfo.InvariantCulture));
                    return false;
                }
                else
                {
                    //停權已超過5分鐘的話，解除之
                    rowa.EOLA_FailureDate = null;
                    rowa.EOLA_FailureCount = 0;
                    rowa.ns_update();
                }
            }

            //密碼驗證
            if (!rowa.EOLA_LoginPassword.equalIgnoreCase(password.Trim()))
            {
                rowa.EOLA_FailureCount = rowa.EOLA_FailureCount + 1;
                if (rowa.EOLA_FailureCount >= 3)
                {
                    rowa.EOLA_FailureDate = DateTime.Now.AddMinutes(5);
                }
                rowa.ns_update();

                //資安考量：勿明確說明哪一種錯誤
                errorMsg = "帳號或密碼錯誤";
                return false;
            }

            {
                rowa.EOLA_LastLoginDate = DateTime.Now;
                rowa["EOLA_FailureDate"] = DBNull.Value;
                rowa.EOLA_FailureCount = 0;
                rowa.ns_update();
            }

            //登入者            
            empId = rowa.EOLA_LoginAccountId;
            return true;
        }

        /// <summary>
        /// 登出結束資料
        /// </summary>
        public virtual void logout()
        {
            //票証取消
            FormsAuthentication.SignOut();

            //結束Session
            HttpContext.Current.Session.Abandon();
        }

        /// <summary>
        /// 登入指定帳號，並移轉至指定網址(如有指定)
        /// </summary>        
        public virtual void login(string userId, string defaultUrl)
        {
            //結束Session
            HttpContext.Current.Session.Abandon();

            //票証設定    
            FormsAuthentication.SetAuthCookie(userId, false);

            //登入事件
            EoUserEventHelper.logEvent(AppUserEventName.EO_UserLogin, userId, "AppWeb");
          
            //重導至目的頁
            //if (defaultUrl.isNullOrEmpty())
            //{
            //    defaultUrl = FormsAuthentication.DefaultUrl;
            //}
            //HttpContext.Current.Response.Redirect(defaultUrl, false);
        }
    }
}
