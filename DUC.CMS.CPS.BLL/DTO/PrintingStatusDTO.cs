using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PrintingStatusDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? PrintingStatusID { get; set; }

        [DataMember]
        public string EnName { get; set; }    

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
