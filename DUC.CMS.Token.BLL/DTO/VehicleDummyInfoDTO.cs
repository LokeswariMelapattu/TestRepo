using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class VehicleDummyInfoDTO : BaseDTO
    {
        [DataMember]
        public int? VehicleInfoID { get; set; }

        [DataMember]
        public string PlateNumber { get; set; }

        [DataMember]
        public string TypeCode { get; set; }

        [DataMember]
        public int? Year { get; set; }

        [DataMember]
        public string MakeNameEN { get; set; } 

        [DataMember]
        public string MakeNameAR { get; set; }
        [DataMember]
        public string ModelNameEN { get; set; }

        [DataMember]
        public string ModelNameAR { get; set; }

        [DataMember]
        public string ChassisNumber { get; set; }

        [DataMember]
        public string EngineNumber { get; set; } 

        [DataMember]
        public int? Cc { get; set; }
        [DataMember]
        public string  FuelInlet { get; set; }
        [DataMember]
        public int? FuelCapacity { get; set; }
    }
}
