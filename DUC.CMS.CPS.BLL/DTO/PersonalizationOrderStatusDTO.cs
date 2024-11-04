using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class PersonalizationOrderStatusDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int PersonalizationOrderStatusID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
