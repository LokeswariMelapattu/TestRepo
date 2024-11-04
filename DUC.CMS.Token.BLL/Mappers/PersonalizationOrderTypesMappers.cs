using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.DTO
{
    public static partial class PersonalizationOrderTypesMappers
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AreaDTO"/> converted from <see cref="AREA"/>.</param>
        static partial void OnDTO(this PERSONALIZATION_ORDER_TYPE entity, PersonalizationOrderTypesDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="AREA"/> converted from <see cref="AreaDTO"/>.</param>
        static partial void OnEntity(this PersonalizationOrderTypesDTO dto, PERSONALIZATION_ORDER_TYPE entity);

        /// <summary>
        /// Converts this instance of <see cref="AreaDTO"/> to an instance of <see cref="AREA"/>.
        /// </summary>
        /// <param name="dto"><see cref="AreaDTO"/> to convert.</param>
        public static PERSONALIZATION_ORDER_TYPE ToEntity(this PersonalizationOrderTypesDTO dto)
        {
            if (dto == null) return null;

            var entity = new PERSONALIZATION_ORDER_TYPE();

            entity.PERSONALIZATION_ORDER_TYPE_ID = dto.PersonalizationOrderTypeID;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.EN_NAME = dto.EnName;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="AREA"/> to an instance of <see cref="AreaDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="AREA"/> to convert.</param>
        public static PersonalizationOrderTypesDTO ToDTO(this PERSONALIZATION_ORDER_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderTypesDTO();

            dto.PersonalizationOrderTypeID = entity.PERSONALIZATION_ORDER_TYPE_ID;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.EnName = entity.EN_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AreaDTO"/> to an instance of <see cref="AREA"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PERSONALIZATION_ORDER_TYPE> ToEntities(this IEnumerable<PersonalizationOrderTypesDTO> dtos)
        {
            return LinqExtension.ToEntity<PERSONALIZATION_ORDER_TYPE, PersonalizationOrderTypesDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="AREA"/> to an instance of <see cref="AreaDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PersonalizationOrderTypesDTO> ToDTOs(this IEnumerable<PERSONALIZATION_ORDER_TYPE> entities)
        {
            return LinqExtension.ToDTO<PERSONALIZATION_ORDER_TYPE, PersonalizationOrderTypesDTO>(entities, ToDTO);
        }
    }
}
