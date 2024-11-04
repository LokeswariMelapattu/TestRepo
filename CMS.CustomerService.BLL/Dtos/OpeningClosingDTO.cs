using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class OpeningClosingBalanceDTO
    {
        [DataMember]
        public decimal? OpeningBalance { get; set; }

        [DataMember]
        public decimal? ClosingBalance { get; set; }
    }
}
