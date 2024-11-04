using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class ProductSegmentMapper
    {
        static partial void OnDTO(this CTProductSegmentDTO entity, ProductSegmentDTO dto);

        public static ProductSegmentDTO ToDTO(this CTProductSegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new ProductSegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.ProductID = entity.ProductID;
            dto.StationID = entity.StationID;
            dto.FromHour = int.Parse(entity.FromHour.ToString("hh"));
            dto.ToHour = int.Parse(entity.ToHour.ToString("hh"));
            dto.UpliftDiscount = entity.UpliftDiscount;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<ProductSegmentDTO> ToDTOs(this IEnumerable<CTProductSegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTProductSegmentDTO, ProductSegmentDTO>(entities, ToDTO);
        }
    }
}
