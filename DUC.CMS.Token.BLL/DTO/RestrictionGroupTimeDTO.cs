using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionGroupTimeDTO : BaseDTO
    {
        [DataMember]
        public int? RestrictionGroupID { get; set; }

        [DataMember]
        public string FromHour { get; set; }

        [DataMember]
        public string ToHour { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

    }
}
