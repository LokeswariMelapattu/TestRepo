using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class VehicleModelDTO : BaseDTO
    {
        [DataMember]
        public int VehicleModelID { get; set; }

        [DataMember]
        public string ModelEnName { get; set; }

        [DataMember]
        public string ModelArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}

