using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTAccountSegmentMapper
    {

        static partial void OnEntity(this AccountSegmentDTO dto, CTAccountSegmentDTO entity);

        public static CTAccountSegmentDTO ToEntity(this AccountSegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTAccountSegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.CustomerCode = dto.CustomerCode;
            entity.IsPremium =Convert.ToInt16(dto.IsPremium);
            entity.AccountTypeID = dto.AccountTypeID;
            entity.EmiratesID = dto.EmiratesID;           
            entity.FamilyID = entity.FamilyID;
            entity.IsActive =Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }
    }
}