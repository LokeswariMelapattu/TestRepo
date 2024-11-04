using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerRefundDTO:BaseDTO
    {
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerType { get; set; }
        [DataMember]
        public string CustomerStatus { get; set; }
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public decimal RefundAmount { get; set; }
    }
}
