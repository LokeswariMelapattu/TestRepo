using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehiclePlateColorMapper
    {
        static partial void OnDTO(this VEHICLE_COLOR entity, VehiclePlateColorDTO dto);

        static partial void OnEntity(this VehiclePlateColorDTO dto, VEHICLE_COLOR entity);

        public static VEHICLE_COLOR ToEntity(this VehiclePlateColorDTO dto)
        {
            if (dto == null) return null;

            var entity = new VEHICLE_COLOR();

            entity.VEHICLE_COLOR_ID = dto.VehicleColorID;
            entity.EN_VEHICLE_COLOR = dto.VehicleColorEn;
            entity.AR_VEHICLE_COLOR = dto.VehicleColorAr;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }
       
        public static VehiclePlateColorDTO ToDTO(this VEHICLE_COLOR entity)
        {
            if (entity == null) return null;

            var dto = new VehiclePlateColorDTO();

            dto.VehicleColorID = entity.VEHICLE_COLOR_ID;
            dto.VehicleColorEn = entity.EN_VEHICLE_COLOR;
            dto.VehicleColorAr = entity.AR_VEHICLE_COLOR;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<VEHICLE_COLOR> ToEntities(this IEnumerable<VehiclePlateColorDTO> dtos)
        {
            return LinqExtension.ToEntity<VEHICLE_COLOR, VehiclePlateColorDTO>(dtos, ToEntity);
        }

        public static List<VehiclePlateColorDTO> ToDTOs(this IEnumerable<VEHICLE_COLOR> entities)
        {
            return LinqExtension.ToDTO<VEHICLE_COLOR, VehiclePlateColorDTO>(entities, ToDTO);
        }

    }
}










