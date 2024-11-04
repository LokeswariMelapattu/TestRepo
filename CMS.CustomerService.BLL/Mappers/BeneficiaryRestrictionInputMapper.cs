using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class BeneficiaryRestrictionInputMapper
    {
        internal static CTBeneficiaryRestrictionInput ToEntity(this BeneficiaryRestrictionInputDTO dto)
        {
            return new CTBeneficiaryRestrictionInput() 
            {
                AllowedAmount = dto.AllowedAmount,
                BeneficiaryId = dto.BeneficiaryId,
                LastLocationId = dto.LastLocationId,
                LastUpdatedUserId = dto.LastUpdatedUserId,
                TimeFrequencyId = dto.TimeFrequencyId
            };
        }
    }
}
