using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerBillingPeriodDTO : BaseDTO
    {
        [DataMember()]
        public DateTime DateFrom { get; set; }

        [DataMember()]
        public DateTime DateTo { get; set; }

        [DataMember()]
        public String PeriodEn { get; set; }

        [DataMember()]
        public string PeriodAr { get; set; }
    }
}
