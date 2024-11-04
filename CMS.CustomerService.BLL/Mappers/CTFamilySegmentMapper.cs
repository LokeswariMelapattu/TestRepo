using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTFamilySegmentMapper
    {
        static partial void OnEntity(this FamilySegmentDTO dto, CTFamilySegmentDTO entity);

        public static CTFamilySegmentDTO ToEntity(this FamilySegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTFamilySegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.FamilyID = dto.FamilyID;
            entity.IsFirstVehicleOnly = dto.IsFirstVehicleOnly;
            entity.IsActive = dto.IsActive;

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTFamilySegmentDTO> ToEntities(this IEnumerable<FamilySegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTFamilySegmentDTO, FamilySegmentDTO>(dtos, ToEntity);

        }
    }
}