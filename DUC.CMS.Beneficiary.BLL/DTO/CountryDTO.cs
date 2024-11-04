using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    public class CountryDTO : BaseDTO
    {
        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
