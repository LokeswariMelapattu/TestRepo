using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerBillingSearchDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public string InvoiceNumber { get; set; }

        [DataMember()]
        public DateTime? BillingDate { get; set; }

        [DataMember()]
        public DateTime? DateFrom { get; set; }

        [DataMember()]
        public DateTime? DateTo { get; set; }

        [DataMember()]
        public Int32? BillingID { get; set; }

        [DataMember()]
        public String BillingPeriod { get; set; }

        [DataMember()]
        public decimal? TransactionAmount { get; set; }

        [DataMember()]
        public decimal? Adjustment { get; set; }

        [DataMember()]
        public decimal? TotalAmount { get; set; }

        [DataMember()]
        public decimal? PaidAmount { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String StatusAR { get; set; }
    }
}
