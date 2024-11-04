using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokenStatusHistoryDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string StatusName { get; set; }

        [DataMember]
        public string StatusNameAr { get; set; }

        [DataMember]
        public int? StatusReasonID { get; set; }

        [DataMember]
        public string StatusReasonName { get; set; }

        [DataMember]
        public string StatusReasonNameAr { get; set; }
        
        [DataMember]
        public DateTime? DateTime { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
