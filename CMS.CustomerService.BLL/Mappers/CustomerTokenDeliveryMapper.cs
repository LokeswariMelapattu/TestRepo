using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class CustomerTokenDeliveryMapper
    {
        internal static CTSearchTokenToDeliver MapToEntity(this SearchTokenToDeliverDTO dto)
        {
            if (dto == null) return null;
            return new CTSearchTokenToDeliver
            {
                TokenCode = dto.TokenCode,
                TokenName = dto.TokenName,
                TokenSerial = dto.TokenSerial,
                TokenTypeID = dto.TokenTypeID,
                BeneficiaryID = dto.BeneficaryID,
                BeneficiaryName = dto.BeneficiaryName,
                BeneficiaryCode = dto.BeneficiaryCode,
                CustomerID = dto.CustomerID,
                CustomerName = dto.CustomerName,
                CustomerCode = dto.CustomerCode,
                PageSize = dto.PageSize,
                PageNumber = dto.PageNumber
            };
        }

        internal static TokenToDeliverDTO MapToDto(this CTSearchTokenToDeliverResult rpf)
        {
            if (rpf == null) return null;
            return new TokenToDeliverDTO
            {
                TokenCode = rpf.TokenCode,
                TokenName = rpf.TokenName,
                TokenSerial = rpf.TokenSerial,
                TokenType = rpf.TokenType,
                CustomerName = rpf.CustomerName,
                BeneficaryName = rpf.BeneficiaryName,
                TokenID = rpf.TokenID

            };
        }

        internal static List<TokenToDeliverDTO> MapToListDto(this List<CTSearchTokenToDeliverResult> rpf)
        {
            var CTRolePageFunctionDTO = new List<TokenToDeliverDTO>();
            foreach (CTSearchTokenToDeliverResult item in rpf)
            {
                CTRolePageFunctionDTO.Add(MapToDto(item));
            }
            return CTRolePageFunctionDTO;
        }
    }
}
