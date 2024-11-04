using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class BillingFrequencyDTO
    {
        [DataMember]
        public int BillingFrequenceId { get; set; }
        [DataMember]
        public string EnName { get; set; }
        [DataMember]
        public int IsActive { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public int? Duration { get; set; }
        [DataMember]
        public int? LastUpdatedUserId { get; set; }
        [DataMember]
        public DateTime? LastUpadtedDate { get; set; }
        [DataMember]
        public int? LastLocationId { get; set; }
    }
}
