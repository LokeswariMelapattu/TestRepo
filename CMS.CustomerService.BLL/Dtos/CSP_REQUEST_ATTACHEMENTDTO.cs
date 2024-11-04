using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
  public  class CSP_REQUEST_ATTACHEMENTDTO:BaseDTO
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
