using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.DTO
{
    [DataContract]
   public  class DictionaryDTO
    {
        [DataMember]        
        public int ID { get; set; }

        [DataMember]
        public string EnName { get; set;}
    }
}
