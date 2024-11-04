using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
  public static partial  class VehicleRegisterSearchMapper
    {
        static partial void OnDTO(this CTVehicleRegisterSearchResult entity, VehicleRegisterSearchResultDTO dto);

        static partial void OnEntity(this VehicleRegisterSearchResultDTO dto, CTVehicleRegisterSearchResult entity);

        public static CTVehicleRegisterSearchResult ToEntity(this VehicleRegisterSearchResultDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTVehicleRegisterSearchResult();

            entity.VEHICLE_REGISTER_ID = dto.VehicleRegisterID;
            entity.MAKE_ID = dto.MakeID;
            entity.MAKE_NAME_EN = dto.MakeNameEn;
            entity.MAKE_NAME_AR = dto.MakeNameAr;
            entity.MODEL_ID = dto.ModelID;
            entity.MODEL_NAME_EN = dto.ModelNameEn;
            entity.MODEL_NAME_AR = dto.ModelNameAr;
            entity.YEAR = dto.Year;
            entity.CC = dto.Cc;
            entity.FUEL_INLET = dto.FuelInlet;
            entity.FUEL_CAPACITY = dto.FuelCapacity; 


            dto.OnEntity(entity);

            return entity;
        }

        public static VehicleRegisterSearchResultDTO ToDTO(this CTVehicleRegisterSearchResult entity)
        {
            if (entity == null) return null;

            var dto = new VehicleRegisterSearchResultDTO();

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

        public static List<CTVehicleRegisterSearchResult> ToEntities(this IEnumerable<VehicleRegisterSearchResultDTO> dtos)
        {
            return LinqExtension.ToEntity<CTVehicleRegisterSearchResult, VehicleRegisterSearchResultDTO>(dtos, ToEntity);
        }

        public static List<VehicleRegisterSearchResultDTO> ToDTOs(this IEnumerable<CTVehicleRegisterSearchResult> entities)
        {
            return LinqExtension.ToDTO<CTVehicleRegisterSearchResult, VehicleRegisterSearchResultDTO>(entities, ToDTO);
        }
    }
}
