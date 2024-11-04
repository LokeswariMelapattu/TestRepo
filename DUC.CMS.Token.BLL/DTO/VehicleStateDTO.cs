using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehicleStateDTO : BaseDTO
    {
        [DataMember]
        public int VehicleStateID { get; set; }

        [DataMember]
        public string NameEN { get; set; }

        [DataMember]
        public string NameAR { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
