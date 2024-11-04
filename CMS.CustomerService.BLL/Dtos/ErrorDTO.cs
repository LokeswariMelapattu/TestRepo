using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class ErrorDTO : BaseDTO
    {
        [DataMember]
        public string ErrorName { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
    }
}
