using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class RestrictionSummaryMapper
    {
        static partial void OnDTO(this CTRestrictionSummary entity, RestrictionSummaryDTO dto);

        static partial void OnEntity(this RestrictionSummaryDTO dto, CTRestrictionSummary entity);

        public static CTRestrictionSummary ToEntity(this RestrictionSummaryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRestrictionSummary();

            entity.ID = dto.ID;
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.Name = dto.Name;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            
            dto.OnEntity(entity);

            return entity;
        }

        public static RestrictionSummaryDTO ToDTO(this CTRestrictionSummary entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionSummaryDTO();

            dto.ID = entity.ID;
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.Name = entity.Name;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTRestrictionSummary> ToEntities(this IEnumerable<RestrictionSummaryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRestrictionSummary, RestrictionSummaryDTO>(dtos, ToEntity);
        }

        public static List<RestrictionSummaryDTO> ToDTOs(this IEnumerable<CTRestrictionSummary> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionSummary, RestrictionSummaryDTO>(entities, ToDTO);
        }
    }
}
