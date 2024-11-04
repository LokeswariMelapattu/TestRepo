using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerDetails"/> and <see cref="CustomerARDTO"/>.
    /// </summary>
    public static partial class CTCustomerDetailsMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerARDTO"/> converted from <see cref="CTCustomerDetails"/>.</param>
        static partial void OnDTO(this CTCustomerDetails entity, CustomerARDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerDetails"/> converted from <see cref="CustomerARDTO"/>.</param>
        static partial void OnEntity(this CustomerARDTO dto, CTCustomerDetails entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerARDTO"/> to an instance of <see cref="CTCustomerDetails"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerARDTO"/> to convert.</param>
        public static CTCustomerDetails ToEntity(this CustomerARDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerDetails();

            entity.CustomerID = dto.CustomerID;
            entity.CustomerName = dto.CustomerName;
            entity.BillingAddressID = dto.BillingAddressID;
            entity.BillingAddress = dto.BillingAddress;
            entity.AccountStatus = dto.AccountStatus;
            entity.Customer_Class = dto.Customer_Class;
            entity.RegistrationDate = dto.RegistrationDate;
            entity.AccPrimaryContactName = dto.AccPrimaryContactName;
            entity.AccNationalID = dto.AccNationalID;
            entity.AccountManagerID = dto.AccountManagerID;
            entity.AccountManager = dto.AccountManager;
            entity.AccManagerEmail = dto.AccManagerEmail;
            entity.AccManagerPhone = dto.AccManagerPhone;
            entity.AccManagerJobTitle = dto.AccManagerJobTitle;
            entity.FinancialAccountNumber = dto.FinancialAccountNumber;
            entity.CustomerAccountTypeID = dto.CustomerAccountTypeID;
            entity.CustomerAccountType = dto.CustomerAccountType;
            entity.CustomerAccountType_ar = dto.CustomerAccountTypeAR;
            entity.AccManagerMobile = dto.AccManagerMobile;
            entity.AccManagerFax = dto.AccManagerFax;
            entity.CorporateAddressID = dto.CorporateAddressID;
            entity.CorporateAddress = dto.CorporateAddress;
            entity.CorporateAddressEmirateID = dto.CorporateAddressEmirateID;
            entity.CorporateAddressEmirate = dto.CorporateAddressEmirate;
            entity.CorporateAddressAreaID = dto.CorporateAddressAreaID;
            entity.CorporateAddressArea = dto.CorporateAddressArea;
            entity.CorporateAddressPhone = dto.CorporateAddressPhone;
            entity.CorporateAddressFax = dto.CorporateAddressFax;
            entity.SuspensionThreshold = dto.SuspensionThreshold;
            entity.BillingAddressEmirateID = dto.BillingAddressEmirateID;
            entity.BillingAddressEmirate = dto.BillingAddressEmirate;
            entity.BillingAddressAreaID = dto.BillingAddressAreaID;
            entity.BillingAddressArea = dto.BillingAddressArea;
            entity.BillingAddressPhone = dto.BillingAddressPhone;
            entity.BillingAddressFax = dto.BillingAddressFax;
            entity.ShippingAddressID = dto.ShippingAddressID;
            entity.ShippingAddress = dto.ShippingAddress;
            entity.ShippingAddressEmirateID = dto.ShippingAddressEmirateID;
            entity.ShippingAddressEmirate = dto.ShippingAddressEmirate;
            entity.ShippingAddressAreaID = dto.ShippingAddressAreaID;
            entity.ShippingAddressArea = dto.ShippingAddressArea;
            entity.ShippingAddressPhone = dto.ShippingAddressPhone;
            entity.ShippingAddressFax = dto.ShippingAddressFax;
            entity.PaymentTerms = dto.PaymentTerms;
            entity.ISMULTIPLEBILLTODETAILS = dto.ISMULTIPLEBILLTODETAILS;
            entity.MAXCREDITLIMIT = dto.MAXCREDITLIMIT;
            entity.CorporateAddressEmirate_AR = dto.CorporateAddressEmirate_Ar;
            entity.CorporateAddressArea_AR = dto.CorporateAddressArea_Ar;
            entity.BillingAddressEmirate_AR = dto.BillingAddressEmirate_Ar;
            entity.BillingAddressArea_AR = dto.BillingAddressArea_Ar;
            entity.ShippingAddressEmirate_AR = dto.ShippingAddressEmirate_Ar;
            entity.ShippingAddressArea_AR = dto.ShippingAddressArea_Ar;
            entity.CompanyRegistrationNo = dto.CompanyRegistrationNo;


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerDetails"/> to an instance of <see cref="CustomerARDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerDetails"/> to convert.</param>
        public static CustomerARDTO ToDTO(this CTCustomerDetails entity)
        {
            if (entity == null) return null;

            var dto = new CustomerARDTO();

            dto.CustomerID = entity.CustomerID;
            dto.CustomerName = entity.CustomerName;
            dto.BillingAddressID = entity.BillingAddressID;
            dto.BillingAddress = entity.BillingAddress;
            dto.AccountStatus = entity.AccountStatus;
            dto.Customer_Class = entity.Customer_Class;
            dto.RegistrationDate = entity.RegistrationDate;
            dto.AccPrimaryContactName = entity.AccPrimaryContactName;
            dto.AccNationalID = entity.AccNationalID;
            dto.AccountManagerID = entity.AccountManagerID;
            dto.AccountManager = entity.AccountManager;
            dto.AccManagerEmail = entity.AccManagerEmail;
            dto.AccManagerPhone = entity.AccManagerPhone;
            dto.AccManagerJobTitle = entity.AccManagerJobTitle;
            dto.FinancialAccountNumber = entity.FinancialAccountNumber;
            dto.CustomerAccountTypeID = entity.CustomerAccountTypeID;
            dto.CustomerAccountType = entity.CustomerAccountType;
            dto.CustomerAccountTypeAR = entity.CustomerAccountType_ar;
            dto.AccManagerMobile = entity.AccManagerMobile;
            dto.AccManagerFax = entity.AccManagerFax;
            dto.CorporateAddressID = entity.CorporateAddressID;
            dto.CorporateAddress = entity.CorporateAddress;
            dto.CorporateAddressEmirateID = entity.CorporateAddressEmirateID;
            dto.CorporateAddressEmirate = entity.CorporateAddressEmirate;
            dto.CorporateAddressAreaID = entity.CorporateAddressAreaID;
            dto.CorporateAddressArea = entity.CorporateAddressArea;
            dto.CorporateAddressPhone = entity.CorporateAddressPhone;
            dto.CorporateAddressFax = entity.CorporateAddressFax;
            dto.SuspensionThreshold = entity.SuspensionThreshold;
            dto.BillingAddressEmirateID = entity.BillingAddressEmirateID;
            dto.BillingAddressEmirate = entity.BillingAddressEmirate;
            dto.BillingAddressAreaID = entity.BillingAddressAreaID;
            dto.BillingAddressArea = entity.BillingAddressArea;
            dto.BillingAddressPhone = entity.BillingAddressPhone;
            dto.BillingAddressFax = entity.BillingAddressFax;
            dto.ShippingAddressID = entity.ShippingAddressID;
            dto.ShippingAddress = entity.ShippingAddress;
            dto.ShippingAddressEmirateID = entity.ShippingAddressEmirateID;
            dto.ShippingAddressEmirate = entity.ShippingAddressEmirate;
            dto.ShippingAddressAreaID = entity.ShippingAddressAreaID;
            dto.ShippingAddressArea = entity.ShippingAddressArea;
            dto.ShippingAddressPhone = entity.ShippingAddressPhone;
            dto.ShippingAddressFax = entity.ShippingAddressFax;
            dto.PaymentTerms = entity.PaymentTerms;
            dto.ISMULTIPLEBILLTODETAILS = entity.ISMULTIPLEBILLTODETAILS;
            dto.MAXCREDITLIMIT = entity.MAXCREDITLIMIT;
            dto.CorporateAddressEmirate_Ar = entity.CorporateAddressEmirate_AR ;
            dto.CorporateAddressArea_Ar = entity.CorporateAddressArea_AR ; 
            dto.BillingAddressEmirate_Ar= entity.BillingAddressEmirate_AR; 
            dto.BillingAddressArea_Ar = entity.BillingAddressArea_AR;
            dto.ShippingAddressEmirate_Ar =  entity.ShippingAddressEmirate_AR;
            dto.ShippingAddressArea_Ar = entity.ShippingAddressArea_AR;
            dto.CompanyRegistrationNo = entity.CompanyRegistrationNo;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerARDTO"/> to an instance of <see cref="CTCustomerDetails"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerDetails> ToEntities(this IEnumerable<CustomerARDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerDetails, CustomerARDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerDetails"/> to an instance of <see cref="CustomerARDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerARDTO> ToDTOs(this IEnumerable<CTCustomerDetails> entities)
        {
            return LinqExtension.ToDTO<CTCustomerDetails, CustomerARDTO>(entities, ToDTO);
        }

    }
}
