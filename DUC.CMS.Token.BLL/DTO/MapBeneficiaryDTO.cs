using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class MapBeneficiaryDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public int? BeneficiaryStatusID { get; set; }

        [DataMember]
        public string BeneficiaryStatus { get; set; }

        [DataMember]
        public string BeneficiaryStatusAr { get; set; }

        [DataMember]
        public int? IsDefaultBeneficiary { get; set; }

        [DataMember]
        public List<MapTokenDTO> Token { get; set; }
    }
}
