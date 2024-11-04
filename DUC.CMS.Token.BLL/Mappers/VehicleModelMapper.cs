using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleModelMapper
    {
        static partial void OnDTO(this CTVehicleModel entity, VehicleModelDTO dto);


        public static VehicleModelDTO ToDTO(this CTVehicleModel entity)
        {
            if (entity == null) return null;

            var dto = new VehicleModelDTO();

            dto.VehicleModelID = entity.VEHICLE_MODEL_ID;
            dto.ModelEnName = entity.EN_NAME;
            dto.ModelArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);


            entity.OnDTO(dto);

            return dto;
        }

        public static List<VehicleModelDTO> ToDTOs(this IEnumerable<CTVehicleModel> entities)
        {
            return LinqExtension.ToDTO<CTVehicleModel, VehicleModelDTO>(entities, ToDTO);
        }
    }
}

