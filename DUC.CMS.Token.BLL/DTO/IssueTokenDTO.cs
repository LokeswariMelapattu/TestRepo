using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class IssueTokenDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string PersonalizationNumber { get; set; }

        [DataMember]
        public int? PersonalizationStatusID { get; set; }

        [DataMember]
        public int? CardCentreID { get; set; }

        [DataMember]
        public DateTime? AppointmentDate { get; set; }

        [DataMember]
        public int? PersonalizationOrderTypeID { get; set; }

        [DataMember]
        public int? PersonalizationReasonID { get; set; }

        [DataMember()]
        public Nullable<Int32> IdentificationTypeID { get; set; }

        [DataMember()]
        public string IdentityNumber { get; set; }
    }
}
