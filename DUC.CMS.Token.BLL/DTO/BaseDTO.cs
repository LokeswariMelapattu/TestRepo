using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public  class BaseDTO
    {
        [DataMember]
        public DateTime? LastUpdatedDate { get; set; }
        [DataMember]
        public int? LastUpdatedUserId { get; set; }
        [DataMember]
        public int? LastUpdatedLocationID { get; set; }
    }
}
