using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class StationMappers
    {
        static partial void OnDTO(this STATION entity, StationDTO dto);

        public static StationDTO ToDTO(this STATION entity)
        {
            if (entity == null) return null;

            var dto = new StationDTO{
            IsActive = entity.IS_ACTIVE,
            Latitude = entity.LATITUDE,
            Longitude = entity.LONGITUDE,
            NameAr = entity.AR_NAME,
            NameEn = entity.EN_NAME,
            StationGroupId=entity.STATION_GROUP_ID,
            StationID = entity.STATION_ID
            };
            entity.OnDTO(dto);

            return dto;
        }

        public static List<StationDTO> ToDTOs(this IEnumerable<STATION> entities)
        {
            return LinqExtension.ToDTO<STATION, StationDTO>(entities, ToDTO);
        }
    }
}
