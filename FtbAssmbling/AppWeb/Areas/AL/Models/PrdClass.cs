using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ftd.query.model;

namespace ftd.mvc.Areas.AL.Models
{
    public class PrdClass
    {
        public string name { set; get; }
        //public String[,] detail{set;get;}
        public List<PrdEditDetail> detail { set; get; }


        public PrdClass(string strName, List<PrdEditDetail> arrDetail)
        {
            this.name = strName;
            this.detail = arrDetail;
        }

    }

}