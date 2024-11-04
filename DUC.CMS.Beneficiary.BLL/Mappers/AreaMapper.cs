using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class AreaMapper
    {
        static partial void OnDTO(this AREA entity, AreaDTO dto);

        static partial void OnEntity(this AreaDTO dto, AREA entity);

        public static AREA ToEntity(this AreaDTO dto)
        {
            if (dto == null) return null;

            var entity = new AREA();

            entity.AREA_ID = dto.AreaID;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.EN_NAME = dto.EnName;

            dto.OnEntity(entity);

            return entity;
        }

        public static AreaDTO ToDTO(this AREA entity)
        {
            if (entity == null) return null;

            var dto = new AreaDTO();
            dto.AreaID = entity.AREA_ID;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1 ? true : false;
            dto.EnName = entity.EN_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<AREA> ToEntities(this IEnumerable<AreaDTO> dtos)
        {
            return LinqExtension.ToEntity<AREA, AreaDTO>(dtos, ToEntity);
        }

        public static List<AreaDTO> ToDTOs(this IEnumerable<AREA> entities)
        {
            return LinqExtension.ToDTO<AREA, AreaDTO>(entities, ToDTO);
        }

    }
}

