using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTRequestWFHistoryCustomer"/> and <see cref="RequestWFHistoryCustomerDTO"/>.
    /// </summary>
    public static partial class RequestWFHistoryCustomerMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryCustomerDTO"/> converted from <see cref="CTRequestWFHistoryCustomer"/>.</param>
        static partial void OnDTO(this CTRequestWFHistoryCustomer entity, RequestWFHistoryCustomerDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryCustomer"/> converted from <see cref="RequestWFHistoryCustomerDTO"/>.</param>
        static partial void OnEntity(this RequestWFHistoryCustomerDTO dto, CTRequestWFHistoryCustomer entity);

        /// <summary>
        /// Converts this instance of <see cref="RequestWFHistoryCustomerDTO"/> to an instance of <see cref="CTRequestWFHistoryCustomer"/>.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryCustomerDTO"/> to convert.</param>
        public static CTRequestWFHistoryCustomer ToEntity(this RequestWFHistoryCustomerDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestWFHistoryCustomer();

            entity.RequestCustomerId = dto.RequestCustomerId==null?-1 :dto.RequestCustomerId;
            entity.AccountManagerID = dto.AccountManagerID;
            entity.AccountTypeID = dto.AccountTypeID;
            entity.BasicAddressID = dto.BasicAddressID;
            entity.BillingAddressID = dto.BillingAddressID;
            entity.BillingFrequencyDayOrder = dto.BillingFrequencyDayOrder;
            entity.BillingFrequencyID = dto.BillingFrequencyID;
            entity.CardCentreID = dto.CardCentreID;
            entity.ClassificationID = dto.ClassificationID;
            entity.CompanyID = dto.CompanyID;
            entity.CustomerTypeID = dto.CustomerTypeID;
            entity.FamilyID = dto.FamilyID;
            entity.FinancialAccountNo = dto.FinancialAccountNo;
            entity.FinancialAccountTypeID = dto.FinancialAccountTypeID;
            entity.FinancialContactID = dto.FinancialContactID;
            entity.IdentificationID = dto.IdentificationID;
            entity.IdentificationTypeID = dto.IdentificationTypeID;
            entity.IsActive =Convert.ToInt32(dto.IsActive);
            entity.IsVIP = dto.IsPremier;
            entity.Name = dto.Name;
            entity.NationalID = dto.NationalID;
            entity.NationalityID = dto.NationalityID;
            entity.NotificationChannelID = dto.NotificationChannelID;
            entity.NotificationLanguageID = dto.NotificationLanguageID;
            entity.NotificationThreshold = dto.NotificationThreshold;
            entity.OperationalContactID = dto.OperationalContactID;
            entity.PaymentTerms = dto.PaymentTerms;
            entity.PIN = dto.PIN;
            entity.RequestID = dto.RequestID;
            entity.RequestSourceTypeID = dto.RequestSourceTypeID;
            entity.ShippingAddressID = dto.ShippingAddressID;
            entity.StatusID = dto.StatusID;
            entity.StatusReasonID = dto.StatusReasonID;
            entity.SuspensionThreshold = dto.SuspensionThreshold;
            entity.UnitID = dto.UnitID;
            entity.EnableDefaultBeneficiary = dto.EnableDefaultBeneficiary==false?0:1;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastLocationID = dto.LastUpdatedLocationID;
            entity.EnableDefaultBeneficiary = dto.EnableDefaultBeneficiary==true?1:0;
            entity.MonthlyVolumeID = dto.MonthlyVolumeID;
            entity.GENDER = dto.Gender;
            entity.DATEOFBIRTH = dto.DateOfBirth;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTRequestWFHistoryCustomer"/> to an instance of <see cref="RequestWFHistoryCustomerDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryCustomer"/> to convert.</param>
        public static RequestWFHistoryCustomerDTO ToDTO(this CTRequestWFHistoryCustomer entity)
        {
            if (entity == null) return null;

            var dto = new RequestWFHistoryCustomerDTO();
            
            dto.AccountManagerID = entity.AccountManagerID;
            dto.AccountTypeID = entity.AccountTypeID;
            dto.BasicAddressID = entity.BasicAddressID;
            dto.BillingAddressID = entity.BillingAddressID;
            dto.BillingFrequencyDayOrder = entity.BillingFrequencyDayOrder;
            dto.BillingFrequencyID = entity.BillingFrequencyID;
            dto.CardCentreID = entity.CardCentreID;
            dto.ClassificationID = entity.ClassificationID;
            dto.CompanyID = entity.CompanyID;
            dto.CustomerTypeID = entity.CustomerTypeID;
            dto.FamilyID = entity.FamilyID;
            dto.FinancialAccountNo = entity.FinancialAccountNo;
            dto.FinancialAccountTypeID = entity.FinancialAccountTypeID;
            dto.FinancialContactID = entity.FinancialContactID;
            dto.IdentificationID = entity.IdentificationID;
            dto.IdentificationTypeID = entity.IdentificationTypeID;
            dto.IsActive =entity.IsActive==1?true:false;
            dto.IsPremier = entity.IsVIP;
            dto.Name = entity.Name;
            dto.NationalID = entity.NationalID;
            dto.NationalityID = entity.NationalityID;
            dto.NotificationChannelID = entity.NotificationChannelID;
            dto.NotificationLanguageID = entity.NotificationLanguageID;
            dto.NotificationThreshold = entity.NotificationThreshold;
            dto.OperationalContactID = entity.OperationalContactID;
            dto.PaymentTerms = entity.PaymentTerms;
            dto.PIN = entity.PIN;
            dto.RequestCustomerId = entity.RequestCustomerId;
            dto.RequestID = entity.RequestID;
            dto.RequestSourceTypeID = entity.RequestSourceTypeID;
            dto.ShippingAddressID = entity.ShippingAddressID;
            dto.StatusID = entity.StatusID;
            dto.StatusReasonID = entity.StatusReasonID;
            dto.SuspensionThreshold = entity.SuspensionThreshold;
            dto.UnitID = entity.UnitID;
            dto.EnableDefaultBeneficiary = entity.EnableDefaultBeneficiary == null ? false : Convert.ToBoolean(entity.EnableDefaultBeneficiary);
            dto.LastUpdatedLocationID = entity.LastLocationID;
            dto.LastUpdatedUserId = entity.LastUserID;
            dto.FinancialAccountType = entity.FinancialAccountType;
            dto.MonthlyVolumeID = entity.MonthlyVolumeID;
            dto.DateOfBirth = entity.DATEOFBIRTH;
            dto.Gender = entity.GENDER;

            dto.AccountManager = entity.AccountManagerID == null ? null : new CustomerAppService().GetRequestAccountManager((int)entity.AccountManagerID);
            dto.BasicAddress = entity.BasicAddressID == null ? null : new CustomerAppService().GetRequestCustomerAddressHistory((int)entity.BasicAddressID);
            dto.BillingAddress = entity.BillingAddressID == null ? null : new CustomerAppService().GetRequestCustomerAddressHistory((int)entity.BillingAddressID);
            dto.ShippingAddress = entity.ShippingAddressID == null ? null : new CustomerAppService().GetRequestCustomerAddressHistory((int)entity.ShippingAddressID);
            dto.Request = new CustomerAppService().GetRequestById((int)entity.RequestID);
            dto.customerContact = new CustomerAppService().RequestCustomerContacHistMapping((int)entity.RequestCustomerId);
            if (dto.customerContact != null)
            {
                foreach (var item in dto.customerContact)
                {
                    if (item.ContactTypeID == 0 || item.ContactTypeID == 2)
                        dto.OperationalContactID = item.Contact.ContactID;
                    else if (item.ContactTypeID == 1)
                        dto.FinancialContactID = item.Contact.ContactID;
                }
            }

            dto.CustomerReceiptPreference = new CustomerAppService().GetRequestCustomerReceiptPreference((int)entity.RequestCustomerId);
            if (dto.CustomerReceiptPreference == null)
                dto.CustomerReceiptPreference = new CustomerReceiptPreferenceDTO { CustomerId = entity.RequestCustomerId, ReceiptTypeId = 3 };


            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="RequestWFHistoryCustomerDTO"/> to an instance of <see cref="CTRequestWFHistoryCustomer"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestWFHistoryCustomer> ToEntities(this IEnumerable<RequestWFHistoryCustomerDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTRequestWFHistoryCustomer>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="CTRequestWFHistoryCustomer"/> to an instance of <see cref="RequestWFHistoryCustomerDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWFHistoryCustomerDTO> ToDTOs(this IEnumerable<CTRequestWFHistoryCustomer> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestWFHistoryCustomerDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
