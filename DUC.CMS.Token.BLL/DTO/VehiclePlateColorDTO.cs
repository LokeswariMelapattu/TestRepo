using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehiclePlateColorDTO : BaseDTO
    {
        [DataMember]
        public int VehicleColorID { get; set; }

        [DataMember]
        public string VehicleColorEn { get; set; }

        [DataMember]
        public string VehicleColorAr { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
