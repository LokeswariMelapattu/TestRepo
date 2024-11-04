using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class MappedDriverDTO : BaseDTO
    {
        [DataMember]
        public int DriverCardID { get; set; }

        [DataMember]
        public string DriverCode { get; set; }

        [DataMember]
        public string DriverCardName { get; set; }

        [DataMember]
        public int TokenID { get; set; }
    }
}
