using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestCustomerContactsMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTRequestCustomerContacts entity, RequestContactDTO dto);
        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestContactDTO ToDTO(this CTRequestCustomerContacts entity)
        {
            if (entity == null) return null;

            var dto = new RequestContactDTO();
            dto.ContactID = entity.ContactID;
            // dto.ContactTypeID = entity.ContactTypeID;
            dto.Email = entity.Email;
            dto.Fax = entity.Fax;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.LastUpdatedDate = entity.LastUpdatedDate;
            dto.LastUpdatedUserId = entity.LastUpdatedUserID;
            dto.Mobile = entity.Mobile;
            dto.Name = entity.Name;
            dto.NotificationChannelID = entity.NotificationChannelID;
            dto.NotificationLanguageID = entity.NotificationLanguageID;
            dto.Phone = entity.Phone;
            dto.Code = entity.Code;
            dto.PIN = entity.PIN;
            entity.OnDTO(dto);

            return dto;
        }
        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestContactDTO> ToDTOs(this IEnumerable<CTRequestCustomerContacts> entities)
        {
            return LinqExtension.ToDTO<CTRequestCustomerContacts, RequestContactDTO>(entities, ToDTO);
        }
        
        static partial void OnCDTO(this CTRequestCustomerContacts entity, CustomerContactDTO dto);
        public static CustomerContactDTO ToCDTO(this CTRequestCustomerContacts entity)
        {
            if (entity == null) return null;

            var dto = new CustomerContactDTO();
            var ContactDto = new ContactDTO();
            ContactDto.ContactID = entity.ContactID;
            dto.ContactTypeID = entity.ContactTypeID == null ? -1 : (int)entity.ContactTypeID;
            ContactDto.Email = entity.Email;
            ContactDto.Fax = entity.Fax;
            ContactDto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.LastUpdatedDate = entity.LastUpdatedDate;
            dto.LastUpdatedUserId = entity.LastUpdatedUserID;
            ContactDto.Mobile = entity.Mobile;
            ContactDto.Name = entity.Name;
            ContactDto.NotificationChannelID = entity.NotificationChannelID;
            ContactDto.NotificationLanguageID = entity.NotificationLanguageID;
            ContactDto.Phone = entity.Phone;
            ContactDto.Code = entity.Code;
            ContactDto.PIN = entity.PIN;

            dto.Contact = ContactDto;

            entity.OnCDTO(dto);

            return dto;
        }
        public static List<CustomerContactDTO> ToCDTOs(this IEnumerable<CTRequestCustomerContacts> entities)
        {
            return LinqExtension.ToDTO<CTRequestCustomerContacts, CustomerContactDTO>(entities, ToCDTO);
        }
        
        static partial void OnEEntity(this RequestContactDTO dto, RQST_REQUEST_CONTACT entity);
        public static RQST_REQUEST_CONTACT ToEEntity(this RequestContactDTO dto)
        {
            if (dto == null) return null;
            var entity = new RQST_REQUEST_CONTACT();
            entity.EMAIL = dto.Email;
            entity.FAX = dto.Fax;
            entity.IS_ACTIVE = dto.IsActive == true ? (short)1 : (short)0;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.MOBILE = dto.Mobile;
            entity.NAME = dto.Name;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificationChannelID;
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.PHONE = dto.Phone;
            entity.REQUEST_CONTACT_ID = dto.ContactID == null ? -1 : (int)dto.ContactID;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.CODE = dto.Code;
            entity.PIN = dto.PIN;
            dto.OnEEntity(entity);

            return entity;
        }
        public static List<RQST_REQUEST_CONTACT> ToEntities(this IEnumerable<RequestContactDTO> dtos)
        {
            return LinqExtension.ToEntity<RQST_REQUEST_CONTACT, RequestContactDTO>(dtos, ToEEntity);

        }


        static partial void OnEDTO(this RQST_REQUEST_CONTACT entity, RequestContactDTO dto);
        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestContactDTO ToEDTO(this RQST_REQUEST_CONTACT entity)
        {
            if (entity == null) return null;

            var dto = new RequestContactDTO();
            dto.ContactID = entity.REQUEST_CONTACT_ID;
            dto.Email = entity.EMAIL;
            dto.Fax = entity.FAX;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedUserId = entity.USERS.USER_ID;
            dto.Mobile = entity.MOBILE;
            dto.Name = entity.NAME;
            dto.NotificationChannelID = entity.NOTIFICATION_CHANNEL_ID;
            dto.NotificationLanguageID = entity.NOTIFICATION_LANGUAGE_ID;
            dto.Phone = entity.PHONE;
            dto.Code = entity.CODE;
            dto.PIN = entity.PIN;

            entity.OnEDTO(dto);

            return dto;
        }
        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestContactDTO> ToEDTOs(this IEnumerable<RQST_REQUEST_CONTACT> entities)
        {
            return LinqExtension.ToDTO<RQST_REQUEST_CONTACT, RequestContactDTO>(entities, ToEDTO);
        }

        static partial void OnERDTO(this RQST_REQUEST_CONTACT_HIST entity, RequestContactDTO dto);
        public static RequestContactDTO ToERDTO(this RQST_REQUEST_CONTACT_HIST entity)
        {
            if (entity == null) return null;

            var dto = new RequestContactDTO();
            dto.ContactID = entity.REQUEST_CONTACT_ID;
            dto.Email = entity.EMAIL;
            dto.Fax = entity.FAX;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            //    dto.LastUpdatedUserId = entity.USERS.USER_ID;
            dto.Mobile = entity.MOBILE;
            dto.Name = entity.NAME;
            dto.NotificationChannelID = entity.NOTIFICATION_CHANNEL_ID;
            dto.NotificationLanguageID = entity.NOTIFICATION_LANGUAGE_ID;
            dto.Phone = entity.PHONE;
            dto.Code = entity.CODE;

            entity.OnERDTO(dto);

            return dto;
        }

        static partial void OnEERntity(this RequestContactDTO dto, RQST_REQUEST_CONTACT_HIST entity);
        public static RQST_REQUEST_CONTACT_HIST ToEERntity(this RequestContactDTO dto)
        {
            if (dto == null) return null;
            var entity = new RQST_REQUEST_CONTACT_HIST();
            entity.EMAIL = dto.Email;
            entity.FAX = dto.Fax;
            entity.IS_ACTIVE = dto.IsActive == true ? (short)1 : (short)0;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.MOBILE = dto.Mobile;
            entity.NAME = dto.Name;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificationChannelID;
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.PHONE = dto.Phone;
            entity.REQUEST_CONTACT_ID = dto.ContactID == null ? -1 : (int)dto.ContactID;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.CODE = dto.Code;
            dto.OnEERntity(entity);

            return entity;
        }
    }
}
