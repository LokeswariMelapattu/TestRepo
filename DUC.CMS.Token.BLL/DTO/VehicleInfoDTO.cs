using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class VehicleInfoDTO : BaseDTO
    {
        [DataMember]
        public int? VehicleInfoID { get; set; }

        [DataMember]
        public string PlateNumber { get; set; }

        [DataMember]
        public string PlateColorID { get; set; }

        [DataMember]
        public int? ColorID { get; set; }

        [DataMember]
        public string ColorName { get; set; }

        [DataMember]
        public Nullable<int> StateID { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string ChassisNumber { get; set; }

        [DataMember]
        public Nullable<int> VehicleRegisterID { get; set; }

        [DataMember]
        public VehicleRegisterDTO VehicleRegisterDTO { get; set; }

        [DataMember]
        public Nullable<int> VehicleTypeID { get; set; }

        [DataMember]
        public string VehicleTypeName { get; set; }

        [DataMember]
        public string EngineNumber { get; set; }

    }
}
