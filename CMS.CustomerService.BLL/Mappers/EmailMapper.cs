using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class EmailMapper
    {
        static partial void OnDTO(this EMAIL_NOTIFICATION entity, EmailDTO dto);

        static partial void OnEntity(this EmailDTO dto, EMAIL_NOTIFICATION entity);

        public static EMAIL_NOTIFICATION ToEntity(this EmailDTO dto)
        {
            if (dto == null) return null;

            var entity = new EMAIL_NOTIFICATION();

            entity.EMAIL_NOTIFICATION_ID = -1;
            entity.NOTIFICATION_SOURCE = "CMS";
            entity.EMAIL_BODY = dto.EmailBody;
            entity.EMAIL_SUBJECT = dto.EmailSubject;
            entity.EMAIL_RECEPIENTS = dto.RecipientEmail;
            entity.DATE_RECEIVED = DateTime.Now;
            entity.IS_SENT = 0;
            entity.DATE_PROCESSED = DateTime.Now;
            entity.IS_ACTIVE = 1;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            //entity.LANGUAGE.LANGUAGE_ID = (int)dto.LanguageID;

            dto.OnEntity(entity);

            return entity;
        }

        public static List<EMAIL_NOTIFICATION> ToEntities(this IEnumerable<EmailDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<EMAIL_NOTIFICATION>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }
    }
}
