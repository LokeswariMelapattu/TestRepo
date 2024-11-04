using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RestrictionTransactionDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public decimal? MaxTransactionAmount { get; set; }
    }
}
