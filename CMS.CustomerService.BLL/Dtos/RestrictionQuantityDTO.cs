using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RestrictionQuantityDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int TimeFrequencyID { get; set; }
        [DataMember]
        public TimeFrequencyDTO TimeFrequency { get; set; }
        [DataMember]
        public decimal? AllowedAmount { get; set; }
        [DataMember]
        public int AllowedProductID { get; set; }
        [DataMember]
        public string AllowedProductName { get; set; }
    }
}
