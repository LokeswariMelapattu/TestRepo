using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class AccountTokenSearchDTO : BaseDTO
    {
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public Nullable<int> RestrictionGroupID { get; set; }
        [DataMember]
        public Nullable<int> TokenStatusID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegisterFromDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> RegisterToDate { get; set; }
        [DataMember]
        public Nullable<int> TokenTypeID { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public string IDNumber { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public Nullable<int> UserId { get; set; }
        [DataMember]
        public Nullable<decimal> EmployeeID { get; set; }

    }
}
