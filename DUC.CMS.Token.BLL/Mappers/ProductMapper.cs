using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class ProductMapper
    {
        static partial void OnDTO(this PRODUCT entity, ProductDTO dto);

        public static ProductDTO ToDTO(this PRODUCT entity)
        {
            if (entity == null) return null;

            var dto = new ProductDTO();

            dto.ProductID = entity.PRODUCT_ID;
            dto.ProductEnName = entity.EN_NAME;
            dto.ProductArName = entity.AR_NAME;
            dto.UnitPrice = entity.UNIT_PRICE;
            dto.IsDry = Convert.ToBoolean(entity.IS_DRY);
            dto.IsActive =  Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            dto.ColorCode = entity.COLOR_CODE;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<ProductDTO> ToDTOs(this IEnumerable<PRODUCT> entities)
        {
            return LinqExtension.ToDTO<PRODUCT, ProductDTO>(entities, ToDTO);
        }
    }
}
