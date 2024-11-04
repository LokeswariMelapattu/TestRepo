using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class FamilySegmentMapper
    {
        static partial void OnDTO(this CTFamilySegmentDTO entity, FamilySegmentDTO dto);

        public static FamilySegmentDTO ToDTO(this CTFamilySegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new FamilySegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.FamilyID = entity.FamilyID;
            dto.IsFirstVehicleOnly = entity.IsFirstVehicleOnly;
            dto.IsActive = entity.IsActive;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<FamilySegmentDTO> ToDTOs(this IEnumerable<CTFamilySegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTFamilySegmentDTO, FamilySegmentDTO>(entities, ToDTO);
        }
    }
}
