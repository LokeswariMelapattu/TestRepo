using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionAmountDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }

        [DataMember]
        public int TimeFrequencyID { get; set; }

        [DataMember] 
        public TimeFrequencyDTO TimeFrequencyDTO { get; set; }        

        [DataMember]
        public decimal? AllowedAmount { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public int ProductCategoryID { get; set; }

    }
}
