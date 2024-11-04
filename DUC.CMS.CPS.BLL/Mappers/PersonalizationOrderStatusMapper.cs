using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PersonalizationOrderStatusMapper
    {
        static partial void OnDTO(this PERSONALIZATION_ORDER_STATUS entity, PersonalizationOrderStatusDTO dto);

        static partial void OnEntity(this PersonalizationOrderStatusDTO dto, PERSONALIZATION_ORDER_STATUS entity);

        public static PERSONALIZATION_ORDER_STATUS ToEntity(this PersonalizationOrderStatusDTO dto)
        {
            if (dto == null) return null;

            var entity = new PERSONALIZATION_ORDER_STATUS();

            entity.PERSONALIZATION_STATUS_ID = dto.PersonalizationOrderStatusID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static PersonalizationOrderStatusDTO ToDTO(this PERSONALIZATION_ORDER_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderStatusDTO();

            dto.PersonalizationOrderStatusID = entity.PERSONALIZATION_STATUS_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<PERSONALIZATION_ORDER_STATUS> ToEntities(this IEnumerable<PersonalizationOrderStatusDTO> dtos)
        {
            return LinqExtension.ToEntity<PERSONALIZATION_ORDER_STATUS, PersonalizationOrderStatusDTO>(dtos, ToEntity);
        }

        public static List<PersonalizationOrderStatusDTO> ToDTOs(this IEnumerable<PERSONALIZATION_ORDER_STATUS> entities)
        {
            return LinqExtension.ToDTO<PERSONALIZATION_ORDER_STATUS, PersonalizationOrderStatusDTO>(entities, ToDTO);
        }
    }
}