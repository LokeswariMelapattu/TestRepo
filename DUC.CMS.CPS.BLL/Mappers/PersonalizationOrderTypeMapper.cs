using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PersonalizationOrderTypeMapper
    {
        static partial void OnDTO(this PERSONALIZATION_ORDER_TYPE entity, PersonalizationOrderTypeDTO dto);

        static partial void OnEntity(this PersonalizationOrderTypeDTO dto, PERSONALIZATION_ORDER_TYPE entity);

        public static PERSONALIZATION_ORDER_TYPE ToEntity(this PersonalizationOrderTypeDTO dto)
        {
            if (dto == null) return null;

            var entity = new PERSONALIZATION_ORDER_TYPE();

            entity.PERSONALIZATION_ORDER_TYPE_ID = dto.PersonalizationOrderTypeID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static PersonalizationOrderTypeDTO ToDTO(this PERSONALIZATION_ORDER_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderTypeDTO();
            dto.PersonalizationOrderTypeID = entity.PERSONALIZATION_ORDER_TYPE_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<PERSONALIZATION_ORDER_TYPE> ToEntities(this IEnumerable<PersonalizationOrderTypeDTO> dtos)
        {
            return LinqExtension.ToEntity<PERSONALIZATION_ORDER_TYPE, PersonalizationOrderTypeDTO>(dtos, ToEntity);
        }

        public static List<PersonalizationOrderTypeDTO> ToDTOs(this IEnumerable<PERSONALIZATION_ORDER_TYPE> entities)
        {
            return LinqExtension.ToDTO<PERSONALIZATION_ORDER_TYPE, PersonalizationOrderTypeDTO>(entities, ToDTO);
        }

    }
}