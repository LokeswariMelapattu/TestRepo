using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
   public class DepotDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int DEPOT_ID { get; set; }
        [DataMember]
        public int LOCATION_ID { get; set; }
        [DataMember]
        public string EN_NAME { get; set; }
        [DataMember]
        public short IS_ACTIVE { get; set; }
        [DataMember]
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        [DataMember]
        public string AR_NAME { get; set; }
    }
}
