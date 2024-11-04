using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerAccountTypeDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerAccountTypeID { get; set; }

        [DataMember()]
        public String ENCustomerAccountType { get; set; }

        [DataMember()]
        public String ARCustomerAccountType { get; set; }
    }
}
