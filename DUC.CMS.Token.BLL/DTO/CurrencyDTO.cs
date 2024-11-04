using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class CurrencyDTO
    {
        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public int DecimalPlaces { get; set; }
    }
}
