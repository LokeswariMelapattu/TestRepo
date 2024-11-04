using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class EOMDifferentialPricingMapper
    {
        static partial void OnDTO(this CTEOMDifferentialPricingDTO entity, EOMDifferentialPricingDTO dto);

        public static EOMDifferentialPricingDTO ToDTO(this CTEOMDifferentialPricingDTO entity)
        {
            if (entity == null) return null;

            var dto = new EOMDifferentialPricingDTO();
            dto.RuleID = entity.RuleID;
            dto.RuleName = entity.RuleName;
            dto.Description = entity.Description;
            dto.IsRuleDisabled = Convert.ToBoolean(entity.IsRuleDisabled);
            dto.ValidFrom = (DateTime)entity.ValidFrom;
            dto.ValidTo = (DateTime)entity.ValidTo;
            dto.ProductEOMSegment = new CustomerAppService().GetEOMProductSegments(entity.RuleID);
            dto.AccountEOMSegment = new CustomerAppService().GetEOMAccountSegment(entity.RuleID);
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.LastUpdatedUSerID = entity.LastUpdatedUSerID;            
            dto.LastUpdatedLocationID = entity.LastUpdatedLocationID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<EOMDifferentialPricingDTO> ToDTOs(this IEnumerable<CTEOMDifferentialPricingDTO> entities)
        {
            return LinqExtension.ToDTO<CTEOMDifferentialPricingDTO, EOMDifferentialPricingDTO>(entities, ToDTO);
        }

        static partial void OnEntity(this EOMDifferentialPricingDTO dto, CTEOMDifferentialPricingDTO entity);

        public static CTEOMDifferentialPricingDTO ToEntity(this EOMDifferentialPricingDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTEOMDifferentialPricingDTO();

            entity.RuleID = dto.RuleID;
            entity.RuleName = dto.RuleName;
            entity.Description = dto.Description;
            entity.IsRuleDisabled = Convert.ToInt16(dto.IsRuleDisabled);
            entity.ValidFrom = dto.ValidFrom;
            entity.ValidTo = dto.ValidTo;            
            entity.IsActive = Convert.ToInt16(dto.IsActive);
            entity.LastUpdatedUSerID = dto.LastUpdatedUSerID;            
            entity.LastUpdatedLocationID = dto.LastUpdatedLocationID; 

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTEOMDifferentialPricingDTO> ToEntities(this IEnumerable<EOMDifferentialPricingDTO> dtos)
        {
            return LinqExtension.ToEntity<CTEOMDifferentialPricingDTO, EOMDifferentialPricingDTO>(dtos, ToEntity);
        }
    }
}
