using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerBeneficiaryGroupDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public Int32 BeneficiaryID { get; set; }

        [DataMember()]
        public Int32? GroupID { get; set; }
    }
}
