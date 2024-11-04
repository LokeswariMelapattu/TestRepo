using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTBeneficiarySegmentMapper
    {

        static partial void OnEntity(this BeneficiarySegmentDTO dto, CTBeneficiarySegmentDTO entity);

        public static CTBeneficiarySegmentDTO ToEntity(this BeneficiarySegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBeneficiarySegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.FromDOB = dto.FromDOB;
            entity.ToDOB = dto.ToDOB;
            entity.IsVIP = Convert.ToInt16(dto.IsVIP);
            entity.NationalityID = dto.NationalityID;
            entity.HasDisability = Convert.ToInt16(dto.HasDisability);
            entity.IsActive = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTBeneficiarySegmentDTO> ToEntities(this IEnumerable<BeneficiarySegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBeneficiarySegmentDTO, BeneficiarySegmentDTO>(dtos, ToEntity);

        }
    }
}