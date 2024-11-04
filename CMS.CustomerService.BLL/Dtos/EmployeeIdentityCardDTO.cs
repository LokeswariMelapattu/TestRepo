using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class EmployeeIdentityCardDTO : BaseDTO
    {
        [DataMember()]
        public Nullable<Int32> TokenId { get; set; }

        [DataMember()]
        public Nullable<Int32> CustomerId { get; set; }

        [DataMember()]
        public Nullable<Int32> EmployeeId { get; set; }

        [DataMember()]
        public Nullable<Int32> PersonalizationNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> PersonalizationStatusId { get; set; }

        [DataMember()]
        public Nullable<Int32> CardCenterId { get; set; }

        [DataMember()]
        public Nullable<DateTime> AppointmentDate { get; set; }

        [DataMember()]
        public Nullable<Int32> PersonalizationOrderTypeId { get; set; }

        [DataMember()]
        public Nullable<Int32> PersonalizationReasonId { get; set; }

        [DataMember()]
        public Nullable<Int32> IdentificationTypeID { get; set; }

        [DataMember()]
        public string IdentityNumber { get; set; }

    }
}
