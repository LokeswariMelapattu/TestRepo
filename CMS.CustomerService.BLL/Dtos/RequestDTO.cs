using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestDTO : BaseDTO
    {
        [DataMember]
        public int? REQUEST_ID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DATE_TIME { get; set; }
        [DataMember]
        public string EN_RequestType { get; set; }
        [DataMember]
        public int? REQUEST_TYPE_ID { get; set; }
        [DataMember]
        public string AR_RequestType { get; set; }
        [DataMember]
        public int? REQUEST_STATUS_ID { get; set; }
        [DataMember]
        public int? REQUESTER_USER_ID { get; set; }
        [DataMember]
        public int? CUSTOMER_ID { get; set; }
        [DataMember]
        public int? BENEFICIARY_ID { get; set; }
        [DataMember]
        public int? TOKEN_ID { get; set; }
        [DataMember]
        public string REMARKS { get; set; }
        [DataMember]
        public string Code { get; set; }
    }
}
