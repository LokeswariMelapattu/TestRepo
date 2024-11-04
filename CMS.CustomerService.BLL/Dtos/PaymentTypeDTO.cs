using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class PaymentTypeDTO :BaseDTO
    {
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public string EnName { get; set; }
        [DataMember]
        public string ArName { get; set; }
    }
}
