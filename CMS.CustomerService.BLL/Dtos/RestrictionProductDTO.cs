using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
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
    }
}
