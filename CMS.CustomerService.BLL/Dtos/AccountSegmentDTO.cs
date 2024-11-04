using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class AccountSegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public bool IsPremium { get; set; }
        [DataMember]
        public int AccountTypeID { get; set; }
        [DataMember]
        public int EmiratesID { get; set; }
        [DataMember]
        public FamilySegmentDTO Family { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}