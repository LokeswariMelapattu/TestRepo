using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class InventoryReasonDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int? StatusReasonID { get; set; }

        [DataMember]
        public string EnName { get; set; }       

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
