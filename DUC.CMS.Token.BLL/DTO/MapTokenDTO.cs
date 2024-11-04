using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class MapTokenDTO : BaseDTO
    {
        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public int? TokenStatusID { get; set; }

        [DataMember]
        public string TokenStatus { get; set; }

        [DataMember]
        public string TokenStatusAr { get; set; }

        [DataMember]
        public int? TokenTypeID { get; set; }

        [DataMember]
        public string TokenType { get; set; }

        [DataMember]
        public string TokenTypeAr { get; set; }
    }
}






