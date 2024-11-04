using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class IssueTokenMapper
    {
        static partial void OnDTO(this CTPersonalization entity, IssueTokenDTO dto);

        static partial void OnEntity(this IssueTokenDTO dto, CTPersonalization entity);

        public static CTPersonalization ToEntity(this IssueTokenDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPersonalization();

            entity.TOKEN_ID = dto.TokenID;
            entity.PERSONALIZATION_NUMBER = dto.PersonalizationNumber;
            entity.PERSONALIZATION_STATUS_ID = dto.PersonalizationStatusID;
            entity.CARD_CENTER_ID = dto.CardCentreID;
            entity.APPOINTMENT_DATE_TIME = dto.AppointmentDate;
            entity.PERSONALIZATION_ORDER_TYPE_ID = dto.PersonalizationOrderTypeID;
            entity.PERSONALIZATION_REASON_ID = dto.PersonalizationReasonID;
            entity.IDENTIFICATION_TYPE_ID = dto.IdentificationTypeID;
            entity.IDENTITY_NUMBER = dto.IdentityNumber;


            dto.OnEntity(entity);

            return entity;
        }

        public static IssueTokenDTO ToDTO(this CTPersonalization entity)
        {
            if (entity == null) return null;

            var dto = new IssueTokenDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.PersonalizationNumber = entity.PERSONALIZATION_NUMBER;
            dto.PersonalizationStatusID = entity.PERSONALIZATION_STATUS_ID;
            dto.CardCentreID = entity.CARD_CENTER_ID;
            dto.AppointmentDate = entity.APPOINTMENT_DATE_TIME;
            dto.PersonalizationOrderTypeID = entity.PERSONALIZATION_ORDER_TYPE_ID;
            dto.PersonalizationReasonID = entity.PERSONALIZATION_REASON_ID;
            dto.IdentificationTypeID = entity.IDENTIFICATION_TYPE_ID;
            dto.IdentityNumber = entity.IDENTITY_NUMBER;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPersonalization> ToEntities(this IEnumerable<IssueTokenDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPersonalization, IssueTokenDTO>(dtos, ToEntity);
        }

        public static List<IssueTokenDTO> ToDTOs(this IEnumerable<CTPersonalization> entities)
        {
            return LinqExtension.ToDTO<CTPersonalization, IssueTokenDTO>(entities, ToDTO);
        }
    }
}





