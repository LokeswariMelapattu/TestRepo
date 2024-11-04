using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionWeekDayDTO :BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        
        [DataMember]
        public int WeekDayID { get; set; }
       
        [DataMember]
        public string WeekDayEnName { get; set; }

        [DataMember]
        public string WeekDayArName { get; set; } 
        
        [DataMember]
        public bool IsActive { get; set; }

    }
}
