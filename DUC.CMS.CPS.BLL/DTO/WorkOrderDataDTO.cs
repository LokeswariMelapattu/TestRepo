using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class WorkOrderDataDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public string Tag_Serial { get; set; }
        [DataMember]
        public string TagNumber { get; set; }
        [DataMember]
        public string TagSerialOpt { get; set; }
        [DataMember]
        public string TagNumberOpt { get; set; }
        [DataMember]
        public Nullable<int> Token_ID { get; set; }
        [DataMember]
        public Nullable<int> WORK_ORDER_ID { get; set; }
        [DataMember]
        public Nullable<int> DepotCentreID { get; set; }
        [DataMember]
        public Nullable<int> NUMBER_OF_ACTIVE_TAGS { get; set; }
        [DataMember]
        public Nullable<int> USER_ID { get; set; }
    }
}
