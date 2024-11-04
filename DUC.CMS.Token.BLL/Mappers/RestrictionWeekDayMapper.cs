using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
   
    public static partial class RestrictionWeekDayMapper
    {
        
        static partial void OnDTO(this CTRestrictionGroupWeekDay  entity, RestrictionWeekDayDTO dto);
      
        static partial void OnEntity(this RestrictionWeekDayDTO dto, RESTRICTION_GROUP_WEEKDAY entity);
       
        public static RESTRICTION_GROUP_WEEKDAY ToEntity(this RestrictionWeekDayDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_WEEKDAY();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.WEEK_DAY_ID = dto.WeekDayID;

            dto.OnEntity(entity);

            return entity;
        }
      
        public static RestrictionWeekDayDTO ToDTO(this CTRestrictionGroupWeekDay  entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionWeekDayDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.WeekDayID = entity.WEEK_DAY_ID;
            dto.WeekDayEnName = entity.EN_NAME;
            dto.WeekDayArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }
   
        public static List<RESTRICTION_GROUP_WEEKDAY> ToEntities(this IEnumerable<RestrictionWeekDayDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_WEEKDAY, RestrictionWeekDayDTO>(dtos, ToEntity);
        }
      
        public static List<RestrictionWeekDayDTO> ToDTOs(this IEnumerable<CTRestrictionGroupWeekDay > entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupWeekDay , RestrictionWeekDayDTO>(entities, ToDTO);
        }

    }
}
