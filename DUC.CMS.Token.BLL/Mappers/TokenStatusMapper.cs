using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
       
    public static partial class TokenStatusMapper
    {
       
        static partial void OnDTO(this TOKEN_STATUS entity, StatusDTO dto);

        static partial void OnEntity(this StatusDTO dto, TOKEN_STATUS entity);
      
        public static TOKEN_STATUS ToEntity(this StatusDTO dto)
        {
            if (dto == null) return null;

            var entity = new TOKEN_STATUS();

            entity.TOKEN_STATUS_ID = dto.StatusID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }
      
        public static StatusDTO ToDTO(this TOKEN_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new StatusDTO();

            dto.StatusID = entity.TOKEN_STATUS_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<TOKEN_STATUS> ToEntities(this IEnumerable<StatusDTO> dtos)
        {
            return LinqExtension.ToEntity<TOKEN_STATUS, StatusDTO>(dtos, ToEntity);
        }
       
        public static List<StatusDTO> ToDTOs(this IEnumerable<TOKEN_STATUS> entities)
        {
            return LinqExtension.ToDTO<TOKEN_STATUS, StatusDTO>(entities, ToDTO);
        }
    }
}





