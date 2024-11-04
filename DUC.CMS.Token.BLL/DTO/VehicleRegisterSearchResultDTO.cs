using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
   public class VehicleRegisterSearchResultDTO :BaseDTO
    {
        [DataMember]
        public int? VehicleRegisterID { get; set; }

        [DataMember]
        public int? MakeID { get; set; }

        [DataMember]
        public string MakeNameEn { get; set; }

        [DataMember]
        public string MakeNameAr { get; set; }

        [DataMember]
        public int? ModelID { get; set; }

        [DataMember]
        public string ModelNameEn { get; set; }
        [DataMember]
        public string ModelNameAr { get; set; }

        [DataMember]
        public string Year { get; set; }

        [DataMember]
        public int? TagTypeID { get; set; }

        [DataMember]
        public string Cc { get; set; }

        [DataMember]
        public string FuelInlet { get; set; }

        [DataMember]
        public Nullable<decimal> FuelCapacity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string InventoryUnitTypeNAME { get; set; }

        [DataMember]
        public string InventoryUnitTypeNAMEAR { get; set; }
        
    }
}
