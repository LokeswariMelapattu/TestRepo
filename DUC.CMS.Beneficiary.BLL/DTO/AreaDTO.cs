using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    public class AreaDTO : BaseDTO
    {
        [DataMember]
        public int AreaID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

    }
}
