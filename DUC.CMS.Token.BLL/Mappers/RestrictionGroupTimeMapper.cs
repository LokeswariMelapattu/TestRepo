using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class RestrictionGroupTimeMapper
    {

        static partial void OnDTO(this CTRestrictionGroupTime entity, RestrictionGroupTimeDTO dto);

        static partial void OnEntity(this RestrictionGroupTimeDTO dto, RESTRICTION_GROUP_TIME entity);

        public static RESTRICTION_GROUP_TIME ToEntity(this RestrictionGroupTimeDTO dto)
        {
            if (dto == null) return null;
            var entity = new RESTRICTION_GROUP_TIME();
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID.Value;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.TIME_FROM = dto.FromHour;
            entity.TIME_TO = dto.ToHour;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            dto.OnEntity(entity);
            return entity;
        }

        public static RestrictionGroupTimeDTO ToDTO(this CTRestrictionGroupTime entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionGroupTimeDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.FromHour = entity.TIME_FROM;
            dto.ToHour = entity.TIME_TO;
            //dto.IsActive = Convert.ToBoolean(entity.is);
            entity.OnDTO(dto);

            return dto;
        }

        public static List<RESTRICTION_GROUP_TIME> ToEntities(this IEnumerable<RestrictionGroupTimeDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_TIME, RestrictionGroupTimeDTO>(dtos, ToEntity);
        }

        public static List<RestrictionGroupTimeDTO> ToDTOs(this IEnumerable<CTRestrictionGroupTime> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupTime, RestrictionGroupTimeDTO>(entities, ToDTO);
        }

    }
}
