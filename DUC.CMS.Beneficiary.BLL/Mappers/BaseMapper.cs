using DUC.CMS.Beneficiary.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{
   public static partial class BaseMapper
    {
        static partial void OnDTO(this CTBase entity, BaseDTO dto);

        static partial void OnEntity(this BaseDTO dto, CTBase entity);

        public static CTBase ToEntity(this BaseDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBase();
            entity.LastLocationID = dto.LocationID;
            entity.LastUserID = dto.LastUpdateUser;
            entity.LastUpdateDate = dto.LastUpdateDate;

            dto.OnEntity(entity);

            return entity;
        }

        public static BaseDTO ToDTO(this CTBase entity)
        {
            if (entity == null) return null;

            var dto = new BaseDTO();

            dto.LastUpdateUser = entity.LastUserID;
            dto.LastUpdateDate = entity.LastUpdateDate;
            dto.LocationID = entity.LastLocationID;

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
