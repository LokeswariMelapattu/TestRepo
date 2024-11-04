using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_CONTACT"/> and <see cref="CustomerContactDTO"/>.
    /// </summary>
    public static partial class CustomerContactMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerContactDTO"/> converted from <see cref="CUSTOMER_CONTACT"/>.</param>
        static partial void OnDTO(this CUSTOMER_CONTACT entity, CustomerContactDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> converted from <see cref="CustomerContactDTO"/>.</param>
        static partial void OnEntity(this CustomerContactDTO dto, CUSTOMER_CONTACT entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerContactDTO"/> to an instance of <see cref="CUSTOMER_CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerContactDTO"/> to convert.</param>
        public static CUSTOMER_CONTACT ToEntity(this CustomerContactDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_CONTACT();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.CONTACT = dto.Contact.ToEntity();
            entity.CONTACT_TYPE_ID = dto.ContactTypeID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CONTACT"/> to convert.</param>
        public static CustomerContactDTO ToDTO(this CUSTOMER_CONTACT entity)
        {
            if (entity == null) return null;

            var dto = new CustomerContactDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.Contact = entity.CONTACT.ToDTO();
            dto.ContactTypeID = entity.CONTACT_TYPE_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerContactDTO"/> to an instance of <see cref="CUSTOMER_CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_CONTACT> ToEntities(this IEnumerable<CustomerContactDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_CONTACT, CustomerContactDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_CONTACT"/> to an instance of <see cref="CustomerContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerContactDTO> ToDTOs(this IEnumerable<CUSTOMER_CONTACT> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_CONTACT, CustomerContactDTO>(entities, ToDTO);

        }

    }
}
