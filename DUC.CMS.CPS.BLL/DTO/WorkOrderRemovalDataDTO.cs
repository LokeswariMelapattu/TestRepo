using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.DTO
{
    [DataContract]
    public class WorkOrderRemovalDataDTO : DUC.CMS.Token.BLL.DTO.BaseDTO
    {
        [DataMember]
        public int Token_ID { get; set; }
        [DataMember]
        public int DepotCentreID { get; set; }
        [DataMember]
        public int WORK_ORDER_ID { get; set; }
        [DataMember]
        public int WORK_ORDER_TYPE_ID { get; set; }
        [DataMember]
        public int Reason { get; set; }
        [DataMember]
        public int ISTOKENPROFILETERMINATE { get; set; }
        [DataMember]
        public int USER_ID { get; set; }
        [DataMember]
        public string Tag_Serial { get; set; }
        [DataMember]
        public string Tag_Number { get; set; }
        [DataMember]
        public string Tag_Serial_Opt { get; set; }
        [DataMember]
        public string Tag_Number_Opt { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
}
