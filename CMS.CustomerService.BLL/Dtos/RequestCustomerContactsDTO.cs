using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestCustomerContactsDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember]
        public int ContactTypeID { get; set; }

        [DataMember]
        public RequestContactDTO Contact { get; set; }

    }
}
