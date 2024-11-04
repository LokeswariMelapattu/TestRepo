using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="COUNTRY"/> and <see cref="CountryDTO"/>.
    /// </summary>
    public static partial class CountryMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CountryDTO"/> converted from <see cref="COUNTRY"/>.</param>
        static partial void OnDTO(this COUNTRY entity, CountryDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="COUNTRY"/> converted from <see cref="CountryDTO"/>.</param>
        static partial void OnEntity(this CountryDTO dto, COUNTRY entity);

        /// <summary>
        /// Converts this instance of <see cref="CountryDTO"/> to an instance of <see cref="COUNTRY"/>.
        /// </summary>
        /// <param name="dto"><see cref="CountryDTO"/> to convert.</param>
        public static COUNTRY ToEntity(this CountryDTO dto)
        {
            if (dto == null) return null;

            var entity = new COUNTRY();

            entity.COUNTRY_ID = dto.CountryID;
            entity.EN_NAME = dto.EnName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.AR_NAME = dto.ArName;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="COUNTRY"/> to an instance of <see cref="CountryDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="COUNTRY"/> to convert.</param>
        public static CountryDTO ToDTO(this COUNTRY entity)
        {
            if (entity == null) return null;

            var dto = new CountryDTO();

            dto.CountryID = entity.COUNTRY_ID;
            dto.EnName = entity.EN_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ArName = entity.AR_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CountryDTO"/> to an instance of <see cref="COUNTRY"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<COUNTRY> ToEntities(this IEnumerable<CountryDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<COUNTRY>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="COUNTRY"/> to an instance of <see cref="CountryDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CountryDTO> ToDTOs(this IEnumerable<COUNTRY> entities)
        {
            if (entities == null) return null;
            var dtos = new List<CountryDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
