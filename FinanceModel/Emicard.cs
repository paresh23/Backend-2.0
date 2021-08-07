using System;
using System.Collections.Generic;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class Emicard
    {
        public Emicard()
        {
            PurchaseRecords = new HashSet<PurchaseRecord>();
        }

        public int Eid { get; set; }
        public string CardNo { get; set; }
        public int? UserId { get; set; }
        public DateTime? ValidityPeriod { get; set; }
        public decimal AccBalance { get; set; }
        public string TotalCredit { get; set; }

        public virtual Consumer User { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
