using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class GetVehicleInfoDTO : BaseDTO
    {
        [DataMember]
        public int? VehicleEmirateId { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int? MakeId { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string ChassisNumber { get; set; }
        [DataMember]
        public string TrafficNumber { get; set; }
        [DataMember]
        public int? CC { get; set; }
        [DataMember]
        public int? FuelInlet { get; set; }
        [DataMember]
        public int? FuelCapacity { get; set; }
        [DataMember]
        public Int64? Plate { get; set; }
        [DataMember]
        public string MakeName { get; set; }
        [DataMember]
        public int? ModelId { get; set; }
        [DataMember]
        public int? YearId { get; set; }

    
   /*
                 [DataMember]
        public int VehicleEmirateId { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int MakeId { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string ChassisNumber { get; set; }
        [DataMember]
        public string TrafficNumber { get; set; }
        [DataMember]
        public int? CC { get; set; }
        [DataMember]
        public int? FuelInlet { get; set; }
        [DataMember]
        public int? FuelCapacity { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public string MakeName { get; set; }
        [DataMember]
        public int ModelId { get; set; }
        [DataMember]
        public int YearId { get; set; }
       */
    }
}
