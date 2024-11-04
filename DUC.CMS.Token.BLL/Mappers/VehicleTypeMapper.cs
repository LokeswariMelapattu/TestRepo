using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleTypeMapper
    {
        static partial void OnDTO(this VEHICLE_TYPE entity, VehicleTypesDTO dto);

        static partial void OnEntity(this VehicleTypesDTO dto, VEHICLE_TYPE entity);

        public static VEHICLE_TYPE ToEntity(this VehicleTypesDTO dto)
        {
            if (dto == null) return null;

            var entity = new VEHICLE_TYPE();

            entity.VEHICLE_TYPE_ID = dto.VehicleTypeID;
            entity.CODE = dto.Code;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }
        
        public static VehicleTypesDTO ToDTO(this VEHICLE_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new VehicleTypesDTO();

            dto.VehicleTypeID = (int)entity.VEHICLE_TYPE_ID; 
            dto.Code = entity.CODE;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<VEHICLE_TYPE> ToEntities(this IEnumerable<VehicleTypesDTO> dtos)
        {
            return LinqExtension.ToEntity<VEHICLE_TYPE, VehicleTypesDTO>(dtos, ToEntity);
        }

        public static List<VehicleTypesDTO> ToDTOs(this IEnumerable<VEHICLE_TYPE> entities)
        {
            return LinqExtension.ToDTO<VEHICLE_TYPE, VehicleTypesDTO>(entities, ToDTO);
        }
    }
}












