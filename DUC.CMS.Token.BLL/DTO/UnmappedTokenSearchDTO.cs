using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class UnmappedTokenSearchDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public int? EmployeeID { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

    }
}
