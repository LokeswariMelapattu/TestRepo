using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionStationDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }

        [DataMember]
        public int StationID { get; set; }

        [DataMember]
        public string StationName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string AR_NAME { get; set; }
        
    }
}
