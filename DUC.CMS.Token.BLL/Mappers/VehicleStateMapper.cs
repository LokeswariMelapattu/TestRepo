using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleStateMapper
    {
        static partial void OnDTO(this VEHICLE_STATE entity, VehicleStateDTO dto);

        static partial void OnEntity(this VehicleStateDTO dto, VEHICLE_STATE entity);

        public static VEHICLE_STATE ToEntity(this VehicleStateDTO dto)
        {
            if (dto == null) return null;

            var entity = new VEHICLE_STATE();

            entity.VEHICLE_STATE_ID = dto.VehicleStateID;
            entity.EN_STATE = dto.NameEN;
            entity.AR_STATE = dto.NameAR;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        public static VehicleStateDTO ToDTO(this VEHICLE_STATE entity)
        {
            if (entity == null) return null;

            var dto = new VehicleStateDTO();

            dto.VehicleStateID = entity.VEHICLE_STATE_ID;
            dto.NameEN = entity.EN_STATE;
            dto.NameAR = entity.AR_STATE;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<VEHICLE_STATE> ToEntities(this IEnumerable<VehicleStateDTO> dtos)
        {
            return LinqExtension.ToEntity<VEHICLE_STATE, VehicleStateDTO>(dtos, ToEntity);
        }

        public static List<VehicleStateDTO> ToDTOs(this IEnumerable<VEHICLE_STATE> entities)
        {
            return LinqExtension.ToDTO<VEHICLE_STATE, VehicleStateDTO>(entities, ToDTO);
        }
    }
}
