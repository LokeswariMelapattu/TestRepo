using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerSearchDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CompanyID { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public int? StatusID { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public DateTime? RegisterFrom { get; set; }
        [DataMember]
        public DateTime? RegisterTo { get; set; }
        [DataMember]
        public DateTime? RegistrationDate { get; set; }
        [DataMember]
        public int? CustomerClassificationID { get; set; }
        [DataMember]
        public string CustomerClassification { get; set; }
        [DataMember]
        public int? AccountTypeID { get; set; }
        [DataMember]
        public string AccountType { get; set; }
        [DataMember]
        public string NationalID { get; set; }
        [DataMember]
        public string FinancialID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
        [DataMember]
        public string IdType { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public int? IsSubscribed { get; set; }
    }
}
