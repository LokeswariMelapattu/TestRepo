using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class DriverCardSearchDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

         [DataMember]
        public int? CurrentTokenID { get; set; }

        [DataMember]
        public string TokenCode{ get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public string TokenSerial { get; set; }

        //[DataMember]
        //public int? BeneficiaryID { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public DateTime? RegistrationFromDate { get; set; }

        [DataMember]
        public DateTime? RegistrationToDate { get; set; }

        [DataMember]
        public int CustomerID { get; set; }
    }
}
