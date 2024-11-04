using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{

    public class RequestWorkflowHistoryDTO
    {
        [DataMember]
        public string RequestNumber { get; set; }
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public string RequestType { get; set; }
        [DataMember]
        public string RequestSource { get; set; }
        [DataMember]
        public string CurrentRequestStatus { get; set; }
        [DataMember]
        public List<WorkFlowHistoryDTO> WorkFlowHistory { get; set; }
    }
}
 