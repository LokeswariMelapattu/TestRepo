using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class FamilySegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public int FamilyID { get; set; }
        [DataMember]
        public bool IsFirstVehicleOnly { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}