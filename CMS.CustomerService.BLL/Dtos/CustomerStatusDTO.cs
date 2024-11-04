using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerStatusDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerStatusId { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember()]
        public String CustomerStatus { get; set; }

        [DataMember()]
        public String ARCustomerStatus { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int? CustomerStatusReasonId { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}
