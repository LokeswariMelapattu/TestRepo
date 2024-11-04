using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.BLL.Dtos;
namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class MappedDriverMapper
    {
        static partial void OnDTO(this CTMappedDriver entity, MappedDriverDTO dto);

        static partial void OnEntity(this MappedDriverDTO dto, CTMappedDriver entity);

        public static CTMappedDriver ToEntity(this MappedDriverDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTMappedDriver();

            entity.TOKEN_ID = dto.TokenID;
            entity.DRIVER_CARD_ID = dto.DriverCardID;
            entity.DriverCardCode = dto.DriverCode;
            entity.DriverCardName = dto.DriverCardName;

            dto.OnEntity(entity);

            return entity;
        }

        public static MappedDriverDTO ToDTO(this CTMappedDriver entity)
        {
            if (entity == null) return null;

            var dto = new MappedDriverDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.DriverCardID = entity.DRIVER_CARD_ID;
            dto.DriverCode = entity.DriverCardCode;
            dto.DriverCardName = entity.DriverCardName;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTMappedDriver> ToEntities(this IEnumerable<MappedDriverDTO> dtos)
        {
            return LinqExtension.ToEntity<CTMappedDriver, MappedDriverDTO>(dtos, ToEntity);
        }

        public static List<MappedDriverDTO> ToDTOs(this IEnumerable<CTMappedDriver> entities)
        {
            return LinqExtension.ToDTO<CTMappedDriver, MappedDriverDTO>(entities, ToDTO);
        }
    }
}