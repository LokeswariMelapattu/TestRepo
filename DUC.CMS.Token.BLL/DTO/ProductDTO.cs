using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class ProductDTO : BaseDTO
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductEnName { get; set; }
        [DataMember]
        public Nullable<decimal> UnitPrice { get; set; }
        [DataMember]
        public bool IsDry { get; set; }
        [DataMember]
        public string ProductArName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string ColorCode { get; set; }
    }
}
