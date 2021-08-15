using System;
using System.Collections.Generic;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public string Username { get; set; }
        public byte[] DocImage { get; set; }
    }
}
