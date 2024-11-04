using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehicleMakeModelDTO : BaseDTO
    {
        [DataMember]
        public int? VehicleMakeID { get; set; }
       
        [DataMember]
        public string VehicleMakeName { get; set; }

        [DataMember]
        public string VehicleMakeNameAr { get; set; }

        [DataMember]
        public int? VehicleModelID { get; set; }
       
        [DataMember]
        public string VehicleModelName { get; set; }

        [DataMember]
        public string VehicleModelNameAr { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
