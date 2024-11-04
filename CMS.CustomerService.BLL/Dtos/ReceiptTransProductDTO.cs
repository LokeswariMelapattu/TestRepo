using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class ReceiptTransProductDTO
    {
        [DataMember]
        public int? ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ARProductName { get; set; }
        [DataMember]
        public decimal? UnitPrice { get; set; }
        [DataMember]
        public decimal? TransactionAmount { get; set; }
        [DataMember]
        public string VatInvoiceNumber { get; set; }
        [DataMember]
        public decimal? VatAmount { get; set; }
        [DataMember]
        public decimal? VatPercentage { get; set; }
        [DataMember]
        public bool IsPrintable { get; set; }
        [DataMember]
        public string VATCode { get; set; }
        [DataMember]
        public decimal? Adjustment { get; set; }
        [DataMember]
        public decimal? ChargedAmount { get; set; }
    }
}
