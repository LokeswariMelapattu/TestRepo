using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class AccountEOMSegmentMapper
    {
        static partial void OnDTO(this CTAccountEOMSegmentDTO entity, AccountEOMSegmentDTO dto);

        public static AccountEOMSegmentDTO ToDTO(this CTAccountEOMSegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new AccountEOMSegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.CustomerCode = entity.CustomerCode;
            dto.NationalityID = entity.NationalityID;
            dto.ClassificationID = entity.ClassificationID;
            dto.IsActive =  Convert.ToBoolean(entity.IsActive);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<AccountEOMSegmentDTO> ToDTOs(this IEnumerable<CTAccountEOMSegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTAccountEOMSegmentDTO, AccountEOMSegmentDTO>(entities, ToDTO);
        }

        static partial void OnEntity(this AccountEOMSegmentDTO dto, CTAccountEOMSegmentDTO entity);

        public static CTAccountEOMSegmentDTO ToEntity(this AccountEOMSegmentDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTAccountEOMSegmentDTO();
            entity.RuleID = dto.RuleID;
            entity.CustomerCode = dto.CustomerCode;
            entity.NationalityID = dto.NationalityID;
            entity.ClassificationID = dto.ClassificationID;
            entity.IsActive = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTAccountEOMSegmentDTO> ToEntities(this IEnumerable<AccountEOMSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTAccountEOMSegmentDTO, AccountEOMSegmentDTO>(dtos, ToEntity);

        }
    }
}
