using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class ProductServiceBillingFrequencyDTO : BaseDTO
    {
        [DataMember()]
        public Nullable<Int32> Id { get; set; }
        [DataMember()]
        public Int32 BillingTypeId { get; set; }

        [DataMember()]
        public String BillingTypeNameEN { get; set; }
        [DataMember()]
        public Int32 BillingFrequencyId { get; set; }

        [DataMember()]
        public String BillingFrequencyNameEN { get; set; }
        [DataMember()]
        public Nullable<Int32> CustomerId { get; set; }

        public ProductServiceBillingFrequencyDTO()
        {
        }
    }
}
