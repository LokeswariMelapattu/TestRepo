
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerClassificationDTO : BaseDTO
    {
        [DataMember]
        public int CustomerClassificationID { get; set; }

        [DataMember]
        public string Classification { get; set; }

        [DataMember]
        public string ARClassification { get; set; }

        [DataMember]
        public string ENClassification { get; set; }
    }
}
