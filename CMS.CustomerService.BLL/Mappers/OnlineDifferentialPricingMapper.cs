using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class OnlineDifferentialPricingMapper
    {
        static partial void OnDTO(this CTOnlineDifferentialPricingDTO entity, OnlineDifferentialPricingDTO dto);

        public static OnlineDifferentialPricingDTO ToDTO(this CTOnlineDifferentialPricingDTO entity)
        {
            if (entity == null) return null;

            var dto = new OnlineDifferentialPricingDTO();
            dto.RuleID = entity.RuleID;
            dto.RuleName = entity.RuleName;
            dto.Description = entity.Description;
            dto.IsRuleDisabled = Convert.ToBoolean(entity.IsRuleDisabled);
            dto.ValidFrom = entity.ValidFrom;
            dto.ValidTo = entity.ValidTo;
            dto.ProductSegment = new CustomerAppService().GetProductSegments(entity.RuleID);
            dto.AccountSegment = new CustomerAppService().GetAccountSegment(entity.RuleID);
            dto.BeneficiarySegment = new CustomerAppService().GetBeneficiarySegment(entity.RuleID);
            dto.TokenSegment = new CustomerAppService().GetTokenSegment(entity.RuleID);
            dto.IsActive =Convert.ToBoolean(entity.IsActive);
            dto.LastUpdatedUSerID = entity.LastUpdatedUSerID;
            dto.LastUpdatedDate = entity.LastUpdatedDate;
            dto.LastUpdatedLocationID = entity.LastUpdatedLocationID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<OnlineDifferentialPricingDTO> ToDTOs(this IEnumerable<CTOnlineDifferentialPricingDTO> entities)
        {
            return LinqExtension.ToDTO<CTOnlineDifferentialPricingDTO, OnlineDifferentialPricingDTO>(entities, ToDTO);
        }    

        static partial void OnEntity(this OnlineDifferentialPricingDTO dto, CTOnlineDifferentialPricingDTO entity);

        public static CTOnlineDifferentialPricingDTO ToEntity(this OnlineDifferentialPricingDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTOnlineDifferentialPricingDTO();

            entity.RuleID = dto.RuleID;
            entity.RuleName = dto.RuleName;
            entity.Description = dto.Description;
            entity.IsRuleDisabled =  Convert.ToInt16(dto.IsRuleDisabled);
            entity.ValidFrom = dto.ValidFrom;
            entity.ValidTo = dto.ValidTo;
            entity.IsActive = Convert.ToInt16(dto.IsActive);
            entity.LastUpdatedUSerID = dto.LastUpdatedUSerID;
            entity.LastUpdatedDate = dto.LastUpdatedDate;
            entity.LastUpdatedLocationID = dto.LastUpdatedLocationID;
            
            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTOnlineDifferentialPricingDTO> ToEntities(this IEnumerable<OnlineDifferentialPricingDTO> dtos)
        {
            return LinqExtension.ToEntity<CTOnlineDifferentialPricingDTO, OnlineDifferentialPricingDTO>(dtos, ToEntity);
        }
    }
}
