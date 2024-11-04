using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
   public static partial class DepotMapper
    {
        static partial void OnDTO(this DEPOT entity, DepotDTO dto);

        public static DepotDTO ToDTO(this DEPOT entity)
        {
            if (entity == null) return null;

            var dto = new DepotDTO();
            dto.DEPOT_ID = entity.DEPOT_ID;
            dto.LOCATION_ID = entity.LOCATION_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.LAST_UPDATED_USER_ID = entity.LAST_UPDATED_USER_ID;
            dto.LAST_UPDATED_DATE = entity.LAST_UPDATED_DATE;
            dto.AR_NAME = entity.AR_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<DepotDTO> ToDTOs(this IEnumerable<DEPOT> entities)
        {
            return LinqExtension.ToDTO<DEPOT, DepotDTO>(entities, ToDTO);
        }
    }
}
