using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.Token.BLL.Mappers
{
   public static partial class SearchTokenToDeliverMapper
    {
       static partial void OnDTO(this CTSearchTokenToDeliverResult entity, SearchTokenToDeliverResultDTO dto);

       static partial void OnEntity(this SearchTokenToDeliverDTO dto, CTSearchTokenToDeliver entity);

       public static CTSearchTokenToDeliver ToEntity(this SearchTokenToDeliverDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchTokenToDeliver();

            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.BeneficiaryID = dto.BeneficaryID;           

            dto.OnEntity(entity);

            return entity;
        }

       public static SearchTokenToDeliverResultDTO ToDTO(this CTSearchTokenToDeliverResult entity)
        {
            if (entity == null) return null;

            var dto = new SearchTokenToDeliverResultDTO();

            dto.TokenName = entity.TokenName;
            dto.TokenSerial = entity.TokenSerial;
            dto.TokenCode = dto.TokenCode;
            dto.TokenType = dto.TokenType;
            dto.CustomerName = entity.CustomerName;
            entity.OnDTO(dto);

            return dto;
        }

       public static List<SearchTokenToDeliverResultDTO> ToDTOs(this IEnumerable<CTSearchTokenToDeliverResult> entities)
        {
            return LinqExtension.ToDTO<CTSearchTokenToDeliverResult, SearchTokenToDeliverResultDTO>(entities, ToDTO);
        }
    }
}
