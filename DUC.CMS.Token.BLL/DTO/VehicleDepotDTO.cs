using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehicleDepotDTO : BaseDTO
    {
        [DataMember]
        public int VEHICLE_DEPOT_ID { get; set; }

        [DataMember]
        public string EN_NAME { get; set; }

        [DataMember]
        public Nullable<int> ADDRESS_ID { get; set; }

        [DataMember]
        public short IS_ACTIVE { get; set; }

        [DataMember]
        public string AR_NAME { get; set; }
    }
}
