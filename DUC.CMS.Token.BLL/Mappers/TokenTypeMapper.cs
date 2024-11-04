using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class TokenTypeMapper
    {
        static partial void OnDTO(this TOKEN_TYPE entity, TokenTypeDTO dto);

        public static TokenTypeDTO ToDTO(this TOKEN_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new TokenTypeDTO();

            dto.TOKEN_TYPE_ID = entity.TOKEN_TYPE_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.AR_NAME = entity.AR_NAME;
            dto.DESCRIPTION = entity.DESCRIPTION;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<TokenTypeDTO> ToDTOs(this IEnumerable<TOKEN_TYPE> entities)
        {
            return LinqExtension.ToDTO<TOKEN_TYPE, TokenTypeDTO>(entities, ToDTO);
        }
    }
}
