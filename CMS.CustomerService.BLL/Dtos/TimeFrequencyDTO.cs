using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class TimeFrequencyDTO : BaseDTO
    {
        [DataMember]
        public int TimeFrequencyID { get; set; }

        public string Name { get; set; }
    }
}
