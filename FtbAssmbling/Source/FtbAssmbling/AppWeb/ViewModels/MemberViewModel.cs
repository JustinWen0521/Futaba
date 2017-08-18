using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace ftd.mvc.ViewModels
{
    public class MemberViewModel
    {
        /// <summary>
        /// 加這個，當MemberViewModel new出來時，存取PhotoFileNames才不會發生NULL例外
        /// </summary>
        private List<string> _photoFileNames = new List<string>();
        /// <summary>
        /// 多張大頭照的檔案名稱
        /// </summary>
        public List<string> PhotoFileNames 
        { 
            get { return this._photoFileNames; } 
            set { this._photoFileNames = value; } 
        }
    }
}