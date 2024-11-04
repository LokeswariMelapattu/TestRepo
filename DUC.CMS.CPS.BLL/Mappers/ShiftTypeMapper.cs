using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class ShiftTypeMapper
    {
        static partial void OnDTO(this SHIFT_TYPE entity, ShiftTypeDTO dto);

        static partial void OnEntity(this ShiftTypeDTO dto, SHIFT_TYPE entity);

        public static SHIFT_TYPE ToEntity(this ShiftTypeDTO dto)
        {
            if (dto == null) return null;

            var entity = new SHIFT_TYPE();

            entity.SHIFT_TYPE_ID = dto.ShiftTypeID;
            entity.AR_NAME = dto.ArName;
            entity.EN_NAME = dto.ENName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static ShiftTypeDTO ToDTO(this SHIFT_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new ShiftTypeDTO();
            dto.ShiftTypeID = entity.SHIFT_TYPE_ID;
            dto.ArName = entity.AR_NAME;
            dto.ENName = entity.EN_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<SHIFT_TYPE> ToEntities(this IEnumerable<ShiftTypeDTO> dtos)
        {
            return LinqExtension.ToEntity<SHIFT_TYPE, ShiftTypeDTO>(dtos, ToEntity);
        }

        public static List<ShiftTypeDTO> ToDTOs(this IEnumerable<SHIFT_TYPE> entities)
        {
            return LinqExtension.ToDTO<SHIFT_TYPE, ShiftTypeDTO>(entities, ToDTO);
        }
    }
}

