using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleMakeModelMapper
    {
        static partial void OnDTO(this CTVehicleMakeModel entity, VehicleMakeModelDTO dto);

        static partial void OnEntity(this VehicleMakeModelDTO dto, CTVehicleMakeModel entity);

        public static CTVehicleMakeModel ToEntity(this VehicleMakeModelDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTVehicleMakeModel();

            entity.VEHICLE_MAKE_ID = dto.VehicleMakeID;
            entity.Vehicle_Make_Name = dto.VehicleMakeName;
            entity.VEHICLE_MODEL_ID = dto.VehicleModelID;
            entity.Vehicle_Model_Name = dto.VehicleModelName;
            entity.Vehicle_Model_Name_AR = dto.VehicleModelNameAr;
            entity.model_is_active = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }
       
        public static VehicleMakeModelDTO ToDTO(this CTVehicleMakeModel entity)
        {
            if (entity == null) return null;

            var dto = new VehicleMakeModelDTO();

            dto.VehicleMakeID = entity.VEHICLE_MAKE_ID;
            dto.VehicleMakeName = entity.Vehicle_Make_Name;
            dto.VehicleModelID = entity.VEHICLE_MODEL_ID;
            dto.VehicleModelName = entity.Vehicle_Model_Name;
            dto.VehicleModelNameAr = entity.Vehicle_Model_Name_AR;
            dto.IsActive = Convert.ToBoolean(entity.model_is_active);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTVehicleMakeModel> ToEntities(this IEnumerable<VehicleMakeModelDTO> dtos)
        {
            return LinqExtension.ToEntity<CTVehicleMakeModel, VehicleMakeModelDTO>(dtos, ToEntity);
        }

        public static List<VehicleMakeModelDTO> ToDTOs(this IEnumerable<CTVehicleMakeModel> entities)
        {
            return LinqExtension.ToDTO<CTVehicleMakeModel, VehicleMakeModelDTO>(entities, ToDTO);
        }

    }
}









