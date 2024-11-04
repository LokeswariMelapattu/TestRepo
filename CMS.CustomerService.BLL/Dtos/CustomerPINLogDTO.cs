using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerPINLogDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerId { get; set; }

        [DataMember()]
        public String PIN { get; set; }

        [DataMember()]
        public DateTime ChangeDateTime { get; set; }
    }
}
