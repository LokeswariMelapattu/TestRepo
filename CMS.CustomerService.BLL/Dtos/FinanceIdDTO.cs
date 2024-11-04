using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
  public  class FinanceIdDTO
    {
      [DataMember]
      public string DataID { get; set; }

      [DataMember]
      public string ERPNumber { get; set; }
    }
}
