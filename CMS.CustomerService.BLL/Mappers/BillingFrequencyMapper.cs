using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class BillingFrequencyMapper
    {
        public static BillingFrequencyDTO ToDTO(this CTBillingFrequency entity)
        {
            if (entity == null) return null;

            var dto = new BillingFrequencyDTO();

            dto.ArName = entity.AR_NAME;
            dto.BillingFrequenceId = entity.BILLING_FREQUENCY_ID;
            dto.Duration = entity.DURATION;
            dto.EnName = entity.EN_NAME;
            dto.IsActive = entity.IS_ACTIVE;
            dto.LastLocationId = entity.LAST_LOCATION_ID;
            dto.LastUpadtedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;

            return dto;
        }

        public static List<BillingFrequencyDTO> ToDTOs(this IEnumerable<CTBillingFrequency> entities)
        {
            if (entities == null) return null;
            var dtos = new List<BillingFrequencyDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

        static partial void OnEntity(this BillingFrequencyDTO dto, CTBillingFrequency entity);

        public static CTBillingFrequency ToEntity(this BillingFrequencyDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBillingFrequency();

            entity.AR_NAME = dto.ArName;
            entity.BILLING_FREQUENCY_ID = dto.BillingFrequenceId;
            entity.DURATION = dto.Duration;
            entity.EN_NAME = dto.EnName;
            entity.IS_ACTIVE = dto.IsActive;
            entity.LAST_LOCATION_ID = dto.LastLocationId;
            entity.LAST_UPDATED_DATE = dto.LastUpadtedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTBillingFrequency> ToEntities(this IEnumerable<BillingFrequencyDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBillingFrequency, BillingFrequencyDTO>(dtos, ToEntity);
        }
    }
}
