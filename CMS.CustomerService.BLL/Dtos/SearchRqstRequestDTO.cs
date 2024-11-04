using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class SearchRqstRequestDTO
    {
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public Nullable<int> RequestTypeID { get; set; }
        [DataMember]
        public Nullable<int> RequestStatusId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RequestDateFrom { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RequestDateTo { get; set; }
        [DataMember]
        public Nullable<int> AssignedToUserID { get; set; }
        [DataMember]
        public Nullable<int> RequestID { get; set; }
        [DataMember]
        public string RequestCode { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
    }
}
