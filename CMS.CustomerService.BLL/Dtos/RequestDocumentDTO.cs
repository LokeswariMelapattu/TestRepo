using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestDocumentDTO:BaseDTO
    {
        [DataMember]
        public int? RequestDocumentId { get; set; }
        [DataMember]
        public int? IsRequired { get; set; }
        [DataMember]
        public int? RequestTypeId { get; set; }
        [DataMember]
        public string EnName { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public string EnDescription { get; set; }
        [DataMember]
        public string ArDescription { get; set; }

    }
}
