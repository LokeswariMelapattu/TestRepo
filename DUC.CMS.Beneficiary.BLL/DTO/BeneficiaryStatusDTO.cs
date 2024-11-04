using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class BeneficiaryStatusDTO : BaseDTO
    {
        [DataMember]
        public int BeneficiaryID { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public int? StatusReasonID { get; set; }

        [DataMember]
        public int UserID { get; set; }

    }
}
