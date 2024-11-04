using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class MapTokenToRuleDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public List<Int32> TokenList { get; set; }
        [DataMember]
        public int LastUpdatedUserID { get; set; }
        [DataMember]
        public int LastUpdatedLocationID { get; set; }
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
    }
}
