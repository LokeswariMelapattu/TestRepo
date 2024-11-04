using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CardCenterDTO : BaseDTO
    {
        [DataMember]
        public int CardCentreID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Name_ar { get; set; }
    }
}
