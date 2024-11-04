using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class SearchTokenIssuanceResultDTO
    {
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public int? CustomerStatusID { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CompanyRegistrationID { get; set; }
        [DataMember]
        public int? ClassificationID { get; set; }
        [DataMember]
        public System.DateTime? RegistrationDate { get; set; }
        [DataMember]
        public string FinancialAccountNumber { get; set; }
        [DataMember]
        public int? EmployeeNumber { get; set; }
        [DataMember]
        public int? TokenTypeID { get; set; }
        [DataMember]
        public int? TokenID { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public string TokenStatus { get; set; }
    }
}
