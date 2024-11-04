using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "TransactionSearchInvDTO1")]
    public class TransactionSearchInvDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public int? BeneficiaryID { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        [DataMember]
        public int? TokenTypeID { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public int? StationID { get; set; }
        [DataMember]
        public int? ProductID { get; set; }
        [DataMember]
        public string Serial { get; set; }
        [DataMember]
        public int? GroupID { get; set; }
        [DataMember]
        public DateTime? TransactionDate { get; set; }
        [DataMember]
        public decimal? TransactionAmount { get; set; }
        [DataMember]
        public decimal? Adjustment { get; set; }
        [DataMember]
        public decimal? PaidAmount { get; set; }
        [DataMember]
        public string StationNameEn { get; set; }
        [DataMember]
        public string ProductNameEn { get; set; }
        [DataMember]
        public string StationNameAr { get; set; }
        [DataMember]
        public string ProductNameAr { get; set; }
        [DataMember]
        public int InvoiceID { get; set; }
        [DataMember]
        public string OnlineDPRuleName { get; set; }
        [DataMember]
        public int? OnlineDPRuleId { get; set; }
        [DataMember]
        public string EOMDPRuleName { get; set; }
        [DataMember]
        public int? EOMDPRuleId { get; set; }

        [DataMember]
        public string VAT_Code { get; set; }

        [DataMember]
        public Nullable<decimal> VAT_RATE { get; set; }

        [DataMember]
        public Nullable<decimal> VAT_Amount { get; set; }

        [DataMember]
        public string VAT_INV_NUM { get; set; }

        [DataMember]
        public string ServiceOrProductName { get; set; }
        [DataMember]
        public List<ReceiptTransProductDTO> ProductDtos { get; set; }

       

    }
}
