using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class BatchTokenDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public string TokenName { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

        [DataMember]
        public int? TokenTypeId { get; set; }

        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        [DataMember]
        public int? RestrictionGroupId { get; set; }

        [DataMember]
        public int? TokenStatusId { get; set; }

        [DataMember]
        public int? TokenStatusReasonId { get; set; }

        [DataMember]
        public int? CardCentreID { get; set; }

        [DataMember]
        public DateTime? AppointmentDate { get; set; }

        [DataMember]
        public int? PersonalizationReasonID { get; set; }

        [DataMember]
        public int? PersonalizationOrderStatusID { get; set; }

        [DataMember]
        public int? PersonalizationOrderTypeID { get; set; }

        [DataMember]
        public string StatusRemark { get; set; }

        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public int? IdentificationTypeID { get; set; }

        [DataMember]
        public string IdentificationNumber { get; set; }

        [DataMember]
        public int PersonalizationOrderID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
