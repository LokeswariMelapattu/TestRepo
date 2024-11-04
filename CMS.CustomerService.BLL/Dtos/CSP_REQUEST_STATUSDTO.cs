using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
  public  class CSP_REQUEST_STATUSDTO:BaseDTO
    {
      [DataMember]
      public int REQUEST_STATUS_ID { get; set; }
      [DataMember]
      public string EN_NAME { get; set; }
      [DataMember]
      public string AR_NAME { get; set; }
    }
}
