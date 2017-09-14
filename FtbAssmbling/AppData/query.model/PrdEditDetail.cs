using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace ftd.mvc.Areas.AL.Models
namespace ftd.query.model
{
    public class PrdEditDetail
    {
        public string index { set; get; }
        public string dateHr { set; get; }
        public string item { set; get; }
        public string qty { set; get; }

        public PrdEditDetail(){
        
        }

        public PrdEditDetail(string Index, string DateHr, string Item, string Qty)
        { 
            this.index = Index;
            this.dateHr = DateHr;
            this.item = Item;
            this.qty = Qty;
        }

      
    }
}