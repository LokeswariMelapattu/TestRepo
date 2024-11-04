using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchVoucherTransactionDTO : BaseDTO
    {
        [DataMember]
        public int? ReceiptID { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public decimal? TransactionAmount { get; set; }
        [DataMember]
        public decimal? TotalAmount { get; set; }
        [DataMember]
        public Nullable<int> IsOfflineTransaction { get; set; }
        [DataMember]
        public Nullable<int> IsDisableBeneficiary { get; set; }
        [DataMember]
        public string ENPaymentMethod { get; set; }
        [DataMember]
        public string CustomerNo { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string ARNumber { get; set; }
        [DataMember]
        public string BeneficiaryNo { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }      
        [DataMember]
        public string StationName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public decimal? PaidAmount { get; set; }
        [DataMember]
        public string TransactionDate { get; set; }
        [DataMember]
        public decimal? ProductQuantity { get; set; }
        [DataMember]
        public decimal? ProductPrice { get; set; }
        [DataMember]
        public string VATInvoiceNo { get; set; }
        [DataMember]
        public string ExternalVoucherNo { get; set; }
        [DataMember]
        public string VoucherSerialNo { get; set; }
        [DataMember]
        public string FinancialAccountName { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public int RowNum { get; set; }

    }
}
