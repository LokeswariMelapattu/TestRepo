using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehicleRegister : BaseDTO
    {
        [DataMember]
        public Nullable<int> VehicleRegisterId { get; set; }

        [DataMember]
        public Nullable<int> Year { get; set; }

        [DataMember]
        public Nullable<int> CC { get; set; }

        [DataMember]
        public Nullable<decimal> FuelInlet { get; set; }

        [DataMember]
        public Nullable<decimal> FuelCapacity { get; set; }

        [DataMember]
        public Nullable<short> IsActive { get; set; }

        [DataMember]
        public Nullable<int> InventoryUnitTypeId { get; set; }

        [DataMember]
        public Nullable<int> VehicleModelId { get; set; }

        [DataMember]
        public Nullable<int> VehicleMakeId { get; set; }
    }
}
