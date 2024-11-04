using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class ProductEOMSegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public double AcountQuota { get; set; }
        [DataMember]
        public double TokenQuota { get; set; }
        [DataMember]
        public int TrxPerMonth { get; set; }
        [DataMember]
        public double UpliftDiscount { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}