using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class CustomerTokenSearchDTO : BaseDTO
    {

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        
        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public int? TokenId { get; set; }

        [DataMember]
        public int? CurrentTokenId { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string IdNumber { get; set; }

        [DataMember]
        public int? BeneficiaryId { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public int? RestrictionGroupID { get; set; }

        [DataMember]
        public string RegistrationGroup { get; set; }

        [DataMember]
        public int? StatusId { get; set; }

        [DataMember]
        public string StatusNameEn { get; set; }

        [DataMember]
        public string StatusNameAr { get; set; }

        [DataMember]
        public DateTime? RegisterFrom { get; set; }

        [DataMember]
        public DateTime? RegisterTo { get; set; }

        [DataMember]
        public DateTime? RegistrationDate { get; set; }

        [DataMember]
        public int? TokenTypeId { get; set; }

        [DataMember]
        public string TokenTypeNameEn { get; set; }

        [DataMember]
        public string TokenTypeNameAr { get; set; }

        [DataMember]
        public string Serial { get; set; }

        [DataMember]
        public int? CustomerId { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }

        [DataMember]
        public string OnlineDifferentialPricing { get; set; }
        [DataMember]
        public string EomDifferentialPricing { get; set; }
        [DataMember]
        public DateTime? ExpiryDate { get; set; }


    }
}
