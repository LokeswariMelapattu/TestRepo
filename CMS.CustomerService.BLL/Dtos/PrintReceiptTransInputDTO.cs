using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class PrintReceiptTransInputDTO
    {
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        [DataMember]
        public int? TransactionTypeId { get; set; }
        [DataMember]
        public string BeneficiaryNo { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public int? TokenTypeId { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public int? PageNo { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
        [DataMember]
        public string VatInvoiceNumber { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public bool? IsPremiumService { get; set; }
        [DataMember]
        public int? ExemptionTypeId { get; set; }
    }
}
