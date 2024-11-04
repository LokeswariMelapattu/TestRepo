using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{   
    public static partial class ConsumedAmountMapper
    {       
        static partial void OnDTO(this CTConsumedAmountResult entity, ConsumedAmountResultDTO dto);
     
        static partial void OnEntity(this ConsumedAmountResultDTO dto, CTConsumedAmountResult entity);
        
        public static CTConsumedAmountResult ToEntity(this ConsumedAmountResultDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTConsumedAmountResult();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
            entity.IS_ACTIVE  = Convert.ToBoolean(dto.IsActive);
            entity.DAILY_USED_AMOUNT = dto.DAILY_USED_AMOUNT;
            entity.YEARLY_USED_AMOUNT = dto.YEARLY_USED_AMOUNT;
            entity.MONTHLY_USED_AMOUNT = dto.MONTHLY_USED_AMOUNT;
            entity.WEEKLY_USED_AMOUNT = dto.WEEKLY_USED_AMOUNT;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            dto.OnEntity(entity);
            return entity;
        }
    
        public static ConsumedAmountResultDTO ToDTO(this CTConsumedAmountResult entity)
        {
            if (entity == null) return null;

            var dto = new ConsumedAmountResultDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.TimeFrequencyDTO = new TokenAppService().GetTimeFrequencyByID((int)entity.TIME_FREQUENCY_ID);
            dto.DAILY_USED_AMOUNT = entity.DAILY_USED_AMOUNT;
            dto.MONTHLY_USED_AMOUNT = entity.MONTHLY_USED_AMOUNT;
            dto.WEEKLY_USED_AMOUNT = entity.WEEKLY_USED_AMOUNT;
            dto.YEARLY_USED_AMOUNT = entity.YEARLY_USED_AMOUNT;
            dto.ProductCategoryID = entity.PRODUCT_CATEGORY_ID;
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<CTConsumedAmountResult> ToEntities(this IEnumerable<ConsumedAmountResultDTO> dtos)
        {
            return LinqExtension.ToEntity<CTConsumedAmountResult, ConsumedAmountResultDTO>(dtos, ToEntity);
        }

        public static List<ConsumedAmountResultDTO> ToDTOs(this IEnumerable<CTConsumedAmountResult> entities)
        {
            return LinqExtension.ToDTO<CTConsumedAmountResult, ConsumedAmountResultDTO>(entities, ToDTO);
        }
    }
}






