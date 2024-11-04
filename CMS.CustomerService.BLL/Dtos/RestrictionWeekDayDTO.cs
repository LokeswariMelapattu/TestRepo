using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RestrictionWeekDayDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }
        [DataMember]
        public int WeekDayID { get; set; }
        [DataMember]
        public string WeekDayName { get; set; }
    }
}
