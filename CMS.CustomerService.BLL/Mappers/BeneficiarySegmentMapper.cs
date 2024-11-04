using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class BeneficiarySegmentMapper
    {
        static partial void OnDTO(this CTBeneficiarySegmentDTO entity, BeneficiarySegmentDTO dto);

        public static BeneficiarySegmentDTO ToDTO(this CTBeneficiarySegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiarySegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.FromDOB = entity.FromDOB;
            dto.ToDOB = entity.ToDOB;
            dto.IsVIP = Convert.ToBoolean(entity.IsVIP);
            dto.NationalityID = entity.NationalityID;
            dto.HasDisability = Convert.ToBoolean(entity.HasDisability);
            dto.IsActive = Convert.ToBoolean(entity.IsActive);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<BeneficiarySegmentDTO> ToDTOs(this IEnumerable<CTBeneficiarySegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTBeneficiarySegmentDTO, BeneficiarySegmentDTO>(entities, ToDTO);
        }
    }
}
