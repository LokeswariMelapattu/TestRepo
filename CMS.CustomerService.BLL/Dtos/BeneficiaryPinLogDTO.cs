using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class BeneficiaryPinLogDTO : BaseDTO
    {
        [DataMember()]
        public Int32 BeneficiaryID { get; set; }

        [DataMember()]
        public String PIN { get; set; }

        [DataMember()]
        public DateTime ChangeDateTime { get; set; }
    }
}
