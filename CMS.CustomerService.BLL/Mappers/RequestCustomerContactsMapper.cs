using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestCustomerContactsMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTRequestCustomerContacts entity, RequestCustomerContactsDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestCustomerContactsDTO ToDTO(this CTRequestCustomerContacts entity)
        {
            if (entity == null) return null;

            var dto = new RequestCustomerContactsDTO();
            dto.ContactID = entity.ContactID;
            dto.ContactTypeID = entity.ContactTypeID;
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


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestCustomerContactsDTO> ToDTOs(this IEnumerable<CTRequestCustomerContacts> entities)
        {
            return LinqExtension.ToDTO<CTRequestCustomerContacts, RequestCustomerContactsDTO>(entities, ToDTO);
        }
    }
}
