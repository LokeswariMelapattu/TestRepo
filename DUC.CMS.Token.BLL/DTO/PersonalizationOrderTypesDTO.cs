using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class PersonalizationOrderTypesDTO : BaseDTO
    {
        [DataMember]
        public int PersonalizationOrderTypeID { set; get; }
        [DataMember]
        public string EnName { set; get; }
        [DataMember]
        public string ArName { set; get; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
