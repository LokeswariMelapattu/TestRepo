using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PersonalizedDataDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string CardSerial { get; set; }

        [DataMember]
        public bool IsVIPAccess { get; set; }

        [DataMember]
        public int? PrinterID { get; set; }

        [DataMember]
        public int? CardCentreID { get; set; }

        [DataMember]
        public int? TokenStatusID { get; set; }

        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public int? BenefiicaryID { get; set; }

        [DataMember]
        public string BenefiicaryCode { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public int? CustomerTypeID { get; set; }

        [DataMember]
        public string CustomerType { get; set; }

        [DataMember]
        public string CustomerTypeAR{ get; set; }

        [DataMember]
        public string TokenCode { get; set; }
        
        [DataMember]
        public string TokenName { get; set; }

    }
}
