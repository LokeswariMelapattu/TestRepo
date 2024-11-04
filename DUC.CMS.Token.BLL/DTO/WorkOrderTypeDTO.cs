using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class WorkOrderTypeDTO : BaseDTO
    {
        [DataMember]
        public int WorkOrderTypeID { get; set; }
        [DataMember]
        public string EN_NAME { get; set; }
        [DataMember]
        public string AR_NAME { get; set; }
        [DataMember]
        public int isActive { get; set; }
    }
}
