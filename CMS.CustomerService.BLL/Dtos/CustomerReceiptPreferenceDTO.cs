
using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerReceiptPreferenceDTO : BaseDTO
    {
        [DataMember()]
        public Int32? CustomerId { get; set; }

        [DataMember()]
        public Int32? ReceiptTypeId { get; set; }

    }
}
