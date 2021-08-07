using System;
using System.Collections.Generic;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class Product
    {
        public Product()
        {
            PurchaseRecords = new HashSet<PurchaseRecord>();
        }

        public int Pid { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProdDetails { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
