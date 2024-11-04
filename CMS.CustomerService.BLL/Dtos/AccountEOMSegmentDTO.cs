using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class AccountEOMSegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public int NationalityID { get; set; }
        [DataMember]
        public int ClassificationID { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}