using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class ShiftMapper
    {
        static partial void OnDTO(this CTSHIFT entity, ShiftDTO dto);

        static partial void OnEntity(this ShiftDTO dto, CTSHIFT entity);

        public static CTSHIFT ToEntity(this ShiftDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSHIFT();

            entity.SHIFT_ID = dto.ShiftID;
            entity.SHIFT_TYPE_ID = dto.ShiftTypeID;
            entity.SHIFT_TYPE = dto.ShiftType;
            entity.SHIFT_STATUS_ID = dto.ShiftStatusID;
            entity.SHIFT_STATUS = dto.ShiftStatus;
            entity.USER_ID = dto.UserID;
            entity.USER_NAME = dto.User;
            entity.LOCATION_ID = dto.LocationID;
            entity.LOCATION_NAME = dto.Location;
            entity.START_DATETIME = dto.StartDateTime;
            entity.END_DATETIME = dto.EndDateTime;

            dto.OnEntity(entity);

            return entity;
        }

        public static ShiftDTO ToDTO(this CTSHIFT entity)
        {
            if (entity == null) return null;

            var dto = new ShiftDTO();

            dto.ShiftID = entity.SHIFT_ID;
            dto.ShiftTypeID = entity.SHIFT_TYPE_ID;
            dto.ShiftType = entity.SHIFT_TYPE;
            dto.ShiftStatusID = entity.SHIFT_STATUS_ID;
            dto.ShiftStatus = entity.SHIFT_STATUS;
            dto.UserID = entity.USER_ID;
            dto.User = entity.USER_NAME;
            dto.LocationID = entity.LOCATION_ID;
            dto.Location = entity.LOCATION_NAME;
            dto.StartDateTime = entity.START_DATETIME;
            dto.EndDateTime = entity.END_DATETIME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTSHIFT> ToEntities(this IEnumerable<ShiftDTO> dtos)
        {
            return LinqExtension.ToEntity<CTSHIFT, ShiftDTO>(dtos, ToEntity);
        }

        public static List<ShiftDTO> ToDTOs(this IEnumerable<CTSHIFT> entities)
        {
            return LinqExtension.ToDTO<CTSHIFT, ShiftDTO>(entities, ToDTO);
        }
    }
}

