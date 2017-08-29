using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ftd.mvc.Areas.AL.Models
{
    public class PrdClass
    {
        public string name { set; get; }
        public String[,] detail{set;get;}


        public PrdClass(string strName, String[,] arrDetail)
        {
            this.name = strName;
            this.detail = arrDetail;
        }

    }
}