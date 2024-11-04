using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionTransactionDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }

        [DataMember]
        public decimal? MaxTransactionAmount { get; set; }

        [DataMember]
        public int? WeekDayID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int ProductCategoryID { get; set; }
    }
}
