using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class BeneficiaryRestrictionResultDTO
    {
        [DataMember]
        public Nullable<int> TimeFrequencyId { get; set; }
        [DataMember]
        public Nullable<decimal> AllowedAmount { get; set; }
    }
}
