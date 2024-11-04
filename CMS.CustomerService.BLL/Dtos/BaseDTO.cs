using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "BaseDTO1")]
    public  class BaseDTO
    {
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
        [DataMember]
        public int? LastUpdatedUserId { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int? LastUpdatedLocationID { get; set; }
    }
}
 