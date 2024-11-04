using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerBillingDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public Int32 InvoiceID { get; set; }

        [DataMember()]
        public DateTime BillingDate { get; set; }

        [DataMember()]
        public DateTime? DueDate { get; set; }

        [DataMember()]
        public string InvoiceNumber { get; set; }

        [DataMember()]
        public DateTime? DateFrom { get; set; }

        [DataMember()]
        public DateTime? DateTo { get; set; }

        [DataMember()]
        public String BillingPeriod_EN { get; set; }

        [DataMember()]
        public String BillingPeriod_AR { get; set; }

        [DataMember()]
        public Int32 StatusID { get; set; }

        [DataMember()]
        public String StatusName { get; set; }

        [DataMember()]
        public String StatusNameAR { get; set; }
    }
}
