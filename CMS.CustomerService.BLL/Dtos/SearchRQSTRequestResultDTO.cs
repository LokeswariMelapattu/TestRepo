using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class SearchRQSTRequestResultDTO:BaseDTO
    {
        [DataMember]
        public Nullable<int> RequestId { get; set; }
        [DataMember]
        public Nullable<int> RequestTypeID { get; set; }
        [DataMember]
        public Nullable<int> RequestStatusId { get; set; }
        [DataMember]
        public Nullable<int> RequesterUserId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RequestDate { get; set; }
        [DataMember]
        public string RequestType { get; set; }
        [DataMember]
        public string RequestStatus { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string RequestCode { get; set; }
        [DataMember]
        public int RequestActionID { get; set; }
        [DataMember]
        public string RequestAction { get; set; }
        [DataMember]
        public string RequestOriginatorUserName { get; set; }
        [DataMember]
        public string LastUpdatedUserName { get; set; }
        [DataMember]
        public string ApproverLevel { get; set; } 
    }
}
 