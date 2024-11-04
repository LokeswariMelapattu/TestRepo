using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CityDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CityID { get; set; }

        [DataMember()]
        public String EnName { get; set; }

        [DataMember()]
        public String ArName { get; set; }
    }
}
