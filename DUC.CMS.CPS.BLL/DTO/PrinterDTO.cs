using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PrinterDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int PrinterID { get; set; }

        [DataMember]
        public string PrinterNameEN { get; set; }

        [DataMember]
        public string PrinterNameAR { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool? IsDefault { get; set; }

        [DataMember]
        public bool? IsActive { get; set; }

        [DataMember]
        public int? CardCenterID { get; set; }

        [DataMember]
        public string EncoderName { get; set; }
    }
}
