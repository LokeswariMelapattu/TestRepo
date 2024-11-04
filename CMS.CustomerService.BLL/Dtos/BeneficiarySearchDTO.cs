using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class BeneficiarySearchDTO : BaseDTO
    {
        [DataMember]
        public Nullable<int> CustomerID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public Nullable<int> BeneficiaryID { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public Nullable<int> StatusID { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string NationalityName { get; set; }
        [DataMember]
        public Nullable<int> NationalilityID { get; set; }
        [DataMember]
        public string NationalID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegisterFromDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegiserToDate { get; set; }
        [DataMember]
        public string CustomerGroup { get; set; }
        [DataMember]
        public Nullable<bool> IsVIP { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
    }
}
