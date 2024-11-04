using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class ProductSegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int StationID { get; set; }
        [DataMember]
        public int FromHour { get; set; }
        [DataMember]
        public int ToHour { get; set; }
        [DataMember]
        public double UpliftDiscount { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}