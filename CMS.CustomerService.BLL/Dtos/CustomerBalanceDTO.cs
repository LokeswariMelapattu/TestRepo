using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerBalanceDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public decimal UsableBalance { get; set; }
        [DataMember]
        public decimal TotalBalance { get; set; }
        [DataMember]
        public decimal AccumulativeBlockedAmount { get; set; }
    }
}
