using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
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
    }
}
