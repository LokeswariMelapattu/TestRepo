using DUC.CMS.Token.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class WORK_ORDER_TYPEDTO : BaseDTO
    {
        [DataMember]
        public int WORK_ORDER_TYPE_ID { get; set; }
        [DataMember]
        public string EN_NAME { get; set; }
        [DataMember]
        public short IS_ACTIVE { get; set; }
        [DataMember]
        public string AR_NAME { get; set; }
    }

}
