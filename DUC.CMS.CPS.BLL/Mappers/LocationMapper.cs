using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class LocationMapper
    {
        static partial void OnDTO(this LOCATION entity, LocationDTO dto);

        public static LocationDTO ToDTO(this LOCATION entity)
        {
            if (entity == null) return null;

            var dto = new LocationDTO();

            dto.LocationID = entity.LOCATION_ID;
            dto.LocationNameAR= entity.LOCATION_AR_SHORT_NAME;
            dto.LocationNameEN = entity.LOCATION_EN_SHORT_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<LocationDTO> ToDTOs(this IEnumerable<LOCATION> entities)
        {
            return LinqExtension.ToDTO<LOCATION, LocationDTO>(entities, ToDTO);
        }
    }
}
