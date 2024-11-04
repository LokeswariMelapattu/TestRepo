using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class WorkFlowHistoryDTO : BaseDTO
    {
        [DataMember]
        public int? WFInstanceID { get; set; }
        [DataMember]
        public DateTime RequestDate { get; set; }
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string AssignedTo { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public bool HasHistoryData { get; set; }
    }
}
