using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class ShiftTypeDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int ShiftTypeID { get; set; }

        [DataMember]
        public string ENName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
