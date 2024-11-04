using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class BatchBeneficiaryDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public int? BeneficiaryID { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PIN { get; set; }

        [DataMember]
        public int? IdentificationTypeID { get; set; }

        [DataMember]
        public string IdentificationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public int? NationalityID { get; set; }

        [DataMember]
        public int? BeneficiaryStatusReasonID { get; set; }

        [DataMember]
        public int? BeneficiaryStatusID { get; set; }

        [DataMember]
        public string StatusRemark { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }
    }
}
