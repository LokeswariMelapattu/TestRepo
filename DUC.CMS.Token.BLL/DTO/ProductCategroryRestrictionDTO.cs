using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class ProductCategroryRestrictionDTO
    {
        [DataMember]
        public int ProductCategoryID { get; set; }
        [DataMember]
        public List<RestrictionProductDTO> RestrictionProductDTO { get; set; }
        [DataMember]
        public List<RestrictionAmountDTO> RestrictionAmountDTO { get; set; }
        [DataMember]
        public List<RestrictionQuantityDTO> RestrictionQuantityDTO { get; set; }
        [DataMember]
        public List<RestrictionTransactionDTO> RestrictionTransactionDTO { get; set; }
        [DataMember]
        public List<RestrictionTransNoDTO> RestrictionTransNoDTO { get; set; }
    }
}
