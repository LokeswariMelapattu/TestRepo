using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class PersonalizationOrderStatusDTO
    {
        [DataMember]
        public int PersonalizationOrderStatusID { get; set; }
        [DataMember]
        public string EN_NAME { get; set; }
        [DataMember]
        public string AR_NAME { get; set; }
        [DataMember]
        public int isActive { get; set; }
    }
}
