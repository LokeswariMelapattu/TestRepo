using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.BLL.Dtos;


namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class IdentityCardMapper
    {
        static partial void OnDTO(this CTIdentityCard entity, IdentityCardDTO dto);

        public static IdentityCardDTO ToDTO(this CTIdentityCard entity)
        {
            if (entity == null) return null;

            var dto = new IdentityCardDTO();

            dto.TOKEN_ID = entity.TOKEN_ID;
            dto.BENEFICIARY_NAME = entity.BENEFICIARY_NAME;
            dto.TOKEN_STATUS = entity.TOKEN_STATUS;
            dto.TOKEN_STATUS_AR = entity.TOKEN_STATUS_AR;
            dto.TOKEN_TYPE_NAME = entity.TOKEN_TYPE_NAME;
            dto.TOKEN_TYPE_NAME_AR = entity.TOKEN_TYPE_NAME_AR;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<IdentityCardDTO> ToDTOs(this IEnumerable<CTIdentityCard> entities)
        {
            return LinqExtension.ToDTO<CTIdentityCard, IdentityCardDTO>(entities, ToDTO);
        }
    }
}
