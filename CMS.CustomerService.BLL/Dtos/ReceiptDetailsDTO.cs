using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class ReceiptDetailsDTO
    {
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string VatCode { get; set; }
        public Nullable<decimal> VatRate { get; set; }
        public Nullable<decimal> VatAmount { get; set; }
        public string VatInvoiceNumber { get; set; }
    }
}
