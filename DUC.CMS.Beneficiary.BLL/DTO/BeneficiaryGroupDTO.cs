using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class BeneficiaryGroupDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string BeneficiaryID { get; set; }

        [DataMember]
        public int GroupID { get; set; }
    }
}
