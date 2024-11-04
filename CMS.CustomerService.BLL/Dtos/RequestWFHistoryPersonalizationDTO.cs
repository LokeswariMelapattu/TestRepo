using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestWFHistoryPersonalizationDTO : BaseDTO
    {

        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public Nullable<int> RequestId { get; set; }
        [DataMember]
        public string CurrentRequestStatus { get; set; }
        [DataMember]
        public Nullable<int> RequestPersonalizationOrderID { get; set; }
        [DataMember]
        public Nullable<int> TokenTypeID { get; set; }
        [DataMember]
        public Nullable<int> TokenStatusID { get; set; }
        [DataMember]
        public Nullable<int> AuthPersonIDType { get; set; }
        [DataMember]
        public Nullable<int> PreferredLocationId { get; set; }
        [DataMember]
        public Nullable<int> ScheduledLocationID { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PreferredDateFrom { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PreferredDateTo { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        [DataMember]
        public string AuthPersonIDNumber { get; set; }
        [DataMember]
        public Nullable<int> ReasonID { get; set; }
        [DataMember]
        public string TokenTypeName { get; set; }

        [DataMember]
        public RequestDTO Request { get; set; }
    }
}
