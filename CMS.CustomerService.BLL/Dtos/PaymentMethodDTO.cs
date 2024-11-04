using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class PaymentMethodDTO:BaseDTO
    {
        [DataMember]
        public int? PaymentMethodId { get; set; }
        [DataMember]
        public string PaymentMethodName { get; set; }
        [DataMember]
        public string ARPaymentMethodName { get; set; }

    }
}
