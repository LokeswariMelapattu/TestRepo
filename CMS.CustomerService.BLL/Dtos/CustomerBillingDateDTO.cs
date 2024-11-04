
using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerBillingDateDTO : BaseDTO
    {
        [DataMember()]
        public DateTime BillingDate { get; set; }
    }
}
