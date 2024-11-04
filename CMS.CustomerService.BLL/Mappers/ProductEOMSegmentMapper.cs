using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class ProductEOMSegmentMapper
    {
        static partial void OnDTO(this CTProductEOMSegmentDTO entity, ProductEOMSegmentDTO dto);

        public static ProductEOMSegmentDTO ToDTO(this CTProductEOMSegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new ProductEOMSegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.ProductID = entity.ProductID;
            dto.AcountQuota = entity.AcountQuota;
            dto.TokenQuota = entity.TokenQuota;
            dto.TrxPerMonth = entity.TrxPerMonth;
            dto.UpliftDiscount = entity.UpliftDiscount;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<ProductEOMSegmentDTO> ToDTOs(this IEnumerable<CTProductEOMSegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTProductEOMSegmentDTO, ProductEOMSegmentDTO>(entities, ToDTO);
        }

        static partial void OnEntity(this ProductEOMSegmentDTO dto, CTProductEOMSegmentDTO entity);

        public static CTProductEOMSegmentDTO ToEntity(this ProductEOMSegmentDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTProductEOMSegmentDTO();
            entity.RuleID = dto.RuleID;
            entity.ProductID = dto.ProductID;
            entity.AcountQuota = Convert.ToInt32(dto.AcountQuota);
            entity.TokenQuota = Convert.ToInt32(dto.TokenQuota);
            entity.TrxPerMonth = dto.TrxPerMonth;
            entity.UpliftDiscount = Convert.ToInt32(dto.UpliftDiscount);
            entity.IsActive = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTProductEOMSegmentDTO> ToEntities(this IEnumerable<ProductEOMSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProductEOMSegmentDTO, ProductEOMSegmentDTO>(dtos, ToEntity);
        }

    }
}
