using System;
using System.Collections.Generic;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class PurchaseRecord
    {
        public int Prid { get; set; }
        public string OrderId { get; set; }
        public int? CardNo { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public DateTime Dop { get; set; }
        public decimal? ProductBalance { get; set; }
        public int? TotalMonthsSelected { get; set; }
        public int? LatestEmimonth { get; set; }

        public virtual Emicard CardNoNavigation { get; set; }
        public virtual Product Product { get; set; }
        public virtual Consumer User { get; set; }
    }
}
