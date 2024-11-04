using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class CustomerCardSearchDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int PersonalizationOrderID { get; set; }

        [DataMember]
        public string PersonalizationRequestNumber { get; set; }

        [DataMember]
        public DateTime? AppointmentDate { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public int? CustomerTypeID { get; set; }

        [DataMember]
        public string CustomerType { get; set; }

        [DataMember]
        public string CustomerTypeAR { get; set; }

        [DataMember]
        public int? RecipientIdentityID { get; set; }

        [DataMember]
        public string RecipientIdentityType { get; set; }

        [DataMember]
        public string RecipientIdentityTypeAR { get; set; }      

        [DataMember]
        public string RecipientIdentityNumber { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenType { get; set; }

        [DataMember]
        public string TokenTypeAR { get; set; }

        [DataMember]
        public int RowNum { get; set; }
    }
}
