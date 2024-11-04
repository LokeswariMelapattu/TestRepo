using System;

using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerStatusHistoryDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int StatusID { get; set; }
        [DataMember]
        public string StatusEnName { get; set; }
        [DataMember]
        public string StatusArName { get; set; }
        [DataMember]
        public int StatusReasonID { get; set; }
        [DataMember]
        public string StatusReasonEnName { get; set; }
        [DataMember]
        public string StatusReasonArName { get; set; }
        [DataMember]
        public DateTime? StatusChangeDate { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
