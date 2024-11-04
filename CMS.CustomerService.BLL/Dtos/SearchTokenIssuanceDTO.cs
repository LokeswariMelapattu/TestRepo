using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class SearchTokenIssuanceDTO
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public Nullable<int> TokenTypeID { get; set; }
        [DataMember]
        public Nullable<int> TokenStatusID { get; set; }
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string CompanyRegistrationID { get; set; }
        [DataMember]
        public Nullable<int> CustomerstatusID { get; set; }
        [DataMember]
        public Nullable<int> ClassificationID { get; set; }
        [DataMember]
        public Nullable<int> CustomerAccountTypeID { get; set; }
        [DataMember]
        public Nullable<int> EmployeeNumber { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegsiterFromDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegsiterToDate { get; set; }
        [DataMember]
        public string FinancialAccountNumber { get; set; }
    }
}
