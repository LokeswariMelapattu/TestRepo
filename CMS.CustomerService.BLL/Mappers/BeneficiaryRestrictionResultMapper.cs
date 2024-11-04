using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class BeneficiaryRestrictionResultMapper
    {
        internal static BeneficiaryRestrictionResultDTO ToDTO (this CTBeneficiaryRestrictionResult ct)
        {
            return new BeneficiaryRestrictionResultDTO() 
            {
                AllowedAmount = ct.ALLOWED_AMOUNT,
                TimeFrequencyId = ct.TIME_FREQUENCY_ID
            };
        }

        internal static List<BeneficiaryRestrictionResultDTO> ToDTOs(this List<CTBeneficiaryRestrictionResult> cts)
        {
            var dtos = new List<BeneficiaryRestrictionResultDTO>();
            foreach (var ct in cts)
                dtos.Add(ct.ToDTO());
            return dtos;
        }
    }
}
