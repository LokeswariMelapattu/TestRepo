using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class ConsumedAmountResultDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int TimeFrequencyID { get; set; }
        [DataMember]
        public TimeFrequencyDTO TimeFrequencyDTO { get; set; }
        [DataMember]
        public decimal? DAILY_USED_AMOUNT { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public decimal? MONTHLY_USED_AMOUNT { get; set; }
        [DataMember]
        public decimal? WEEKLY_USED_AMOUNT { get; set; }
        [DataMember]
        public decimal? YEARLY_USED_AMOUNT { get; set; }
        [DataMember]
        public int ProductCategoryID { get; set; }


    }
}
