using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RestrictionTransNoDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int NumberOfDays { get; set; }
        [DataMember]
        public int NumberOfTransactions { get; set; }
        [DataMember]
        public int TimeFrequencyID { get; set; }
    }
}