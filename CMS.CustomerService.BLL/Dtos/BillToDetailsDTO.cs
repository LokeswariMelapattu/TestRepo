
using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class BillToDetailsDTO : BaseDTO
    {

        [DataMember()]
        public string BillToNumber { get; set; }

        [DataMember()]
        public String BillToAddress { get; set; }


        [DataMember()]
        public string BillToFax { get; set; }

        [DataMember()]
        public String PoBox { get; set; }

        [DataMember()]
        public string AddressDetails { get; set; }
    }
}
