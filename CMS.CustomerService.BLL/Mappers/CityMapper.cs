using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CITY"/> and <see cref="CityDTO"/>.
    /// </summary>
    public static partial class CityMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CityDTO"/> converted from <see cref="CITY"/>.</param>
        static partial void OnDTO(this CITY entity, CityDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CITY"/> converted from <see cref="CityDTO"/>.</param>
        static partial void OnEntity(this CityDTO dto, CITY entity);

        /// <summary>
        /// Converts this instance of <see cref="CityDTO"/> to an instance of <see cref="CITY"/>.
        /// </summary>
        /// <param name="dto"><see cref="CityDTO"/> to convert.</param>
        public static CITY ToEntity(this CityDTO dto)
        {
            if (dto == null) return null;

            var entity = new CITY();

            entity.CITY_ID = dto.CityID;
            entity.EN_NAME = dto.EnName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.AR_NAME = dto.ArName;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CITY"/> to an instance of <see cref="CityDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CITY"/> to convert.</param>
        public static CityDTO ToDTO(this CITY entity)
        {
            if (entity == null) return null;

            var dto = new CityDTO();

            dto.CityID = entity.CITY_ID;
            dto.EnName = entity.EN_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.ArName = entity.AR_NAME;
            dto.LastUpdatedLocationID =(int?) entity.LAST_LOCATION_ID;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CityDTO"/> to an instance of <see cref="CITY"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CITY> ToEntities(this IEnumerable<CityDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CITY>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="CITY"/> to an instance of <see cref="CityDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CityDTO> ToDTOs(this IEnumerable<CITY> entities)
        {
            if (entities == null) return null;
            var dtos = new List<CityDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
