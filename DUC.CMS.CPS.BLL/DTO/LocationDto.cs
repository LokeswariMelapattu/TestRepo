using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract()]
    public partial class LocationDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember()]
        public Int32 LocationID { get; set; }

        [DataMember()]
        public String LocationNameAR { get; set; }

        [DataMember()]
        public String LocationNameEN { get; set; }
    }
}
