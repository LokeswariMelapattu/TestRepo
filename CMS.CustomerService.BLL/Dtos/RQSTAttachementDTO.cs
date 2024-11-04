using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
  public  class RQSTAttachementDTO:BaseDTO
    {
      [DataMember]
      public int REQUEST_ATTACHMENT_ID { get; set; }
      [DataMember]
      public int REQUEST_ID { get; set; }
      [DataMember]
      public int REQUEST_DOCUMENT_ID { get; set; }
      [DataMember]
      public byte[] ATTACHMENT { get; set; }
      [DataMember]
      public string FILE_EXTENSION { get; set; }

    }
}
