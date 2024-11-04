using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class AppointmentDTO  
    {
        [DataMember]
        public int AppointmentID { get; set; }
        [DataMember]
        public int AppointmentTypeID { get; set; }
        [DataMember]
        public int LocationID { get; set; }
        [DataMember]
        public int ReferenceID { get; set; }
        [DataMember]
        public int AppointmentStatusID { get; set; }
        [DataMember]
        public System.DateTime AppointmentFromDate { get; set; }
        [DataMember]
        public System.DateTime AppointmentToDate { get; set; }
        [DataMember]
        public int? CreatedUserID { get; set; }
        [DataMember]
        public int IsActive { get; set; }
    }
}
