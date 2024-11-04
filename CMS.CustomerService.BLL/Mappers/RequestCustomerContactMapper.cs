using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_CONTACT"/> and <see cref="CustomerContactDTO"/>.
    /// </summary>
    public static partial class RequestCustomerContactMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerContactDTO"/> converted from <see cref="CUSTOMER_CONTACT"/>.</param>
        static partial void OnDTO(this RQST_REQUEST_CUSTOMER_CONTACT entity, RequestCustomerContactsDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> converted from <see cref="CustomerContactDTO"/>.</param>
        static partial void OnEntity(this RequestCustomerContactsDTO dto, RQST_REQUEST_CUSTOMER_CONTACT entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerContactDTO"/> to an instance of <see cref="CUSTOMER_CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerContactDTO"/> to convert.</param>
        public static RQST_REQUEST_CUSTOMER_CONTACT ToEntity(this RequestCustomerContactsDTO dto)
        {
            if (dto == null) return null;

            var entity = new RQST_REQUEST_CUSTOMER_CONTACT();

            entity.REQUEST_CUSTOMER_ID = dto.CustomerID;
            entity.RQST_REQUEST_CONTACT = dto.Contact.ToEEntity();
            entity.CONTACT_TYPE_ID = dto.ContactTypeID;

            dto.OnEntity(entity);

            return entity;
        }


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> to convert.</param>
        public static RequestCustomerContactsDTO ToDTO(this RQST_REQUEST_CUSTOMER_CONTACT entity)
        {
            if (entity == null) return null;

            var dto = new RequestCustomerContactsDTO();

            dto.CustomerID = entity.REQUEST_CUSTOMER_ID;
            dto.Contact = entity.RQST_REQUEST_CONTACT.ToEDTO();
            dto.ContactTypeID = entity.CONTACT_TYPE_ID;
            dto.IsActive = dto.Contact.IsActive;
            

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerContactDTO"/> to an instance of <see cref="CUSTOMER_CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<RQST_REQUEST_CUSTOMER_CONTACT> ToEntities(this IEnumerable<RequestCustomerContactsDTO> dtos)
        {
            return LinqExtension.ToEntity<RQST_REQUEST_CUSTOMER_CONTACT, RequestCustomerContactsDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestCustomerContactsDTO> ToDTOs(this IEnumerable<RQST_REQUEST_CUSTOMER_CONTACT> entities)
        {
            return LinqExtension.ToDTO<RQST_REQUEST_CUSTOMER_CONTACT, RequestCustomerContactsDTO>(entities, ToDTO);

        }



        static partial void OnRDTO(this RQST_RQST_CUSTOMER_CNTCT_HIST entity, RequestCustomerContactsDTO dto);
        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> to convert.</param>
        public static RequestCustomerContactsDTO ToRDTO(this RQST_RQST_CUSTOMER_CNTCT_HIST entity)
        {
            if (entity == null) return null;

            var dto = new RequestCustomerContactsDTO();

            dto.CustomerID = entity.REQUEST_CUSTOMER_ID;
            dto.Contact = entity.RQST_REQUEST_CONTACT_HIST.ToERDTO();
            dto.ContactTypeID = entity.CONTACT_TYPE_ID;

            entity.OnRDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestCustomerContactsDTO> ToRDTOs(this IEnumerable<RQST_RQST_CUSTOMER_CNTCT_HIST> entities)
        {
            return LinqExtension.ToDTO<RQST_RQST_CUSTOMER_CNTCT_HIST, RequestCustomerContactsDTO>(entities, ToRDTO);

        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> converted from <see cref="CustomerContactDTO"/>.</param>
        static partial void OnERntity(this RequestCustomerContactsDTO dto, RQST_RQST_CUSTOMER_CNTCT_HIST entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerContactDTO"/> to an instance of <see cref="CUSTOMER_CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerContactDTO"/> to convert.</param>
        public static RQST_RQST_CUSTOMER_CNTCT_HIST ToERntity(this RequestCustomerContactsDTO dto)
        {
            if (dto == null) return null;

            var entity = new RQST_RQST_CUSTOMER_CNTCT_HIST();

            entity.REQUEST_CUSTOMER_ID = dto.CustomerID;
            entity.RQST_REQUEST_CONTACT_HIST = dto.Contact.ToEERntity();
            entity.CONTACT_TYPE_ID = dto.ContactTypeID;

            dto.OnERntity(entity);

            return entity;
        }
    
    }
}
