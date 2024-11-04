using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
   public class WorkOrderSearchDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public Nullable<long> OrderTypeID { get; set; }
        [DataMember]
        public Nullable<long> OrderStatusID { get; set; }
        [DataMember]
        public Nullable<long> DepotCenterID { get; set; }
        [DataMember]
        public string WorkOrderNumber { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string TagSerial { get; set; }
        [DataMember]
        public string TagNumber { get; set; }
        [DataMember]
        public System.DateTime AppointmentFrom { get; set; }
        [DataMember]
        public System.DateTime AppointmentTo { get; set; }

    }
}
