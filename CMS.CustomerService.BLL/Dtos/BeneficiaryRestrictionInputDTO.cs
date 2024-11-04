using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class BeneficiaryRestrictionInputDTO
    {
        [DataMember]
        public Nullable<int> BeneficiaryId { get; set; }
        [DataMember]
        public Nullable<int> TimeFrequencyId { get; set; }
        [DataMember]
        public Nullable<int> AllowedAmount { get; set; }
        [DataMember]
        public Nullable<int> LastUpdatedUserId { get; set; }
        [DataMember]
        public Nullable<int> LastLocationId { get; set; }
    }
}
