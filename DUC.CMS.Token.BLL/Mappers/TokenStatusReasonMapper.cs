using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class TokenStatusReasonMapper
    {
      
        static partial void OnDTO(this TOKEN_STATUS_REASON entity, StatusReasonDTO dto);

        static partial void OnEntity(this StatusReasonDTO dto, TOKEN_STATUS_REASON entity);

        public static TOKEN_STATUS_REASON ToEntity(this StatusReasonDTO dto)
        {
            if (dto == null) return null;

            var entity = new TOKEN_STATUS_REASON();

            entity.TOKEN_STATUS_REASON_ID = dto.StatusReasonID;
            entity.TOKEN_STATUS_ID = dto.StatusID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.DESCRIPTION = dto.Description;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }
 
        public static StatusReasonDTO ToDTO(this TOKEN_STATUS_REASON entity)
        {
            if (entity == null) return null;

            var dto = new StatusReasonDTO();

            dto.StatusReasonID = entity.TOKEN_STATUS_REASON_ID;
            dto.StatusID = entity.TOKEN_STATUS_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<TOKEN_STATUS_REASON> ToEntities(this IEnumerable<StatusReasonDTO> dtos)
        {
            return LinqExtension.ToEntity<TOKEN_STATUS_REASON, StatusReasonDTO>(dtos, ToEntity);
        }

        public static List<StatusReasonDTO> ToDTOs(this IEnumerable<TOKEN_STATUS_REASON> entities)
        {
            return LinqExtension.ToDTO<TOKEN_STATUS_REASON, StatusReasonDTO>(entities, ToDTO);
        }
    }
}






