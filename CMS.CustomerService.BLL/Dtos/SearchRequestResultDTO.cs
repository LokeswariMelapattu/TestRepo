using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchRequestResultDTO : BaseDTO
    {
        [DataMember]
        public int? RequestId { get; set; }
        [DataMember]
        public int? RequestTypeID { get; set; }
        [DataMember]
        public int? RequestStatusId { get; set; }
        [DataMember]
        public int? RequesterUserId { get; set; }
        [DataMember]
        public System.DateTime? RequestDate { get; set; }
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
    }
}
