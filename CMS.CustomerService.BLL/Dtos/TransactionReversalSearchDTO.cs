using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class TransactionReversalSearchDTO
    {
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        [DataMember]
        public int? TransactionTypeId { get; set; }
        [DataMember]
        public string VATInvoiceNumber { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public int? TokenTypeId { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public int? StationId { get; set; }
        [DataMember]
        public int? ProductId { get; set; }
        [DataMember]
        public int? ReceiptId { get; set; }
        [DataMember]
        public string AuthorizationCode { get; set; }
        [DataMember]
        public bool? IsPremiumService { get; set; }
    }
}
