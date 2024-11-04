using DUC.CMS.Token.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class WorkOrderSearchResultDTO : BaseDTO
    {
        [DataMember]
        public string WORK_ORDER_NUMBER { get; set; }
        [DataMember]
        public string APPOINTMENT_DATE_TIME { get; set; }
        [DataMember]
        public string OrderStatusName { get; set; }
        [DataMember]
        public string OrderStatusNameAR { get; set; }
        [DataMember]
        public string DepotCenterName { get; set; }
        [DataMember]
        public string TagSerial { get; set; }
        [DataMember]
        public string TagNumber { get; set; }
        [DataMember]
        public string TagSerialOpt { get; set; }
        [DataMember]
        public string TagNumberOpt { get; set; }
        [DataMember]
        public string tokencode { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BenefiicaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string OrderTypeName { get; set; }
        [DataMember]
        public string OrderTypeNameAR { get; set; }
        [DataMember]
        public string tokenname { get; set; }
        [DataMember]
        public int? WORK_ORDER_TYPE_ID { get; set; }
        [DataMember]
        public int? WORK_ORDER_STATUS_ID { get; set; }
        [DataMember]
        public int? DepotCentreID { get; set; }
    }
}
