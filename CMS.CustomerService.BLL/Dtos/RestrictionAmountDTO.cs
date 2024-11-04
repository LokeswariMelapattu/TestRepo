using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RestrictionAmountDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int TimeFrequencyID { get; set; }
        [DataMember]
        public TimeFrequencyDTO TimeFrequency { get; set; }
        [DataMember]
        public decimal? AllowedAmount { get; set; }
    }
}