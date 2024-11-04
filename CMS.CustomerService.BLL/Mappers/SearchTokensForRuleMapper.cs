using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class SearchTokensForRuleMapper
    {
        static partial void OnDTO(this CTSearchTokensForRuleResultDTO entity, SearchTokensForRuleResultDTO dto);

        public static SearchTokensForRuleResultDTO ToDTO(this CTSearchTokensForRuleResultDTO entity)
        {
            if (entity == null) return null;

            var dto = new SearchTokensForRuleResultDTO();
            dto.RuleID = entity.RuleID;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.TokenCode = entity.TokenCode;
            dto.TokenName = entity.TokenName;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.TokenType = entity.TokenType;
            dto.TokenSerial = entity.TokenSerial;
            dto.OnlineDPID = entity.OnlineDPID;
            dto.OnlineDPName = entity.OnlineDPName;
            dto.EOMDPID = entity.EOMDPID;
            dto.EOMDPName = entity.EOMDPName;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<SearchTokensForRuleResultDTO> ToDTOs(this IEnumerable<CTSearchTokensForRuleResultDTO> entities)
        {
            return LinqExtension.ToDTO<CTSearchTokensForRuleResultDTO, SearchTokensForRuleResultDTO>(entities, ToDTO);
        }  
    }
}
