using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PersonalizationOrderSearchInputDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? PersonalizationOrderID { get; set; }

        [DataMember]
        public string PersonalizationRequestNumber { get; set; }

        [DataMember]
        public DateTime? AppointmentFrom { get; set; }

        [DataMember]
        public DateTime? AppointmentTo { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public int? OrderTypeID { get; set; }

        [DataMember]
        public int? OrderStatusID { get; set; }

        [DataMember]
        public int? CardCenterID { get; set; }

        [DataMember]
        public int? PrintingStatusID { get; set; }

        [DataMember]
        public string CardSerial { get; set; }

        [DataMember]
        public DateTime? PrintingDateFrom { get; set; }

        [DataMember]
        public DateTime? PrintingDateTo { get; set; }

        [DataMember]
        public int PageNo { get; set; }

        [DataMember]
        public int PageSize { get; set; }
    }
}
