using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class SMSDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public int BeneficiaryID { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
