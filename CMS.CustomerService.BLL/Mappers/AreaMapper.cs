using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="AREA"/> and <see cref="AreaDTO"/>.
    /// </summary>
    public static partial class AreaMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AreaDTO"/> converted from <see cref="AREA"/>.</param>
        static partial void OnDTO(this AREA entity, AreaDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="AREA"/> converted from <see cref="AreaDTO"/>.</param>
        static partial void OnEntity(this AreaDTO dto, AREA entity);

        /// <summary>
        /// Converts this instance of <see cref="AreaDTO"/> to an instance of <see cref="AREA"/>.
        /// </summary>
        /// <param name="dto"><see cref="AreaDTO"/> to convert.</param>
        public static AREA ToEntity(this AreaDTO dto)
        {
            if (dto == null) return null;

            var entity = new AREA();

            entity.AREA_ID = dto.AreaId;
            entity.AR_NAME = dto.ARName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.EN_NAME = dto.ENName;
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
        public static AreaDTO ToDTO(this AREA entity)
        {
            if (entity == null) return null;

            var dto = new AreaDTO();

            dto.AreaId = entity.AREA_ID;
            dto.ARName = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ENName = entity.EN_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID =(int?) entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AreaDTO"/> to an instance of <see cref="AREA"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<AREA> ToEntities(this IEnumerable<AreaDTO> dtos)
        {
            return LinqExtension.ToEntity<AREA, AreaDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="AREA"/> to an instance of <see cref="AreaDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<AreaDTO> ToDTOs(this IEnumerable<AREA> entities)
        {
            return LinqExtension.ToDTO<AREA, AreaDTO>(entities, ToDTO);
        }

    }
}
