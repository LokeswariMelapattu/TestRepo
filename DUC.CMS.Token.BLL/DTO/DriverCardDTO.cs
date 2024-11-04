using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class DriverCardDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public string TokenSerial { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public DateTime? RegistrationDate { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string StatusAr { get; set; }
    }
}
