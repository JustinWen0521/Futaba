using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.query.model
{
    /// <summary>
    /// ZZ_Order
    /// </summary>
    public class ZzOrderQryModel : AppQryModel
    {
        public ZzOrderQryModel()
        {
        }

        public string Q_OrderId { get; set; }
        public string Q_OrderNo { get; set; }
        public DateTime? Q_DateFrom { get; set; }
        public DateTime? Q_DateTo { get; set; }
        public string Q_Desc { get; set; }
        public string Q_IsEnable { get; set; }
        public string Q_IsEnableName_XX { get; set; }
        public int? Q_OrderAmount_XXFrom { get; set; }
        public int? Q_OrderAmount_XXTo { get; set; }

        public string Q_Item { get; set; }
        public int? Q_Qty { get; set; }
        public int? Q_UnitPrice { get; set; }
        public int? Q_Amount_XX { get; set; }

    }
}
