using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerAttachmentDTO : BaseDTO
    {
       [DataMember]
        public int? ATTACHMENT_ID { get; set; }
       [DataMember]
       public Nullable<int> REQUESTDOCUMENTID { get; set; }
       [DataMember]
       public byte[] ATTACHMENT { get; set; }
       [DataMember]
       public string FILEEXTENSION { get; set; }
       [DataMember]
       public int? CustomerID { get; set; }

    }
}
