using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class EmailDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID{get;set;}

        [DataMember]
        public int? BeneficiaryID{get;set;}

        [DataMember]
        public string RecipientEmail { get; set; }

        [DataMember]
        public string EmailBody { get; set; }

        [DataMember]
        public string EmailSubject { get; set; }

        [DataMember]
        public int? LanguageID { get; set; }

    }
}
