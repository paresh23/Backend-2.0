using System;
using System.Collections.Generic;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class Consumer
    {
        public Consumer()
        {
            Emicards = new HashSet<Emicard>();
            PurchaseRecords = new HashSet<PurchaseRecord>();
        }

        public int Cid { get; set; }
        public string UserId { get; set; }
        public string CName { get; set; }
        public DateTime Dob { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string CAddress { get; set; }
        public string CPassword { get; set; }
        public string CardType { get; set; }
        public string BankName { get; set; }
        public string AccNo { get; set; }
        public string IfscCode { get; set; }
        public bool? IsVerfied { get; set; }

        public virtual ICollection<Emicard> Emicards { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
