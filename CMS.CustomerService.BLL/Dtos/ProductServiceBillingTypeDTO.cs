using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class ProductServiceBillingTypeDTO : BaseDTO
    {
        [DataMember()]
        public Int32 BillingTypeId { get; set; }

        [DataMember()]
        public String BillingTypeNameEN { get; set; }

        [DataMember()]
        public String BillingTypeNameAR { get; set; }

        public ProductServiceBillingTypeDTO()
        {
        }
    }
}
