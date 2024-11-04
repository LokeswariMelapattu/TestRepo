using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class StatusReasonDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CUSTOMER_STATUS_REASON_ID { get; set; }

        [DataMember()]
        public Int32 CUSTOMER_STATUS_ID { get; set; }

        [DataMember()]
        public String EN_NAME { get; set; }

        [DataMember()]
        public String DESCRIPTION { get; set; }

        [DataMember()]
        public String AR_NAME { get; set; }

    }
}
