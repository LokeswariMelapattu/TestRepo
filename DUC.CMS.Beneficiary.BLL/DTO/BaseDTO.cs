using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract(Name = "BaseDTO2")]
    public  class BaseDTO
    {
        [DataMember]
        public Nullable<int> LastUpdateUser { get; set; }
        [DataMember]
        public Nullable<DateTime> LastUpdateDate { get; set; }
        [DataMember]
        public int? LocationID { get; set; }
    }
}
