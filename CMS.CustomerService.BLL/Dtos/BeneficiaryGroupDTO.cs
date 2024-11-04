using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class BeneficiaryGroupDTO : BaseDTO
    {
        [DataMember()]
        public Int32? GroupId { get; set; }

        [DataMember()]
        public Int32 CustomerId { get; set; }

        [DataMember()]
        public String ENGroupName { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public String ARGroupName { get; set; }
    }
}
