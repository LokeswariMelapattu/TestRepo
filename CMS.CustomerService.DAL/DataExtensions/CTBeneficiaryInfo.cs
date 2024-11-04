using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.DAL.DataExtensions
{
    public class CTBeneficiaryInfo 
    {
        public BENEFICIARY BeneficiaryEntity { get; set; }
        public int? RestrictionTimeFrequencyId { get; set; }
        public decimal? RestrictionAllowedAmount { get; set; }
    }
}
