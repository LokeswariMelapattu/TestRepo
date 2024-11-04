using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TimeFrequencyDTO : BaseDTO
    {
        [DataMember]
        public int TimeFrequencyID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
