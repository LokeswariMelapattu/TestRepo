using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestAccountClosureMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CountryDTO"/> converted from <see cref="COUNTRY"/>.</param>
        static partial void OnDTO(this CTRequestAccountClosure entity, RequestAccountClosureDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="COUNTRY"/> to an instance of <see cref="CountryDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="COUNTRY"/> to convert.</param>
        public static RequestAccountClosureDTO ToDTO(this CTRequestAccountClosure entity)
        {
            if (entity == null) return null;

            var dto = new RequestAccountClosureDTO
            {
                AccountTypeID = entity.AccountTypeID,
                BasicAddressId = entity.BasicAddressId,
                BillingAddressId = entity.BillingAddressId,
                Classification = entity.Classification,
                ClassificationId = entity.ClassificationId,
                CompanyID = entity.CompanyID,
                CustomerTypeID = entity.CustomerTypeID,
                AccountStatus = entity.AccountStatus,
                IsActive = Convert.ToBoolean(entity.IsActive),
                LastUpdatedDate = entity.LastUpdatedDate,
                LastUpdatedUserId = entity.LastUpdatedUserId,
                Name = entity.Name,
                NationalId = entity.NationalID,
                NationalityID = entity.NationalityId,
                Nationality = entity.Nationality,
                IdentificationType = entity.identificationtype,
                RegistrationDate = entity.RegistrationDate,
                RequestCustomerId = entity.RequestCustomerId,
                RequestID = entity.RequestID,
                ShippingAddressId = entity.ShippingAddressId,
                BasicAddress =
                    entity.BasicAddressId == null
                        ? null
                        : new CustomerAppService().GetCustomerAddress((int) entity.BasicAddressId),
                BillingAddress =
                    entity.BillingAddressId == null
                        ? null
                        : new CustomerAppService().GetCustomerAddress((int) entity.BillingAddressId),
                ShippingAddress =
                    entity.ShippingAddressId == null
                        ? null
                        : new CustomerAppService().GetCustomerAddress((int) entity.ShippingAddressId),
                Request =
                    entity.RequestID == null ? null : new CustomerAppService().GetRequestById((int) entity.RequestID),
                AccountBalance = entity.AccountBalance,
                CustomerContact =
                    entity.RequestCustomerId == null
                        ? null
                        : new CustomerAppService().GetCustomerContacts((int) entity.RequestCustomerId)
            };

            if (dto.CustomerContact != null)
            {
                foreach (var item in dto.CustomerContact)
                {
                    if (item.ContactTypeID == 0 || item.ContactTypeID == 2)
                        dto.OperationalContactID = item.Contact.ContactID;
                    else if (item.ContactTypeID == 1)
                        dto.FinancialContactID = item.Contact.ContactID;
                }
            }

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="COUNTRY"/> to an instance of <see cref="CountryDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestAccountClosureDTO> ToDTOs(this IEnumerable<CTRequestAccountClosure> entities)
        {
            if (entities == null) return null;
            return Enumerable.ToList(entities.Select(entity => entity.ToDTO()));
        }
    }
}

