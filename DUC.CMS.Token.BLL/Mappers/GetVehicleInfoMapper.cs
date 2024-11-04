using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class GetVehicleInfoMapper
    {
        static partial void OnDTO(this CTGetVehicleInfo entity, GetVehicleInfoDTO dto);


        public static GetVehicleInfoDTO ToDTO(this CTGetVehicleInfo entity)
        {
            if (entity == null) return null;

            var dto = new GetVehicleInfoDTO();

            dto.Category = entity.Category;
            dto.CC = entity.CC;
            dto.ChassisNumber = entity.ChassisNumber;
            dto.Color = entity.Color;
            dto.FuelCapacity = entity.FuelCapacity;
            dto.FuelInlet = entity.FuelInlet;
            dto.MakeId = entity.MakeId;
            dto.MakeName = entity.MakeName;
            dto.ModelId = entity.ModelId;
            dto.ModelName = entity.ModelName;
            dto.Plate = entity.i;
            dto.TrafficNumber = entity.TrafficNumber;
            dto.VehicleEmirateId = entity.VehicleEmirateId;
            dto.Year = entity.Year;
            dto.YearId = entity.YearId;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<GetVehicleInfoDTO> ToDTOs(this IEnumerable<CTGetVehicleInfo> entities)
        {
            return LinqExtension.ToDTO<CTGetVehicleInfo, GetVehicleInfoDTO>(entities, ToDTO);
        }
    }
}







