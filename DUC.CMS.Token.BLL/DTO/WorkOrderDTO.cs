using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class WorkOrderDTO : BaseDTO
    {

        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public int? WorkOrderID { get; set; }

        [DataMember]
        public string WorkOrderNumber { get; set; }

        [DataMember]
        public int? WorkOrderStatusID { get; set; }

        [DataMember]
        public int? WorkOrderStatusReasonID { get; set; }

        [DataMember]
        public int? VehicleInfoID { get; set; }

        [DataMember]
        public int? VehicleDepotID { get; set; }

        [DataMember]
        public DateTime? AppointDateTime { get; set; }

        [DataMember]
        public DateTime? AppointTillDateTime { get; set; }

        [DataMember]
        public DateTime? ServiceDateTime { get; set; }

        [DataMember]
        public int? WorkOrderTypeID { get; set; }

        [DataMember]
        public string RecipientIDNumber { get; set; }

        [DataMember]
        public int? RecipientTypeID { get; set; }
        [DataMember]
        public int? ServiceTypeID { get; set; }
        [DataMember]
        public AppointmentDTO AppointmentDTO { get; set; }
        [DataMember]
        public string PIN { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int? WorkOrderBatchID { get; set; }
    }
}
