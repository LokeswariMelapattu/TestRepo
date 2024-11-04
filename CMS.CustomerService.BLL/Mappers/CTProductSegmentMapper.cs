using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTProductSegmentMapper
    {
        static partial void OnEntity(this ProductSegmentDTO dto, CTProductSegmentDTO entity);

        public static CTProductSegmentDTO ToEntity(this ProductSegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTProductSegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.ProductID = dto.ProductID;
            entity.StationID = dto.StationID;
            entity.FromHour = new DateTime(0001, 01, 01).AddHours(dto.FromHour);
            entity.ToHour = new DateTime(0001, 01, 01).AddHours(dto.ToHour);
            entity.UpliftDiscount = Convert.ToInt32(dto.UpliftDiscount);
            entity.IsActive = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTProductSegmentDTO> ToEntities(this IEnumerable<ProductSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProductSegmentDTO, ProductSegmentDTO>(dtos, ToEntity);

        }
    }
}