using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchDPRulesResultDTO : BaseDTO
    {
        [DataMember]
        public string RuleName { get; set; }
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int RuleTypeID { get; set; }
        [DataMember]
        public string RuleType { get; set; }
        [DataMember]
        public DateTime ValidFromDate { get; set; }
        [DataMember]
        public DateTime ValidToDate { get; set; }
    }
}
