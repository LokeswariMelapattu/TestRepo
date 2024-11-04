using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleRegisterMapper
    {
        static partial void OnDTO(this CTVehicleRegister entity, VehicleRegisterDTO dto);

        static partial void OnEntity(this VehicleRegisterDTO dto, CTVehicleRegister entity);

        public static CTVehicleRegister ToEntity(this VehicleRegisterDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTVehicleRegister();

            entity.VEHICLE_REGISTER_ID = dto.VehicleRegisterID;
            entity.MAKE_ID = dto.MakeID;
            entity.MODEL_ID = dto.ModelID;

            dto.OnEntity(entity);

            return entity;
        }

        static partial void OnCTEntity(this VehicleRegister dto, VEHICLE_REGISTER entity);

        public static VEHICLE_REGISTER ToCTEntity(this VehicleRegister vehicleRegisterDto)
        {
            if (vehicleRegisterDto == null) return null;
            var vehicleRegister = new VEHICLE_REGISTER
            {
                VEHICLE_REGISTER_ID = Convert.ToInt32(vehicleRegisterDto.VehicleRegisterId),
                YEAR = Convert.ToInt32(vehicleRegisterDto.Year),
                CC = vehicleRegisterDto.CC,
                FUEL_INLET = vehicleRegisterDto.FuelInlet,
                FUEL_CAPACITY = vehicleRegisterDto.FuelCapacity,
                IS_ACTIVE = Convert.ToInt16(vehicleRegisterDto.IsActive),
                LAST_UPDATED_USER_ID = vehicleRegisterDto.LastUpdatedUserId,
                LAST_UPDATED_DATE = vehicleRegisterDto.LastUpdatedDate,
                LAST_LOCATION_ID = vehicleRegisterDto.LastUpdatedLocationID
            };
            vehicleRegister.MAKE_ID = Convert.ToInt32(vehicleRegisterDto.VehicleMakeId);
            vehicleRegister.MODEL_ID = Convert.ToInt32(vehicleRegisterDto.VehicleModelId);
            vehicleRegister.INVENTORY_UNIT_TYPE_ID = Convert.ToInt32(vehicleRegisterDto.InventoryUnitTypeId);

            vehicleRegisterDto.OnCTEntity(vehicleRegister);
            return vehicleRegister;
        }

        public static VehicleRegisterDTO ToDTO(this CTVehicleRegister entity)
        {
            if (entity == null) return null;

            var dto = new VehicleRegisterDTO();

            dto.VehicleRegisterID = entity.VEHICLE_REGISTER_ID;
            dto.MakeID = entity.MAKE_ID;
            dto.ModelID = entity.MODEL_ID;
            dto.MakeNameAr = entity.MAKE_NAME_AR;
            dto.MakeNameEn = entity.MAKE_NAME_EN;
            dto.ModelNameAr = entity.MODEL_NAME_AR;
            dto.ModelNameEn = entity.MODEL_NAME_EN;
            dto.Year = entity.YEAR;
            dto.Cc = entity.CC;
            dto.FuelCapacity = entity.FUEL_CAPACITY;
            dto.FuelInlet = entity.FUEL_INLET;
            dto.InventoryUnitTypeNAME = entity.Inventory_Unit_Type_NAME;
            dto.InventoryUnitTypeNAMEAR = entity.Inventory_Unit_Type_NAME_ar;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTVehicleRegister> ToEntities(this IEnumerable<VehicleRegisterDTO> dtos)
        {
            return LinqExtension.ToEntity<CTVehicleRegister, VehicleRegisterDTO>(dtos, ToEntity);
        }

        public static List<VehicleRegisterDTO> ToDTOs(this IEnumerable<CTVehicleRegister> entities)
        {
            return LinqExtension.ToDTO<CTVehicleRegister, VehicleRegisterDTO>(entities, ToDTO);
        }

    }
}











