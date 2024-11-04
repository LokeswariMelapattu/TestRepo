using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchTokensForRuleResultDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryCode { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string TokenCode { get; set; }
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public int TokenTypeID { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public string TokenSerial { get; set; }
        [DataMember]
        public int OnlineDPID { get; set; }
        [DataMember]
        public string OnlineDPName { get; set; }
        [DataMember]
        public int EOMDPID { get; set; }
        [DataMember]
        public string EOMDPName { get; set; }
    }
}
