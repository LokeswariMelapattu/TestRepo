using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{   
    public static partial class ConsumedQuantityMapper
    {       
        static partial void OnDTO(this CTConsumedQuantityResult entity, ConsumedQuantityResultDTO dto);
     
        static partial void OnEntity(this ConsumedQuantityResultDTO dto, CTConsumedQuantityResult entity);
        
        public static CTConsumedQuantityResult ToEntity(this ConsumedQuantityResultDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTConsumedQuantityResult();
            

        entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
        entity.PRODUCT_ID = dto.AllowedProductID;
            entity.IS_ACTIVE = Convert.ToInt32(dto.IsActive);
            entity.PRODUCT_EN_NAME = dto.AllowedProductName;
            entity.PRODUCT_AR_NAME = dto.AllowedProductNameAr;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            entity.ALLOWED_QUANTITY = dto.AllowedQuantity;
           
            dto.OnEntity(entity);

            return entity;
        }
    
        public static ConsumedQuantityResultDTO ToDTO(this CTConsumedQuantityResult entity)
        {
            if (entity == null) return null;

            var dto = new ConsumedQuantityResultDTO();
            dto.ProductCategoryID = entity.PRODUCT_CATEGORY_ID;
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.AllowedProductID = entity.PRODUCT_ID;
            dto.AllowedQuantity = entity.ALLOWED_QUANTITY;
            dto.AllowedProductNameAr = entity.PRODUCT_AR_NAME;
            dto.AllowedProductName = entity.PRODUCT_EN_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.TimeFrequencyDTO = new TokenAppService().GetTimeFrequencyByID((int)entity.TIME_FREQUENCY_ID);
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<CTConsumedQuantityResult> ToEntities(this IEnumerable<ConsumedQuantityResultDTO> dtos)
        {
            return LinqExtension.ToEntity<CTConsumedQuantityResult, ConsumedQuantityResultDTO>(dtos, ToEntity);
        }

        public static List<ConsumedQuantityResultDTO> ToDTOs(this IEnumerable<CTConsumedQuantityResult> entities)
        {
            return LinqExtension.ToDTO<CTConsumedQuantityResult, ConsumedQuantityResultDTO>(entities, ToDTO);
        }
    }
}






