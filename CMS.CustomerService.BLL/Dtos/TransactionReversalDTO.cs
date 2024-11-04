using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class TransactionReversalDTO
    {
        [DataMember]
        public DateTime? TransactionDate { get; set; }
        [DataMember]
        public int? TransactionId { get; set; }
        [DataMember]
        public int? TransactionDetailId { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public string VatInvoiceNumber { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public string StationName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int? ReceiptId { get; set; }
        [DataMember]
        public string AuthorizationCode { get; set; }
        [DataMember]
        public int? ReversedTransactionId { get; set; }
        [DataMember]
        public int? ReversedTransactionDetailId { get; set; }
        [DataMember]
        public bool IsPayment { get; set; }
        [DataMember]
        public decimal? TransactionAmount { get; set; }
        [DataMember]
        public decimal? VATAmount { get; set; }
        [DataMember]
        public bool? IsPremiumService { get; set; }
    }
}
