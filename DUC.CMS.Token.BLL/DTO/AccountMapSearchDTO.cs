using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class AccountMapSearchDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public int UserID { get; set; }
    }
}
