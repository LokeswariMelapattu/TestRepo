using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
       
    public static partial class RestrictionTransactionMapper
    {
       
        static partial void OnDTO(this CTRestrictionGroupTrans entity, RestrictionTransactionDTO  dto);

        static partial void OnEntity(this RestrictionTransactionDTO  dto, CTRestrictionGroupTrans entity);
    
        public static CTRestrictionGroupTrans ToEntity(this RestrictionTransactionDTO  dto)
        {
            if (dto == null) return null;

            var entity = new CTRestrictionGroupTrans();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.MAXIMUM_TRANSACTION_AMOUNT = dto.MaxTransactionAmount;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.WEEK_DAY_ID = dto.WeekDayID;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            dto.OnEntity(entity);

            return entity;
        }
      
        public static RestrictionTransactionDTO  ToDTO(this CTRestrictionGroupTrans entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionTransactionDTO ();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.MaxTransactionAmount = entity.MAXIMUM_TRANSACTION_AMOUNT;
            dto.WeekDayID = entity.WEEK_DAY_ID;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.ProductCategoryID = Convert.ToInt32(entity.PRODUCT_CATEGORY_ID);
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTRestrictionGroupTrans> ToEntities(this IEnumerable<RestrictionTransactionDTO > dtos)
        {
            return LinqExtension.ToEntity<CTRestrictionGroupTrans, RestrictionTransactionDTO >(dtos, ToEntity);
        }

        public static List<RestrictionTransactionDTO > ToDTOs(this IEnumerable<CTRestrictionGroupTrans> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupTrans, RestrictionTransactionDTO >(entities, ToDTO);
        }

    }
}


