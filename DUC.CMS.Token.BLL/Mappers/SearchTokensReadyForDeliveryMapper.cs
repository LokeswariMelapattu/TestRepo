using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class SearchTokensReadyForDeliveryMapper
    {
        public static TokenToDeliverDTO MapToDto(this CTSearchTokenToDeliverResult rpf)
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

        public static List<TokenToDeliverDTO> MapToListDto(this List<CTSearchTokenToDeliverResult> rpf)
        {
            var tokenToDeliverDTO = new List<TokenToDeliverDTO>();
            foreach (CTSearchTokenToDeliverResult item in rpf)
            {
                tokenToDeliverDTO.Add(MapToDto(item));
            }
            return tokenToDeliverDTO;
        }

        public static CTSearchTokenToDeliver MapToEntity(this SearchTokenToDeliverDTO dto)
        {
            if (dto == null) return null;
            return new CTSearchTokenToDeliver
            {
                TokenCode = dto.TokenCode,
                TokenName = dto.TokenName,
                TokenSerial = dto.TokenSerial,
                TokenTypeID = (dto.TokenTypeID),
                BeneficiaryID = (dto.BeneficaryID),
                CustomerID = dto.CustomerID,
                PageNumber=dto.PageNumber,
                PageSize=dto.PageSize
            };
        }

        public static List<CTSearchTokenToDeliver> MapToListEntity(this List<SearchTokenToDeliverDTO> dtos)
        {
            var entity = new List<CTSearchTokenToDeliver>();
            foreach (SearchTokenToDeliverDTO item in dtos)
            {
                entity.Add(MapToEntity(item));
            }
            return entity;
        }



    }
}
