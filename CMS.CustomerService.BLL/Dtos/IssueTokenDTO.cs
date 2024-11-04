using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class IssueTokenDTO : BaseDTO
    {
        [DataMember]
        public int TokenID { get; set; }
        [DataMember]
        public string PersonalizationNumber { get; set; }
        [DataMember]
        public int PersonalizationStatusID { get; set; }
        [DataMember]
        public int CardCentreID { get; set; }
        [DataMember]
        public DateTime AppointmentDate { get; set; }
        [DataMember]
        public int PersonalizationOrderTypeID { get; set; }
        [DataMember]
        public int PersonalizationReasonID { get; set; }
    }
}
