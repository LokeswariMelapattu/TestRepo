using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class AreaDTO : BaseDTO
    {
        [DataMember()]
        public Int32 AreaId { get; set; }

        [DataMember()]
        public String ARName { get; set; }

        [DataMember()]
        public String ENName { get; set; }

        public AreaDTO()
        {
        }
    }
}
