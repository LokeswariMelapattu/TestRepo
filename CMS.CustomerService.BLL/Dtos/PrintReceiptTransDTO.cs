using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class PrintReceiptTransDTO
    {
        [DataMember]
        public Nullable<int> CustomerId { get; set; }
        [DataMember]
        public Nullable<int> PaymentTypeId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransactionDate { get; set; }
        [DataMember]
        public Nullable<decimal> Amount { get; set; }
        [DataMember]
        public string ServiceOrProdName { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string BeneficiaryNo { get; set; }
        [DataMember]
        public decimal? VatPercentage { get; set; }
        [DataMember]
        public string VatInvoiceNumber { get; set; }
        [DataMember]
        public decimal? VatAmount { get; set; }
        [DataMember]
        public string VatCode { get; set; }
        [DataMember]
        public string TokenTypeName { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public Nullable<short> IsPrintable { get; set; }
        [DataMember]
        public List<ReceiptTransProductDTO> ProductDtos { get; set; }
        [DataMember]
        public Nullable<int> TransactionId { get; set; }
        [DataMember]
        public bool IsPremiumService { get; set; }
        [DataMember]
        public string ExemptionType { get; set; }
        [DataMember]
        public string IsSplit { get; set; }
    }
}
