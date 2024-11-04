using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class SearchTokenToDeliverDTO : BaseDTO
    {
        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public int? TokenTypeID { get; set; }

        [DataMember]
        public int? BeneficaryID { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public string TokenSerial { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int PageSize { get; set; }

    }
}
