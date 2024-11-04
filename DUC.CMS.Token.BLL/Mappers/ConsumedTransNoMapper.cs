using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{   
    public static partial class ConsumedTransNoMapper
    {       
        static partial void OnDTO(this CTConsumedTransNoResult entity, ConsumedTransNoResultDTO dto);
     
        static partial void OnEntity(this ConsumedTransNoResultDTO dto, CTConsumedTransNoResult entity);
        
        public static CTConsumedTransNoResult ToEntity(this ConsumedTransNoResultDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTConsumedTransNoResult();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
            entity.NUMBER_OF_DAYS = dto.NumberOfDays;
            entity.NUMBER_OF_TRANSACTIONS =dto.NumberOfTransactions;
            entity.IS_ACTIVE = Convert.ToInt32(dto.IsActive);
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            dto.OnEntity(entity);

            return entity;
        }
    
        public static ConsumedTransNoResultDTO ToDTO(this CTConsumedTransNoResult entity)
        {
            if (entity == null) return null;

            var dto = new ConsumedTransNoResultDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.NumberOfDays = entity.NUMBER_OF_DAYS;
            dto.NumberOfTransactions = entity.NUMBER_OF_TRANSACTIONS;
            dto.IsActive =Convert.ToBoolean( entity.IS_ACTIVE);
            dto.ProductCategoryID = entity.PRODUCT_CATEGORY_ID;
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<CTConsumedTransNoResult> ToEntities(this IEnumerable<ConsumedTransNoResultDTO> dtos)
        {
            return LinqExtension.ToEntity<CTConsumedTransNoResult, ConsumedTransNoResultDTO>(dtos, ToEntity);
        }

        public static List<ConsumedTransNoResultDTO> ToDTOs(this IEnumerable<CTConsumedTransNoResult> entities)
        {
            return LinqExtension.ToDTO<CTConsumedTransNoResult, ConsumedTransNoResultDTO>(entities, ToDTO);
        }
    }
}






