using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class AccountSegmentMapper
    {
        static partial void OnDTO(this CTAccountSegmentDTO entity, AccountSegmentDTO dto);

        public static AccountSegmentDTO ToDTO(this CTAccountSegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new AccountSegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.CustomerCode = entity.CustomerCode;
            dto.IsPremium = Convert.ToBoolean(entity.IsPremium);
            dto.AccountTypeID = entity.AccountTypeID;
            dto.EmiratesID = entity.EmiratesID;            
            dto.Family = new CustomerAppService().GetFamilySegment(entity.FamilyID);
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            entity.OnDTO(dto);

            return dto;
        }

        public static List<AccountSegmentDTO> ToDTOs(this IEnumerable<CTAccountSegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTAccountSegmentDTO, AccountSegmentDTO>(entities, ToDTO);
        }
    }
}
