using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class IdentityCardDTO : BaseDTO
    {
        [DataMember]
        public int? TOKEN_ID { get; set; }

        [DataMember]
        public string BENEFICIARY_NAME { get; set; }

        [DataMember]
        public string TOKEN_STATUS { get; set; }

        [DataMember]
        public string TOKEN_STATUS_AR { get; set; }

        [DataMember]
        public string TOKEN_TYPE_NAME { get; set; }

        [DataMember]
        public string TOKEN_TYPE_NAME_AR { get; set; }
    }
}
