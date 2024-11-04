using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerGroupDTO : BaseDTO
    {
        [DataMember()]
        public Int32? GroupID { get; set; }

        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public String ENGroupName { get; set; }


        [DataMember()]
        public String ARGroupName { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Int64? CostCenterID { get; set; }
    }
}
