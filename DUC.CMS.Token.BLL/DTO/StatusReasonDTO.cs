using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class StatusReasonDTO : BaseDTO
    {

        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public int StatusReasonID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
