using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionSummaryDTO : BaseDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int? RestrictionGroupID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
