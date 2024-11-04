using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "TransactionProductDTO")]
    public class TransactionProductDTO : BaseDTO
    {
        [DataMember]
        public int? ProductID { get; set; }
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
        public int? IntegrationID { get; set; }
        [DataMember]
        public int? IsService { get; set; }
        [DataMember]
        public string IntegrationCode { get; set; }
        [DataMember]
        public int? ProductCategoryID { get; set; }
    }


    [DataContract(Name = "ProductCategoryDTO")]
    public class ProductCategoryDTO
    {
        [DataMember]
        public int? ProductCategoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NameAr { get; set; }
        [DataMember]
        public bool IsProductRestriction { get; set; }
        [DataMember]
        public bool IsPerTransactionLimit { get; set; }
        [DataMember]
        public bool IsTransactionFrequency { get; set; }
        [DataMember]
        public bool IsAmountRestriction { get; set; }
        [DataMember]
        public int? IsActive { get; set; }
        [DataMember]
        public bool IsQuantityRestriction { get; set; }

    }

    [DataContract(Name = "CategoryDTO")]
    public class CategoryDTO
    {
        [DataMember]
        public int? ProductCategoryID { get; set; }
        [DataMember]
        public string ProductCategoryName { get; set; }
        [DataMember]
        public string ProductCategoryARName { get; set; }
    }
}
