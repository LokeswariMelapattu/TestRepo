using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.DTO
{
    public static partial class DictionaryMapper
    {

        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AreaDTO"/> converted from <see cref="AREA"/>.</param>
        static partial void OnDTO(this CTDictionary entity, DictionaryDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="AREA"/> to an instance of <see cref="AreaDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="AREA"/> to convert.</param>
        public static DictionaryDTO ToDTO(this CTDictionary entity)
        {
            if (entity == null) return null;

            var dto = new DictionaryDTO();

            dto.ID = entity.ID;
            dto.EnName = entity.EN_NAME;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AREA"/> to an instance of <see cref="AreaDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<DictionaryDTO> ToDTOs(this IEnumerable<CTDictionary> entities)
        {
            return LinqExtension.ToDTO<CTDictionary, DictionaryDTO>(entities, ToDTO);
        }

    }
}

