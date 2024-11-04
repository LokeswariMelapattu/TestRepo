using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class BaseMapper
    {
        static partial void OnDTO(this CTBase entity, BaseDTO dto);

        static partial void OnEntity(this BaseDTO dto, CTBase entity);

        public static CTBase ToEntity(this BaseDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBase();
            entity.LastLocationID = dto.LastUpdatedLocationID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastUpdateDate = dto.LastUpdatedDate;

            dto.OnEntity(entity);

            return entity;
        }

        public static BaseDTO ToDTO(this CTBase entity)
        {
            if (entity == null) return null;

            var dto = new BaseDTO();

            dto.LastUpdatedUserId = entity.LastUserID;
            dto.LastUpdatedDate = entity.LastUpdateDate;
            dto.LastUpdatedLocationID = entity.LastLocationID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTBase> ToEntities(this IEnumerable<BaseDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBase, BaseDTO>(dtos, ToEntity);
        }

        public static List<BaseDTO> ToDTOs(this IEnumerable<CTBase> entities)
        {
            return LinqExtension.ToDTO<CTBase, BaseDTO>(entities, ToDTO);
        }
    }
}
