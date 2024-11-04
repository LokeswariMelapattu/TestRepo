using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class BeneficiarySegmentDTO : BaseDTO
    {
        [DataMember]
        public int RuleID { get; set; }
        [DataMember]
        public DateTime FromDOB { get; set; }
        [DataMember]
        public DateTime ToDOB { get; set; }
        [DataMember]
        public bool IsVIP { get; set; }
        [DataMember]
        public int NationalityID { get; set; }
        [DataMember]
        public bool HasDisability { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}