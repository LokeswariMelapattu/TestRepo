using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PrinterQueueDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? PrinterQueueID { get; set; }

        [DataMember]
        public int? PersonlizationOrderID { get; set; }

        [DataMember]
        public string PersonalizationRequestNumber { get; set; }

        [DataMember]
        public DateTime? DateAdded { get; set; }

        [DataMember]
        public int? PrinterID { get; set; }

        [DataMember]
        public string PrinterName { get; set; }

        [DataMember]
        public string PersonlizationOrderType { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public int? PrintStatusID { get; set; }

        [DataMember]
        public string PrintingStatus { get; set; }

        [DataMember]
        public string PrintingStatusAR { get; set; }

        [DataMember]
        public string EncoderName { get; set; }

        [DataMember]
        public int RowNum { get; set; }
    }
}
