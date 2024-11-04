using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class ShiftDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? ShiftID { get; set; }

        [DataMember]
        public int? ShiftTypeID { get; set; }

        [DataMember]
        public string ShiftType { get; set; }

        [DataMember]
        public int? ShiftStatusID { get; set; }

        [DataMember]
        public string ShiftStatus { get; set; }

        [DataMember]
        public int? UserID { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public int? LocationID { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public DateTime? StartDateTime { get; set; }

        [DataMember]
        public DateTime? EndDateTime { get; set; }
    }
}
