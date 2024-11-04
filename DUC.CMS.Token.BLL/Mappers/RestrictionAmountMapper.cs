using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{   
    public static partial class RestrictionAmountMapper
    {       
        static partial void OnDTO(this RESTRICTION_GROUP_AMOUNT entity, RestrictionAmountDTO dto);
     
        static partial void OnEntity(this RestrictionAmountDTO dto, RESTRICTION_GROUP_AMOUNT entity);
        
        public static RESTRICTION_GROUP_AMOUNT ToEntity(this RestrictionAmountDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_AMOUNT();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
            entity.ALLOWED_AMOUNT = dto.AllowedAmount;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            // dto.ProductCategoryID = Convert.ToInt32(entity.PRODUCT_CATEGORY_ID);
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
           
            dto.OnEntity(entity);

            return entity;
        }
    
        public static RestrictionAmountDTO ToDTO(this RESTRICTION_GROUP_AMOUNT entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionAmountDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.AllowedAmount = entity.ALLOWED_AMOUNT;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.TimeFrequencyDTO = new TokenAppService().GetTimeFrequencyByID((int)entity.TIME_FREQUENCY_ID);
            dto.ProductCategoryID = Convert.ToInt32(entity.PRODUCT_CATEGORY_ID);
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<RESTRICTION_GROUP_AMOUNT> ToEntities(this IEnumerable<RestrictionAmountDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_AMOUNT, RestrictionAmountDTO>(dtos, ToEntity);
        }

        public static List<RestrictionAmountDTO> ToDTOs(this IEnumerable<RESTRICTION_GROUP_AMOUNT> entities)
        {
            return LinqExtension.ToDTO<RESTRICTION_GROUP_AMOUNT, RestrictionAmountDTO>(entities, ToDTO);
        }
    }
}






