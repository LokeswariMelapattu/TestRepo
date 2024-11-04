using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
     [DataContract]
   public class StationDTO
    {
        [DataMember]
        public int StationID { get; set; }
        [DataMember]
        public string NameEn { get; set; }
        [DataMember]
        public Nullable<int> StationGroupId { get; set; }
        [DataMember]
        public string NameAr { get; set; }
        [DataMember]
        public short IsActive { get; set; }
        [DataMember]
        public string Latitude  { get; set; }
        [DataMember]
        public string Longitude  { get; set; }
    }
}
