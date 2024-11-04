using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchDPRulesDTO : BaseDTO
    {
        [DataMember]
        public string RuleName { get; set; }
        [DataMember]
        public int RuleTypeID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int StationID { get; set; }
    }
}