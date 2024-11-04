using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class BatchTokenVehicleMapDTO : BaseDTO
    {
        [DataMember]
        public int TokenID { get; set; }

        [DataMember]
        public int VehicleInfoID { get; set; }

        [DataMember]
        public VehicleInfoDTO VehicleInfo { get; set; }

        [DataMember]
        public int WorkOrderID { get; set; }

        //[DataMember]
        //public WorkOrderDTO WorkOrder { get; set; }
    }
}
