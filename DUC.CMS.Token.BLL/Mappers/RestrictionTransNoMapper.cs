using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{


    public static partial class RestrictionTransNoMapper
    {

        static partial void OnDTO(this RESTRICTION_GROUP_TRANS_NO entity, RestrictionTransNoDTO dto);

        static partial void OnEntity(this RestrictionTransNoDTO dto, RESTRICTION_GROUP_TRANS_NO entity);

        public static RESTRICTION_GROUP_TRANS_NO ToEntity(this RestrictionTransNoDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_TRANS_NO();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.NUMBER_OF_DAYS = dto.NumberOfDays;
            entity.NUMBER_OF_TRANSACTIONS = dto.NumberOfTransactions;
            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            dto.OnEntity(entity);

            return entity;
        }

        public static RestrictionTransNoDTO ToDTO(this RESTRICTION_GROUP_TRANS_NO entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionTransNoDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.NumberOfDays = entity.NUMBER_OF_DAYS;
            dto.NumberOfTransactions = entity.NUMBER_OF_TRANSACTIONS;
            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.ProductCategoryID = Convert.ToInt32(entity.PRODUCT_CATEGORY_ID);
            entity.OnDTO(dto);

            return dto;
        }

        public static List<RESTRICTION_GROUP_TRANS_NO> ToEntities(this IEnumerable<RestrictionTransNoDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_TRANS_NO, RestrictionTransNoDTO>(dtos, ToEntity);
        }

        public static List<RestrictionTransNoDTO> ToDTOs(this IEnumerable<RESTRICTION_GROUP_TRANS_NO> entities)
        {
            return LinqExtension.ToDTO<RESTRICTION_GROUP_TRANS_NO, RestrictionTransNoDTO>(entities, ToDTO);
        }

    }
}



