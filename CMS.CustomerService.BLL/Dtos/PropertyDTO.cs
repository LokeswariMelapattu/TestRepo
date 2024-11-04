using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "PropertyDTO1")]
    public class PropertyDTO : BaseDTO
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }
    }
}
