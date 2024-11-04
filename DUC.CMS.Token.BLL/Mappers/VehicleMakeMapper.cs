using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class VehicleMakeMapper
    {
        static partial void OnDTO(this VEHICLE_MAKE entity, VehicleMakeDTO dto);

        static partial void OnEntity(this VehicleMakeDTO dto, VEHICLE_MAKE entity);

        public static VEHICLE_MAKE ToEntity(this VehicleMakeDTO dto)
        {
            if (dto == null) return null;

            var entity = new VEHICLE_MAKE();
            entity.VEHICLE_MAKE_ID = dto.VehicleMakeID;
            entity.AR_NAME = dto.ArName;
            entity.EN_NAME = dto.EnName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }

        public static VehicleMakeDTO ToDTO(this VEHICLE_MAKE entity)
        {
            if (entity == null) return null;

            var dto = new VehicleMakeDTO();

            dto.VehicleMakeID = entity.VEHICLE_MAKE_ID;
            dto.ArName = entity.AR_NAME;
            dto.EnName = entity.EN_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<VEHICLE_MAKE> ToEntities(this IEnumerable<VehicleMakeDTO> dtos)
        {
            return LinqExtension.ToEntity<VEHICLE_MAKE, VehicleMakeDTO>(dtos, ToEntity);
        }

        public static List<VehicleMakeDTO> ToDTOs(this IEnumerable<VEHICLE_MAKE> entities)
        {
            return LinqExtension.ToDTO<VEHICLE_MAKE, VehicleMakeDTO>(entities, ToDTO);
        }
    }
}








