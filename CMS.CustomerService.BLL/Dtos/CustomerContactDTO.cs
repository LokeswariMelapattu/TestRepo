using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerContactDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public int ContactTypeID { get; set; }
    }
}
