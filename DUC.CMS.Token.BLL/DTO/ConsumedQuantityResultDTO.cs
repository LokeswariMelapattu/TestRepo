using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class ConsumedQuantityResultDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int TimeFrequencyID { get; set; }
        [DataMember]
        public TimeFrequencyDTO TimeFrequencyDTO { get; set; }
        [DataMember]
        public decimal AllowedQuantity { get; set; }
        [DataMember]
        public int AllowedProductID { get; set; }
        [DataMember]
        public string AllowedProductName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string AllowedProductNameAr { get; set; }
        [DataMember]
        public int ProductCategoryID { get; set; }

    }
}
