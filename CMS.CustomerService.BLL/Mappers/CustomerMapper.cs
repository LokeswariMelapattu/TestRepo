using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.DAL.DataExtensions;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER"/> and <see cref="CustomerDTO"/>.
    /// </summary>
    public static partial class CUSTOMERMapper
    {
        #region CustomerMapper
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerDTO"/> converted from <see cref="CUSTOMER"/>.</param>
        static partial void OnDTO(this CUSTOMER entity, CustomerDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER"/> converted from <see cref="CustomerDTO"/>.</param>
        static partial void OnEntity(this CustomerDTO dto, CUSTOMER entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerDTO"/> to an instance of <see cref="CUSTOMER"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerDTO"/> to convert.</param>
        public static CUSTOMER ToEntity(this CustomerDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER();

            entity.CUSTOMER_ID = dto.CustomerID == null ? -4 : (int)dto.CustomerID;
            entity.NAME = dto.Name;
            entity.CUSTOMER_TYPE_ID = dto.CustomerTypeID;
            entity.CODE = dto.Code;
            entity.CLASSIFICATION_ID = dto.ClassificationID;
            entity.ACCOUNT_TYPE_ID = dto.AccountTypeID;
            entity.NATIONALITY_ID = dto.NationalityID;
            entity.NATIONAL_ID = dto.NationalID;
            entity.BASIC_ADDRESS_ID = dto.BasicAddressID;
            entity.BILLING_ADDRESS_ID = dto.BillingAddressID;
            entity.SHIPPING_ADDRESS_ID = dto.ShippingAddressID;
            entity.FAMILY_ID = dto.FamilyID;
            entity.FINANCIAL_ACCOUNT_TYPE_ID = dto.FinancialAccountTypeID;
            entity.FINANCIAL_ACCOUNT_NUMBER = dto.FinancialAccountNumber;
            entity.ACCOUNT_MANAGER_ID = dto.AccountManagerID > 0 ? dto.AccountManagerID : dto.AccountManager != null ? dto.AccountManager.AccountManagerID : 0;
            entity.BILLING_FREQUENCY_ID = dto.BillingFrequencyID;

            entity.NOTIFICATION_THRESHOLD = dto.NotificationThreshold;
            entity.SUSPPENSION_THRESHOLD = dto.SuspensionThreshold;
            entity.IS_VIP = (short)(dto.IsVIP ? 1 : 0);
            entity.REGISTRATION_DATE = dto.RegistrationDate;
            entity.STATUS_ID = dto.StatusID;
            entity.STATUS_REASON_ID = dto.StatusReasonID;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.PIN = dto.PIN;
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificatonChannelID;
            entity.REQUEST_SOURCE_TYPE_ID = dto.RequestSourceTypeID;
            entity.CARD_CENTER_ID = dto.CardCenterID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.UNIT_ID = dto.UnitID;
            entity.BILLING_FREQUENCY_DAY_ORDER = dto.BillingFrequencyDayOrder;
            entity.PAYEMENT_TERMS = dto.PaymentTerms;
            entity.IDENTIFICATION_TYPE_ID = dto.IdentificationTypeID;
            entity.ACCOUNT_MANAGER = dto.AccountManager.ToEntity();
            entity.CUSTOMER_CONTACT = dto.CustomerContact.ToEntities();

            entity.ADDRESS = dto.BaseAddress.ToEntity();
            entity.ADDRESS1 = dto.BillingAddress.ToEntity();
            entity.ADDRESS2 = dto.ShippingAddress.ToEntity();
            entity.COMPANY_ID = dto.CompanyID;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.IS_PREMIER = Convert.ToInt32(dto.isPrimier);
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER"/> to an instance of <see cref="CustomerDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER"/> to convert.</param>
        public static CustomerDTO ToDTO(this CUSTOMER entity)
        {
            if (entity == null) return null;

            var dto = new CustomerDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.Name = entity.NAME;
            dto.Code = entity.CODE;
            dto.CustomerTypeID = entity.CUSTOMER_TYPE_ID;
            dto.ClassificationID = entity.CLASSIFICATION_ID;
            dto.AccountTypeID = entity.ACCOUNT_TYPE_ID;
            dto.NationalityID = entity.NATIONALITY_ID;
            dto.NationalID = entity.NATIONAL_ID;
            dto.BasicAddressID = entity.BASIC_ADDRESS_ID;
            dto.BillingAddressID = entity.BILLING_ADDRESS_ID;
            dto.ShippingAddressID = entity.SHIPPING_ADDRESS_ID;
            dto.FamilyID = entity.FAMILY_ID;
            dto.FinancialAccountTypeID = entity.FINANCIAL_ACCOUNT_TYPE_ID;
            dto.FinancialAccountNumber = entity.FINANCIAL_ACCOUNT_NUMBER;
            dto.AccountManagerID = entity.ACCOUNT_MANAGER_ID;
            if (dto.AccountManagerID != null)
                dto.AccountManager = entity.ACCOUNT_MANAGER.ToDTO();
            dto.BillingFrequencyID = entity.BILLING_FREQUENCY_ID;

            dto.NotificationThreshold = entity.NOTIFICATION_THRESHOLD;
            dto.SuspensionThreshold = entity.SUSPPENSION_THRESHOLD;
            dto.IsVIP = entity.IS_VIP == 1;
            dto.RegistrationDate = entity.REGISTRATION_DATE;
            dto.StatusID = entity.STATUS_ID;
           dto.StatusReasonID = entity.STATUS_REASON_ID;
            dto.IsActive = (!entity.IS_ACTIVE.HasValue || entity.IS_ACTIVE == 1);
            dto.PIN = entity.PIN;
            dto.NotificationLanguageID = entity.NOTIFICATION_LANGUAGE_ID;
            dto.NotificatonChannelID = entity.NOTIFICATION_CHANNEL_ID;
            dto.RequestSourceTypeID = entity.REQUEST_SOURCE_TYPE_ID;
            dto.CardCenterID = entity.CARD_CENTER_ID;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.UnitID = entity.UNIT_ID;
            dto.BillingFrequencyDayOrder = entity.BILLING_FREQUENCY_DAY_ORDER;
            dto.PaymentTerms = entity.PAYEMENT_TERMS;
            dto.IdentificationTypeID = entity.IDENTIFICATION_TYPE_ID;
            //dto.CustomerContact = entity.CUSTOMER_CONTACT.ToDTOs();

            dto.CustomerContact = new CustomerAppService().GetCustomerContacts((int)entity.CUSTOMER_ID);
            if (dto.CustomerContact != null)
            {
                foreach (var item in dto.CustomerContact)
                {
                    if (item.Contact != null)
                    {
                        if (item.ContactTypeID == 0 || item.ContactTypeID == 2)
                            dto.OperationalContactID = item.Contact.ContactID;
                        else if (item.ContactTypeID == 1)
                            dto.FinancialContactID = item.Contact.ContactID;
                    }
                }
            }
            dto.BaseAddress = entity.ADDRESS.ToDTO();
            dto.BillingAddress = entity.ADDRESS1.ToDTO();
            dto.ShippingAddress = entity.ADDRESS2.ToDTO();
            dto.CustomerReceiptPreference = new CustomerAppService().GetCustomerReceiptPreference(entity.CUSTOMER_ID);
            if (dto.CustomerReceiptPreference == null)
                dto.CustomerReceiptPreference = new CustomerReceiptPreferenceDTO { CustomerId = entity.CUSTOMER_ID, ReceiptTypeId = 3 };
            dto.CompanyID = entity.COMPANY_ID;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.isPrimier = Convert.ToBoolean(entity.IS_PREMIER);
            dto.FinancialStartYear = entity.MONTH == null ? null : (int?)entity.MONTH.MONTH_ID;
            dto.ExemptionReason = entity.EXEMPTION_REASON;
            dto.IsVatExempted = (entity.IS_VAT_EXEMPTED == null || entity.IS_VAT_EXEMPTED == 0) ? false : true;
            dto.Trn = entity.TRN;
            dto.IsBeneficiaryIdNonUnique = (entity.ISBENEFICIARYIDNONUNIQUE == null || entity.ISBENEFICIARYIDNONUNIQUE == 0) ? false : true;
            dto.CustomBillFrequency = (int?)entity.CUSTOM_BILL_FREQUENCY;
            dto.IsEmployer= (entity.IS_EMPLOYER == null || entity.IS_EMPLOYER == 0) ? false : true;
            dto.ContractNumber =  entity.CONTRACT_NUMBER;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerDTO"/> to an instance of <see cref="CUSTOMER"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER> ToEntities(this IEnumerable<CustomerDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER, CustomerDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER"/> to an instance of <see cref="CustomerDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerDTO> ToDTOs(this IEnumerable<CUSTOMER> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER, CustomerDTO>(entities, ToDTO);
        }
        #endregion

        #region CTCustomerMapper

        /// <summary>
        /// Converts this instance of <see cref="CustomerDTO"/> to an instance of <see cref="CUSTOMER"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerDTO"/> to convert.</param>
        public static CTCustomer ToCTEntity(this CustomerDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomer();

            entity.CUSTOMER_ID = dto.CustomerID == null ? -4 : (int)dto.CustomerID;
            entity.NAME = dto.Name;
            entity.CUSTOMER_TYPE_ID = dto.CustomerTypeID;
            entity.CODE = dto.Code;
            entity.CLASSIFICATION_ID = dto.ClassificationID;
            entity.ACCOUNT_TYPE_ID = dto.AccountTypeID;
            entity.NATIONALITY_ID = dto.NationalityID;
            entity.NATIONAL_ID = dto.NationalID;
            entity.BASIC_ADDRESS_ID = dto.BasicAddressID;
            entity.BILLING_ADDRESS_ID = dto.BillingAddressID;
            entity.SHIPPING_ADDRESS_ID = dto.ShippingAddressID;
            entity.FAMILY_ID = dto.FamilyID;
            entity.FINANCIAL_ACCOUNT_TYPE_ID = dto.FinancialAccountTypeID;
            entity.FINANCIAL_ACCOUNT_NUMBER = dto.FinancialAccountNumber;
            entity.ACCOUNT_MANAGER_ID = dto.AccountManagerID > 0 ? dto.AccountManagerID : dto.AccountManager != null ? dto.AccountManager.AccountManagerID : 0;
            entity.BILLING_FREQUENCY_ID = dto.BillingFrequencyID;

            entity.NOTIFICATION_THRESHOLD = dto.NotificationThreshold;
            entity.SUSPPENSION_THRESHOLD = dto.SuspensionThreshold;
            entity.IS_VIP = (short)(dto.IsVIP ? 1 : 0);
            entity.REGISTRATION_DATE = dto.RegistrationDate;
            entity.STATUS_ID = dto.StatusID;
            entity.STATUS_REASON_ID = dto.StatusReasonID;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.PIN = dto.PIN;
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificatonChannelID;
            entity.REQUEST_SOURCE_TYPE_ID = dto.RequestSourceTypeID;
            entity.CARD_CENTER_ID = dto.CardCenterID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.UNIT_ID = dto.UnitID;
            entity.BILLING_FREQUENCY_DAY_ORDER = dto.BillingFrequencyDayOrder;
            entity.PAYEMENT_TERMS = dto.PaymentTerms;
            entity.IDENTIFICATION_TYPE_ID = dto.IdentificationTypeID;
            entity.ACCOUNT_MANAGER = dto.AccountManager.ToEntity();
            entity.CUSTOMER_CONTACT = dto.CustomerContact.ToEntities();

            entity.ADDRESS = dto.BaseAddress.ToEntity();
            entity.ADDRESS1 = dto.BillingAddress.ToEntity();
            entity.ADDRESS2 = dto.ShippingAddress.ToEntity();
            entity.COMPANY_ID = dto.CompanyID;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.IS_PREMIER = Convert.ToInt32(dto.isPrimier);
            entity.FinancialStartYear = dto.FinancialStartYear;
            entity.ISBENEFICIARYIDNONUNIQUE = (short)(dto.IsBeneficiaryIdNonUnique ? 1 : 0);
            entity.CUSTOM_BILL_FREQUENCY = dto.CustomBillFrequency;
            entity.IS_EMPLOYER = (short)(dto.IsEmployer ? 1 : 0);
            entity.CONTRACT_NUMBER = dto.ContractNumber;
            return entity;
        }
        #endregion


    }
}
