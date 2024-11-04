using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class BeneficiarySearchDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string IdNumber { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string StatusName { get; set; }

        [DataMember]
        public string NationalID { get; set; }

        [DataMember]
        public Nullable<int> NationalityID { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public Nullable<DateTime> RegistrationDate { get; set; }

        [DataMember]
        public Nullable<DateTime> RegisterFrom { get; set; }

        [DataMember]
        public Nullable<DateTime> RegisterTo { get; set; }

        [DataMember]
        public string CustomerGroup { get; set; }

        [DataMember]
        public bool? IsVIP { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public string CustomerName { get; set; }
    }
}
