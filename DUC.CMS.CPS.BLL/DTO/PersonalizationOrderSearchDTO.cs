using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PersonalizationOrderSearchDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int PersonalizationOrderID { get; set; }

        [DataMember]
        public string PersonalizationRequestNumber { get; set; }

        [DataMember]
        public DateTime? AppointmentDate { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public int? OrderTypeID { get; set; }

        [DataMember]
        public string OrderTypeNameEN { get; set; }

        [DataMember]
        public string OrderTypeNameAR { get; set; }

        [DataMember]
        public int? OrderStatusID { get; set; }

        [DataMember]
        public string OrderStatusNameEN { get; set; }

        [DataMember]
        public string OrderStatusNameAR { get; set; }

        [DataMember]
        public int? CardCenterID { get; set; }

        [DataMember]
        public string CardCenterName { get; set; }

        [DataMember]
        public int? PrintingStatusID { get; set; }

        [DataMember]
        public string PrintingStatusEN { get; set; }

        [DataMember]
        public string PrintingStatusAR { get; set; }

        [DataMember]
        public string CardSerial { get; set; }

        [DataMember]
        public string PrinterName { get; set; }

        [DataMember]
        public DateTime? PrintingDate { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public int RowNum { get; set; }
    }
}
