using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class EmployeeHRDTO : BaseDTO
    {
        [DataMember()]
        public int EmployeeNumber { get; set; }

        [DataMember()]
        public String EmployeeName { get; set; }

        [DataMember()]
        public String EmployeeRole { get; set; }

        [DataMember()]
        public int? NationalityID { get; set; }

        [DataMember()]
        public Nullable<DateTime> TerminationDate { get; set; }

        [DataMember()]
        public string NationalId { get; set; }

        [DataMember()]
        public String Email { get; set; }

        [DataMember()]
        public String Address { get; set; }

        [DataMember()]
        public Nullable<Int64> EmployeePhone { get; set; }

        [DataMember()]
        public string EmployeeMobile { get; set; }

        [DataMember()]
        public String LocationDepartment { get; set; }

        [DataMember()]
        public String Gender { get; set; }

        [DataMember()]
        public DateTime? Birthday { get; set; }

    }
}
