using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial  class UpliftDiscountDTO : BaseDTO
    {
        [DataMember()]
        public int UpLiftID { get; set; }

        [DataMember()]
        public int ProductID { get; set; }

        [DataMember()]
        public string ProductName { get; set; }

        [DataMember()]
        public string ProductNameAr { get; set; }

        [DataMember()]
        public decimal? Quantity { get; set; }

        [DataMember()]
        public decimal? PriceUpliftDiscount { get; set; }
    }
}
