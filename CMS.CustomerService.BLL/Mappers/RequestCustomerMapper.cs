using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestCustomerMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTRequestCustomer entity, RequestCustomerDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestCustomerDTO ToDTO(this CTRequestCustomer entity)
        {
            if (entity == null) return null;

            var dto = new RequestCustomerDTO();

            dto.FamilyID = entity.FamilyID;
            dto.FinancialAccountTypeID = entity.FinancialAccountTypeID;
            dto.FinancialAccountType = entity.FinanialAccountType;
            dto.FinancialAccountNo = entity.FinancialAccountNo;
            dto.AccountManagerID = entity.AccountManagerID;
            
            dto.BillingFrequencyID = entity.BillingFrequencyID;
            dto.NotificationThreshold = entity.NotificationThreshold;
            dto.SuspensionThreshold = entity.SuspensionThreshold;
            dto.IsVIP = entity.IsVIP;
            dto.NotificationLanguageID = entity.NotificationLanguageID;
            dto.NotificationChannelID = entity.NotificationChannelID;
            dto.RequestSourceTypeID = entity.RequestSourceTypeID;
            dto.CardCentreID = entity.CardCentreID;
            dto.UnitID = entity.UnitID;
            dto.PaymentTerms = entity.PaymentTerms;
            dto.BillingFrequencyDayOrder = entity.BillingFrequencyDayOrder;
            dto.RequestCustomerId = entity.RequestCustomerId;
            dto.RequestID = entity.RequestID;
            dto.NationalityID = entity.NationalityID;
            dto.CompanyID = entity.CompanyID;
            dto.BasicAddressId = entity.BasicAddressId;
            dto.BillingAddressId = entity.BillingAddressId;
            dto.ShippingAddressId = entity.ShippingAddressId;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.IdentificationType = entity.IdentificationID;
            dto.IdentificationTypeID = entity.IdentificationTypeID;
            dto.EnableDefaultBeneficiary = entity.EnableDefaultBeneficiary == null ? false : Convert.ToBoolean(entity.EnableDefaultBeneficiary);
            dto.LastUpdatedLocationID = entity.LastLocationID;
            dto.LastUpdatedUserId = entity.LastUserID;
            dto.CustomerTypeID = entity.CustomerTypeID;
            dto.AccountTypeID = entity.AccountTypeID;
            dto.Name = entity.Name;
            dto.NationalID = entity.NationalID;
            dto.ClassificationId = entity.ClassificationId;
            dto.MonthlyVolumeID = entity.MonthlyVolumeID;
            dto.IsPremier = entity.IsPremier;
            dto.Gender = entity.GENDER;
            dto.DateOfBirth = entity.DATEOFBIRTH;
            dto.IsEmployer = entity.IsEmployer==1? true : false;

            dto.AccountManager = entity.AccountManagerID == null ? null : new CustomerAppService().GetRequestAccountManager((int)entity.AccountManagerID);
            dto.BasicAddress = entity.BasicAddressId == null ? null : new CustomerAppService().GetRequestCustomerAddress((int)entity.BasicAddressId);
            dto.BillingAddress = entity.BillingAddressId == null ? null : new CustomerAppService().GetRequestCustomerAddress((int)entity.BillingAddressId);
            dto.ShippingAddress = entity.ShippingAddressId == null ? null : new CustomerAppService().GetRequestCustomerAddress((int)entity.ShippingAddressId);
            dto.Request = new CustomerAppService().GetRequestById((int)entity.RequestID);
            dto.customerContact = new CustomerAppService().RequestCustomerContact((int)entity.RequestCustomerId);
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
            dto.ReceiptPreference = entity.ReceiptPreference;
            dto.CustomBillFrequency = entity.CustBillFrequency; 
            dto.ContractNumber = entity.ContractNumber;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestCustomerDTO> ToDTOs(this IEnumerable<CTRequestCustomer> entities)
        {
            return LinqExtension.ToDTO<CTRequestCustomer, RequestCustomerDTO>(entities, ToDTO);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this RequestCustomerDTO dto, CTRequestCustomer entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CTRequestCustomer ToEntity(this RequestCustomerDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestCustomer();

            entity.RequestCustomerId = dto.RequestCustomerId == null ? -1 : (int)dto.RequestCustomerId;
            entity.AccountManagerID = dto.AccountManagerID;
            entity.AccountTypeID = dto.AccountTypeID;
            entity.BasicAddressId = dto.BasicAddressId;
            entity.BillingAddressId = dto.BillingAddressId;
            entity.BillingFrequencyDayOrder = dto.BillingFrequencyDayOrder;
            entity.BillingFrequencyID = dto.BillingFrequencyID;
            entity.CardCentreID = dto.CardCentreID;
            entity.ClassificationId = dto.ClassificationId;
            entity.CompanyID = dto.CompanyID;
            entity.CustomerTypeID = dto.CustomerTypeID;
            entity.FamilyID = dto.FamilyID;
            entity.FinancialAccountNo = dto.FinancialAccountNo;
            entity.FinancialAccountTypeID = dto.FinancialAccountTypeID;
            entity.IdentificationID = dto.IdentificationType;
            entity.IdentificationTypeID = dto.IdentificationTypeID;
            entity.IsActive = dto.IsActive == null ? 0 : 1;
            entity.IsVIP = dto.IsVIP??0;
            entity.LastLocationID = dto.LastUpdatedLocationID;
            entity.Name = dto.Name;
            entity.NationalID = dto.NationalID;
            entity.NationalityID = dto.NationalityID;
            entity.NotificationThreshold = dto.NotificationThreshold;
            entity.PaymentTerms = dto.PaymentTerms;
            entity.RequestID = dto.RequestID;
            entity.RequestSourceTypeID = dto.RequestSourceTypeID;
            entity.ShippingAddressId = dto.ShippingAddressId;
            entity.SuspensionThreshold = dto.SuspensionThreshold;
            entity.UnitID = dto.UnitID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.EnableDefaultBeneficiary = dto.EnableDefaultBeneficiary == false ? 0 : 1;
            entity.MonthlyVolumeID = dto.MonthlyVolumeID;
            entity.IsPremier = dto.IsPremier;
            entity.GENDER = dto.Gender;
            entity.DATEOFBIRTH = dto.DateOfBirth;
            entity.IsEmployer = dto.IsEmployer == true ? 1 : 0 ;
            entity.CustBillFrequency = dto.CustomBillFrequency;
            entity.ContractNumber = dto.ContractNumber;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestCustomer> ToEntities(this IEnumerable<RequestCustomerDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRequestCustomer, RequestCustomerDTO>(dtos, ToEntity);
        }


    }
}
