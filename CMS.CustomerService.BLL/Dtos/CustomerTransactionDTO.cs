using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public partial class CustomerTransactionDTO : BaseDTO
    {
        [DataMember]
        public decimal? TransactionAmount { get; set; }

        [DataMember]
        public decimal? Adjustment { get; set; }

        [DataMember]
        public decimal? TotalAmount { get; set; }
    }
}
