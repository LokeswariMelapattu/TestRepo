using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "ProductDTO1")]
    public class ProductDTO : BaseDTO
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ARProductName { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public string ColorCode { get; set; }
        [DataMember]
        public short? ISDRY { get; set; }
        [DataMember]
        public int? ProductCategoryID { get; set; }
    }
}
