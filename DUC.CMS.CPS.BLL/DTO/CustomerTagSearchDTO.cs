using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class CustomerTagSearchDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int Token_ID { get; set; }
        [DataMember]
        public string TagNumberOpt { get; set; }
        [DataMember]
        public string TagSerialOpt { get; set; }
        [DataMember]
        public string TagNumber { get; set; }
        [DataMember]
        public string TagSerial { get; set; }
        [DataMember]
        public string TOKENNAME { get; set; }
        [DataMember]
        public string TOKENCODE { get; set; }
        [DataMember]
        public int DepotCentreID { get; set; }
        [DataMember]
        public int TOKEN_STATUS_ID { get; set; }
        [DataMember]
        public int CUSTOMER_ID { get; set; }
        [DataMember]
        public int BENEFICIARY_ID { get; set; }
        [DataMember]
        public int CustomerTypeID { get; set; }
        [DataMember]
        public int WORK_ORDER_ID { get; set; }
        [DataMember]
        public int WORK_ORDER_TYPE_ID { get; set; }
        [DataMember]
        public int WORK_ORDER_REASON_ID { get; set; }
        [DataMember]
        public int VehicleYear { get; set; }
        [DataMember]
        public int FUEL_INLET { get; set; }
        [DataMember]
        public string BenefiicaryCode { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BenefiicaryName { get; set; }
        [DataMember]
        public string CustomerTypeAR { get; set; }
        [DataMember]
        public string CustomerType { get; set; }
        [DataMember]
        public string VehiclePlate { get; set; }
        [DataMember]
        public string VEHICLEMAKE { get; set; }
        [DataMember]
        public string VehicleModel { get; set; }
        [DataMember]
        public string VehicleColor { get; set; }
        [DataMember]
        public string Emirate { get; set; }
        [DataMember]
        public string WorkOrderReason { get; set; }
        [DataMember]
        public string RFIDTYPEAR { get; set; }
        [DataMember]
        public string RFIDTYPEEN { get; set; }
        [DataMember]
        public string VehicleCategory { get; set; }
    }
}
