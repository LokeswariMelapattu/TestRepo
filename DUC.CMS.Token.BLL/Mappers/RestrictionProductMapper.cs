using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class RestrictionProductMapper
    {
       
        static partial void OnDTO(this CTRestrictionGroupProduct entity, RestrictionProductDTO dto);
      
        static partial void OnEntity(this RestrictionProductDTO dto, RESTRICTION_GROUP_PRODUCT entity);

        public static RESTRICTION_GROUP_PRODUCT ToEntity(this RestrictionProductDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_PRODUCT();
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.PRODUCT_ID = dto.ProductID;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;              

            dto.OnEntity(entity);

            return entity;
        }
     
        public static RestrictionProductDTO ToDTO(this CTRestrictionGroupProduct entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionProductDTO();
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.ProductID = entity.PRODUCT_ID;
            dto.ProductName = entity.PRODUCT_EN_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.ProductNameAr = entity.PRODUCT_AR_NAME;
            dto.ProductCategoryID = Convert.ToInt32(entity.PRODUCT_CATEGORY_ID);
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<RESTRICTION_GROUP_PRODUCT> ToEntities(this IEnumerable<RestrictionProductDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_PRODUCT, RestrictionProductDTO>(dtos, ToEntity);
        }

        public static List<RestrictionProductDTO> ToDTOs(this IEnumerable<CTRestrictionGroupProduct> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupProduct, RestrictionProductDTO>(entities, ToDTO);
        }

    }
}
