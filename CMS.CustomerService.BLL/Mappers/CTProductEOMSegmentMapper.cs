using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTProductEOMSegmentMapper
    {
        static partial void OnEntity(this CTProductEOMSegmentDTO dto, ProductEOMSegmentDTO entity);

        public static ProductEOMSegmentDTO ToEntity(this CTProductEOMSegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new ProductEOMSegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.ProductID = dto.ProductID;
            entity.AcountQuota = dto.AcountQuota;
            entity.TokenQuota = dto.TokenQuota;
            entity.TrxPerMonth = dto.TrxPerMonth;
            entity.UpliftDiscount = dto.UpliftDiscount;
            entity.IsActive = Convert.ToBoolean(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static List<ProductEOMSegmentDTO> ToEntities(this IEnumerable<CTProductEOMSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<ProductEOMSegmentDTO, CTProductEOMSegmentDTO>(dtos, ToEntity);

        }
    }
}