using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class PersonalizationOrderMapper
    {
        static partial void OnDTO(this CTPersonalizationOrder entity, PersonalizationOrderDTO dto);

        static partial void OnEntity(this PersonalizationOrderDTO dto, CTPersonalizationOrder entity);

        public static PersonalizationOrderDTO ToDTO(this CTPersonalizationOrder entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderDTO();

            dto.PERSONALIZATION_ORDER_ID = entity.PERSONALIZATION_ORDER_ID;
            dto.PERSONALIZATION_NUMBER = entity.PERSONALIZATION_NUMBER;
            dto.PERSONALIZATION_STATUS_ID = entity.PERSONALIZATION_STATUS_ID;
            dto.CARD_CENTER_ID = entity.CARD_CENTER_ID;
            dto.PRINTER_ID = entity.PRINTER_ID;
            dto.APPOINTMENT_DATE_TIME = entity.APPOINTMENT_DATE_TIME;
            dto.ACTUAL_SERVICE_DATE_TIME = entity.ACTUAL_SERVICE_DATE_TIME;
            dto.PASSED_QUALITY_TEST = entity.PASSED_QUALITY_TEST;
            dto.PERSONALIZATION_ORDER_TYPE_ID = entity.PERSONALIZATION_ORDER_TYPE_ID;
            dto.PERSONALIZATION_REASON_ID = entity.PERSONALIZATION_REASON_ID;
            dto.IS_ACTIVE = (short)entity.IS_ACTIVE;
            dto.RecipientIDNumber = entity.IDENTITY_NUMBER;
            dto.RecipientTypeID = entity.IDENTIFICATION_TYPE_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<PersonalizationOrderDTO> ToDTOs(this IEnumerable<CTPersonalizationOrder> entities)
        {
            return LinqExtension.ToDTO<CTPersonalizationOrder, PersonalizationOrderDTO>(entities, ToDTO);
        }
    }
}
