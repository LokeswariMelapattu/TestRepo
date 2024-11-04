using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class RestrictionQuantityMapper
    {      
        static partial void OnDTO(this CTRestrictionGroupQuanity entity, RestrictionQuantityDTO dto);

        static partial void OnEntity(this RestrictionQuantityDTO dto, RESTRICTION_GROUP_QUANTITY entity);

        public static RESTRICTION_GROUP_QUANTITY ToEntity(this RestrictionQuantityDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_QUANTITY();
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.PRODUCT_ID = dto.AllowedProductID;
            entity.FREQUENCY_ID = dto.TimeFrequencyID;
            entity.ALLOWED_QUANTITY = dto.AllowedQuantity;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            dto.OnEntity(entity);

            return entity;
        }
       
        public static RestrictionQuantityDTO ToDTO(this CTRestrictionGroupQuanity entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionQuantityDTO();
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.TimeFrequencyID = entity.FREQUENCY_ID;
            dto.TimeFrequencyDTO = new TokenAppService().GetTimeFrequencyByID((int)entity.FREQUENCY_ID);
            dto.AllowedQuantity = entity.ALLOWED_QUANTITY;
            dto.AllowedProductID = entity.PRODUCT_ID;
            dto.AllowedProductName = entity.PRODUCT_EN_NAME;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.AllowedProductNameAr = entity.PRODUCT_AR_NAME;           
            entity.OnDTO(dto);

            return dto;
        }

        public static List<RESTRICTION_GROUP_QUANTITY> ToEntities(this IEnumerable<RestrictionQuantityDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_QUANTITY, RestrictionQuantityDTO>(dtos, ToEntity);
        }

        public static List<RestrictionQuantityDTO> ToDTOs(this IEnumerable<CTRestrictionGroupQuanity> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupQuanity, RestrictionQuantityDTO>(entities, ToDTO);
        }

    }
}
