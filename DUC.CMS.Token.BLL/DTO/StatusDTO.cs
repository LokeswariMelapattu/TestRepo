using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class StatusDTO : BaseDTO
    {
        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
