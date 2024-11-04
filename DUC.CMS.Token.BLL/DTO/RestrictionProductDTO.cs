using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionProductDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }

        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string ProductName { get; set; }
        
        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string ProductNameAr { get; set; }
        [DataMember]
        public int ProductCategoryID { get; set; }

    }
}
