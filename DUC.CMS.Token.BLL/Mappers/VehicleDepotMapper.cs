using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class VehicleDepotMapper
    {
       
        static partial void OnDTO(this DEPOT entity, VehicleDepotDTO dto);

        static partial void OnEntity(this VehicleDepotDTO dto, DEPOT entity);

        public static DEPOT ToEntity(this VehicleDepotDTO dto)
        {
            if (dto == null) return null;

            var entity = new DEPOT();

            entity.DEPOT_ID = dto.VEHICLE_DEPOT_ID;
            entity.AR_NAME = dto.AR_NAME;
            entity.EN_NAME = dto.EN_NAME;
            entity.IS_ACTIVE = dto.IS_ACTIVE;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }
       
        public static VehicleDepotDTO ToDTO(this DEPOT entity)
        {
            if (entity == null) return null;

            var dto = new VehicleDepotDTO();

            dto.VEHICLE_DEPOT_ID = entity.DEPOT_ID;
            dto.AR_NAME = entity.AR_NAME;
            dto.EN_NAME = entity.EN_NAME;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<DEPOT> ToEntities(this IEnumerable<VehicleDepotDTO> dtos)
        {
            return LinqExtension.ToEntity<DEPOT, VehicleDepotDTO>(dtos, ToEntity);
        }

        public static List<VehicleDepotDTO> ToDTOs(this IEnumerable<DEPOT> entities)
        {
            return LinqExtension.ToDTO<DEPOT, VehicleDepotDTO>(entities, ToDTO);
        }

    }
}
