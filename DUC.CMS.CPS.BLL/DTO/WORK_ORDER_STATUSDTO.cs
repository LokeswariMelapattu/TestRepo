using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class WORK_ORDER_STATUSDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int WORK_ORDER_STATUS_ID { get; set; }
        [DataMember]
        public string EN_NAME { get; set; }
        [DataMember]
        public short IS_ACTIVE { get; set; }
        [DataMember]
        public string AR_NAME { get; set; }
    }
}
