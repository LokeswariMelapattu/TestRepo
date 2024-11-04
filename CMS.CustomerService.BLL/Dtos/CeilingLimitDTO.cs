using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
   public class CeilingLimitDTO
    {
       [DataMember]
        public int  CeilingLimitID {get;set;}
       [DataMember]
       public decimal? Limit { get; set; }
    }
}
