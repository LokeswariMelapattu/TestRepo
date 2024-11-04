using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CONTACT"/> and <see cref="ContactDTO"/>.
    /// </summary>
    public static partial class ContactMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> converted from <see cref="CONTACT"/>.</param>
        static partial void OnDTO(this CONTACT entity, ContactDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this ContactDTO dto, CONTACT entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CONTACT ToEntity(this ContactDTO dto)
        {
            if (dto == null) return null;

            var entity = new CONTACT();

            entity.CONTACT_ID = dto.ContactID == null ? -1 : (int)dto.ContactID;
            entity.NAME = dto.Name;
            entity.MOBILE = dto.Mobile;
            entity.PHONE = dto.Phone;
            entity.EMAIL = dto.Email;
            entity.FAX = dto.Fax;
            entity.PIN = dto.PIN;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificationChannelID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserID;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.CODE = dto.Code;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> to convert.</param>
        public static ContactDTO ToDTO(this CONTACT entity)
        {
            if (entity == null) return null;

            var dto = new ContactDTO();

            dto.ContactID = entity.CONTACT_ID;
            dto.Name = entity.NAME;
            dto.Mobile = entity.MOBILE;
            dto.Phone = entity.PHONE;
            dto.Email = entity.EMAIL;
            dto.Fax = entity.FAX;
            dto.PIN = entity.PIN;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.NotificationLanguageID = entity.NOTIFICATION_LANGUAGE_ID;
            dto.NotificationChannelID = entity.NOTIFICATION_CHANNEL_ID;
            dto.LastUpdatedUserID = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.Code = entity.CODE;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CONTACT> ToEntities(this IEnumerable<ContactDTO> dtos)
        {
            return LinqExtension.ToEntity<CONTACT, ContactDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ContactDTO> ToDTOs(this IEnumerable<CONTACT> entities)
        {
            return LinqExtension.ToDTO<CONTACT, ContactDTO>(entities, ToDTO);
        }

    }
}
