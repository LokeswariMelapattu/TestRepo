using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerUnBilledDTO : BaseDTO
    {
        [DataMember()]
        public Nullable<Int32> CustomerId { get; set; }
        [DataMember()]
        public Nullable<Int32> BeneficiaryId { get; set; }
        [DataMember()]
        public String BeneficiaryName { get; set; }
        [DataMember()]
        public Nullable<Int32> TransactionId { get; set; }
        [DataMember()]
        public Nullable<Int32> TokenTypeId { get; set; }
        [DataMember()]
        public String TokenType { get; set; }
        [DataMember()]
        public String TokenTypeAr { get; set; }
        [DataMember()]
        public Nullable<Int32> StationId { get; set; }
        [DataMember()]
        public String StationName { get; set; }
        [DataMember()]
        public String StationNameAr { get; set; }
        [DataMember()]
        public Nullable<Int32> ProductId { get; set; }
        [DataMember()]
        public String ProductName { get; set; }
        [DataMember()]
        public String ProductNameAr { get; set; }
        [DataMember()]
        public String Serial { get; set; }
        [DataMember()]
        public Nullable<Int32> GroupId { get; set; }
        [DataMember()]
        public Nullable<DateTime> TransactionDateTime { get; set; }
        [DataMember()]
        public Nullable<Decimal> TransactionAmount { get; set; }
        [DataMember()]
        public Nullable<Decimal> Adjustment { get; set; }
        [DataMember()]
        public Nullable<Decimal> PaidAmount { get; set; }
        [DataMember()]
        public Nullable<DateTime> LastBilledDate { get; set; }
        [DataMember]
        public string OnlineDPRuleName { get; set; }
        [DataMember]
        public int? OnlineDPRuleId { get; set; }
        [DataMember]
        public string EOMDPRuleName { get; set; }
        [DataMember]
        public int? EOMDPRuleId { get; set; }
        [DataMember]
        public string VAT_INV_NUM { get; set; }
        [DataMember]
        public string VAT_Code { get; set; }
        [DataMember]
        public Nullable<double> VAT_Rate { get; set; }
        [DataMember]
        public Nullable<double> VAT_Amount { get; set; }
    }
}
