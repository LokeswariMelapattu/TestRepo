using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokenStatusDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public int BeneficiaryID { get; set; }

        [DataMember]
        public int TokenID { get; set; }

        [DataMember]
        public string TokenCODE { get; set; }

        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public int? StatusReasonID { get; set; }

        [DataMember]
        public int userID { get; set; }
    }
}
