using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public abstract class BaseDTO
    {
        [DataMember]
        public Nullable<int> LastUpdateUser { get; set; }

        [DataMember]
        public Nullable<DateTime> LastUpdateDate { get; set; }
    }
}
