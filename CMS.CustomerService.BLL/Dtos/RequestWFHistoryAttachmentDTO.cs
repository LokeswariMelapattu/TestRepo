using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestWFHistoryAttachmentDTO : BaseDTO
    {
        [DataMember]
        public string FILEEXTENSION { get; set; }
        [DataMember]
        public Nullable<int> RequestAttachmentId { get; set; }
        [DataMember]
        public Nullable<int> RequestDocumentId { get; set; }
        [DataMember]
        public byte[] ATTACHMENT { get; set; }
        [DataMember]
        public Nullable<int> WFInstanceID { get; set; }
    }
}

