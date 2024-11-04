using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using System;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleInfoMapper
    {
        static partial void OnDTO(this CTVehicleInfo entity, VehicleInfoDTO dto);
        static partial void OnMDTO(this VEHICLE_INFO_DUMMY entity, VehicleDummyInfoDTO dto);

        static partial void OnEntity(this VehicleInfoDTO dto, VEHICLE_INFO entity);

        public static VEHICLE_INFO ToEntity(this VehicleInfoDTO dto)
        {
            if (dto == null) return null;

            var entity = new VEHICLE_INFO();

            entity.VEHICLE_INFO_ID = dto.VehicleInfoID == null ? -1 : (int)dto.VehicleInfoID;
            entity.PLATE_NUMBER = dto.PlateNumber;
            entity.COLOR_ID = dto.ColorID;
            entity.STATE_ID = dto.StateID;
            entity.CHASSIS_NUMBER = dto.ChassisNumber;
            entity.ENGINE_NUMBER = dto.EngineNumber;
            entity.PLATE_COLOUR_ID = dto.PlateColorID;
         
            entity.VEHICLE_TYPE_ID = dto.VehicleTypeID;
            entity.IS_ACTIVE = 1;
            entity.PLATE_COLOUR_ID = dto.PlateColorID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
          
            entity.VEHICLE_REGISTER_ID = dto.VehicleRegisterID != null ? dto.VehicleRegisterID :
             new TokenAppService().UpdateVehicleRegister(new VehicleRegister
             {
                 CC = dto.VehicleRegisterDTO.Cc,
                 FuelCapacity = dto.VehicleRegisterDTO.FuelCapacity,
                 FuelInlet = Convert.ToDecimal(dto.VehicleRegisterDTO.FuelInlet),
                 IsActive = (short?)(dto.VehicleRegisterDTO.IsActive == false ? 0 : 1),
                 LastUpdatedDate = dto.VehicleRegisterDTO.LastUpdatedDate,
                 LastUpdatedLocationID = dto.VehicleRegisterDTO.LastUpdatedLocationID,
                 LastUpdatedUserId = dto.VehicleRegisterDTO.LastUpdatedUserId,
                 VehicleMakeId = dto.VehicleRegisterDTO.MakeID,
                 VehicleModelId = dto.VehicleRegisterDTO.ModelID,
                 VehicleRegisterId = dto.VehicleRegisterID,
                 Year = dto.VehicleRegisterDTO.Year
             });
            dto.OnEntity(entity);

            return entity;
        }

        public static VehicleInfoDTO ToDTO(this CTVehicleInfo entity)
        {
            if (entity == null) return null;

            var dto = new VehicleInfoDTO();

            dto.VehicleInfoID = entity.VEHICLE_INFO_ID;
            dto.PlateNumber = entity.PLATE_NUMBER;
            dto.ColorID = entity.COLOR_ID;
            dto.ColorName = entity.VehicleColor;
            dto.StateID = entity.STATE_ID;
            dto.StateName = entity.VehiclStateName;
            dto.ChassisNumber = entity.CHASSIS_NUMBER;
            dto.VehicleRegisterID = entity.VEHICLE_REGISTER_ID;
            dto.VehicleTypeID = entity.VEHICLE_TYPE_ID;
            dto.VehicleTypeName = entity.VehiclTypeName;
            dto.VehicleRegisterID = entity.VEHICLE_REGISTER_ID;
            dto.EngineNumber = entity.ENGINE_NUMBER;
            dto.VehicleRegisterDTO = new TokenAppService().GetVehicleRegisterByID((int)entity.VEHICLE_REGISTER_ID);
            dto.PlateColorID = entity.PLATE_COLOUR_ID;

            entity.OnDTO(dto);

            return dto;
        }
        public static VehicleDummyInfoDTO ToMDTO(this VEHICLE_INFO_DUMMY entity)
        {
            if (entity == null) return null;

            var dto = new VehicleDummyInfoDTO();

            dto.VehicleInfoID = entity.VEHICLE_INFO_ID;
            dto.PlateNumber = entity.PLATE_NUMBER;
            dto.TypeCode = entity.TYPE_CODE;
            dto.MakeNameEN = entity.MAKE_NAME_EN;
            dto.MakeNameAR = entity.MAKE_NAME_AR;
            dto.ModelNameEN = entity.MODEL_NAME_EN;
            dto.ModelNameAR = entity.MODEL_NAME_AR;
            dto.ChassisNumber = entity.CHASSIS_NUMBER;
            dto.EngineNumber = entity.ENGINE_NUMBER;
            dto.Cc = entity.CC;
            dto.Year = entity.VEHICLE_YEAR;
            dto.FuelInlet = entity.FUEL_INLET; 
            dto.FuelCapacity = entity.FUEL_CAPACITY;

            entity.OnMDTO(dto);

            return dto;
        }

        public static List<VEHICLE_INFO> ToEntities(this IEnumerable<VehicleInfoDTO> dtos)
        {
            return LinqExtension.ToEntity<VEHICLE_INFO, VehicleInfoDTO>(dtos, ToEntity);
        }

        public static List<VehicleInfoDTO> ToDTOs(this IEnumerable<CTVehicleInfo> entities)
        {
            return LinqExtension.ToDTO<CTVehicleInfo, VehicleInfoDTO>(entities, ToDTO);
        }
    }
}







