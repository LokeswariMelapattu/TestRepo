using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerInfo"/> and <see cref="CustomerSearchDTO"/>.
    /// </summary>
    public static partial class CustomerSearchMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerSearchDTO"/> converted from <see cref="CTCustomerInfo"/>.</param>
        static partial void OnDTO(this CTCustomerInfo entity, CustomerSearchDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerInfo"/> converted from <see cref="CustomerSearchDTO"/>.</param>
        static partial void OnEntity(this CustomerSearchDTO dto, CTCustomerInfo entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerSearchDTO"/> to an instance of <see cref="CTCustomerInfo"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerSearchDTO"/> to convert.</param>
        public static CTCustomerInfo ToEntity(this CustomerSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerInfo();

            entity.AccountType = dto.AccountType;
            entity.AccountTypeID = dto.AccountTypeID;
            entity.CompanyID = dto.CompanyID;
            entity.CustomerClassification = dto.CustomerClassification;
            entity.CustomerClassificationID = dto.CustomerClassificationID;
            entity.CustomerID = dto.CustomerID;
            entity.Code = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.MobileNumber = dto.MobileNumber;
            entity.RegisterFrom = dto.RegisterFrom == System.DateTime.MinValue ? null : dto.RegisterFrom;
            entity.RegisterTo = dto.RegisterTo == System.DateTime.MinValue ? null : dto.RegisterTo;
            entity.RegistrationDate = dto.RegistrationDate == System.DateTime.MinValue ? null : dto.RegistrationDate;
            entity.StatusID = dto.StatusID;
            entity.StatusName = dto.StatusName;
            entity.NationalID = dto.NationalID;
            entity.FINANCIAL_ACCOUNT_NUMBER = dto.FinancialID;
            entity.UserID = dto.UserID;
            entity.EmployeeID = dto.EmployeeID;
            entity.TokenCode = dto.TokenCode;
            entity.IsSubscribed = dto.IsSubscribed;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerInfo"/> to an instance of <see cref="CustomerSearchDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerInfo"/> to convert.</param>
        public static CustomerSearchDTO ToDTO(this CTCustomerInfo entity)
        {
            if (entity == null) return null;

            var dto = new CustomerSearchDTO();

            dto.AccountType = entity.AccountType;
            dto.AccountTypeID = entity.AccountTypeID;
            dto.CompanyID = entity.CompanyID;
            dto.CustomerClassification = entity.CustomerClassification;
            dto.CustomerClassificationID = entity.CustomerClassificationID;
            dto.CustomerID = entity.CustomerID;
            dto.CustomerCode = entity.Code;
            dto.CustomerName = entity.CustomerName;
            dto.MobileNumber = entity.MobileNumber;
            dto.RegisterFrom = entity.RegisterFrom;
            dto.RegisterTo = entity.RegisterTo;
            dto.RegistrationDate = entity.RegistrationDate;
            dto.StatusID = entity.StatusID;
            dto.StatusName = entity.StatusName;
            dto.NationalID = entity.NationalID;
            dto.FinancialID = entity.FINANCIAL_ACCOUNT_NUMBER;
            dto.UserID = entity.UserID;
            dto.IdType = entity.IdType;
            dto.IsSubscribed = entity.IsSubscribed;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerSearchDTO"/> to an instance of <see cref="CTCustomerInfo"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerInfo> ToEntities(this IEnumerable<CustomerSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerInfo, CustomerSearchDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerInfo"/> to an instance of <see cref="CustomerSearchDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerSearchDTO> ToDTOs(this IEnumerable<CTCustomerInfo> entities)
        {
            return LinqExtension.ToDTO<CTCustomerInfo, CustomerSearchDTO>(entities, ToDTO);
        }

    }
}
