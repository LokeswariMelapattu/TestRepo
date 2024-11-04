using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokenToDeliverDTO : BaseDTO
    {
        [DataMember]
        public int TokenID { get; set; }
        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public string TokenType { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string BeneficaryName { get; set; }

        [DataMember]
        public string TokenSerial { get; set; }
    }
}
