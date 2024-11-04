using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class OnlineDifferentialPricingDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public string RuleName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsRuleDisabled { get; set; }
        [DataMember]
        public DateTime? ValidFrom { get; set; }
        [DataMember]
        public DateTime? ValidTo { get; set; }
        [DataMember]
        public List<ProductSegmentDTO> ProductSegment { get; set; }
        [DataMember]
        public AccountSegmentDTO AccountSegment { get; set; }
        [DataMember]
        public BeneficiarySegmentDTO BeneficiarySegment { get; set; }
        [DataMember]
        public TokenSegmentDTO TokenSegment { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int LastUpdatedUSerID { get; set; }
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }
        [DataMember]
        public int LastUpdatedLocationID { get; set; }
    }
}