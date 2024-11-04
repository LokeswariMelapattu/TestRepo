using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class QualityAssuranceDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? UserID { get; set; }

        [DataMember]
        public string CardSerial { get; set; }

        [DataMember]
        public bool QualityPassed { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string FailureReason { get; set; }
    }
}
