using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerBeneficiary"/> and <see cref="BeneficiarySearchDTO"/>.
    /// </summary>
    public static partial class CTCustomerBeneficiaryMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BeneficiarySearchDTO"/> converted from <see cref="CTCustomerBeneficiary"/>.</param>
        static partial void OnDTO(this CTCustomerBeneficiary entity, BeneficiarySearchDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBeneficiary"/> converted from <see cref="BeneficiarySearchDTO"/>.</param>
        static partial void OnEntity(this BeneficiarySearchDTO dto, CTCustomerBeneficiary entity);

        /// <summary>
        /// Converts this instance of <see cref="BeneficiarySearchDTO"/> to an instance of <see cref="CTCustomerBeneficiary"/>.
        /// </summary>
        /// <param name="dto"><see cref="BeneficiarySearchDTO"/> to convert.</param>
        public static CTCustomerBeneficiary ToCTEntity(this BeneficiarySearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerBeneficiary();

            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.BENEFICIARY_CODE = dto.BeneficiaryCode;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.CUSTOMER_GROUP = dto.CustomerGroup;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.CUSTOMER_CODE = dto.CustomerCode;
            entity.IS_VIP = (short)(dto.IsVIP.HasValue && dto.IsVIP.Value ? 1 : 0);
            entity.MOBILE = dto.Mobile;
            entity.NATIONAL_ID = dto.NationalID;
            entity.NATIONALILTY_ID = dto.NationalilityID;
            entity.NATIONALITY_NAME = dto.NationalityName;
            entity.REGISTER_FROM_DATE = dto.RegisterFromDate == DateTime.MinValue ? null : dto.RegisterFromDate;
            entity.REGISTER_TO_DATE = dto.RegiserToDate == DateTime.MinValue ? null : dto.RegiserToDate;
            entity.REGISTRATION_DATE = dto.RegistrationDate == DateTime.MinValue ? null : dto.RegistrationDate;
            entity.STATUS_ID = dto.StatusID;
            entity.STATUS_NAME = dto.StatusName;
            entity.EmployeeID = dto.EmployeeID;

            dto.OnEntity(entity);

            return entity;
        }

        public static CTCustomerBenSearch ToCBEntity(this CustomerBeneficiarySearchDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CTCustomerBenSearch
            {
                BENEFICIARY_ID = dto.BeneficiaryID,
                BENEFICIARY_CODE = dto.BeneficiaryCode,
                BENEFICIARY_NAME = dto.BeneficiaryName,
                CUSTOMER_ID = dto.CustomerID,
                CUSTOMER_CODE = dto.CustomerCode,
                CUSTOMER_NAME = dto.CustomerName,
                UserID = dto.UserID
            };
        }

        public static CustomerBeneficiarySearchDTO ToCBDTO(this CTCustomerBenSearch entity)
        {
            if (entity == null)
                return null;

            var dto = new CustomerBeneficiarySearchDTO
            {
                BeneficiaryID = entity.BENEFICIARY_ID,
                BeneficiaryCode=entity.BENEFICIARY_CODE,
                BeneficiaryName = entity.BENEFICIARY_NAME,
                CustomerID = entity.CUSTOMER_ID,
                CustomerName = entity.CUSTOMER_NAME,
                CustomerCode = entity.CUSTOMER_CODE,
                UserID = entity.UserID
            };

            return dto;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerBeneficiary"/> to an instance of <see cref="BeneficiarySearchDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBeneficiary"/> to convert.</param>
        public static BeneficiarySearchDTO ToDTO(this CTCustomerBeneficiaryResult entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiarySearchDTO();

            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.BeneficiaryCode = entity.BENEFICIARY_CODE;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.CustomerGroup = entity.CUSTOMER_GROUP;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.CustomerCode = entity.CUSTOMER_CODE;
            dto.IsVIP = (entity.IS_VIP.HasValue && entity.IS_VIP.Value == 1);
            dto.Mobile = entity.MOBILE;
            dto.NationalID = entity.NATIONAL_ID;
            dto.NationalilityID = entity.NATIONALILTY_ID;
            dto.NationalityName = entity.NATIONALITY_NAME;
            dto.RegisterFromDate = entity.REGISTER_FROM_DATE;
            dto.RegiserToDate = entity.REGISTER_TO_DATE;
            dto.RegistrationDate = entity.REGISTRATION_DATE;
            dto.StatusID = entity.STATUS_ID;
            dto.StatusName = entity.STATUS_NAME;

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="BeneficiarySearchDTO"/> to an instance of <see cref="CTCustomerBeneficiary"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerBeneficiary> ToEntities(this IEnumerable<BeneficiarySearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBeneficiary, BeneficiarySearchDTO>(dtos, ToCTEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerBeneficiary"/> to an instance of <see cref="BeneficiarySearchDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<BeneficiarySearchDTO> ToDTOs(this IEnumerable<CTCustomerBeneficiaryResult> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBeneficiaryResult, BeneficiarySearchDTO>(entities, ToDTO);
        }

        public static List<CustomerBeneficiarySearchDTO> ToCBDTOs(this IEnumerable<CTCustomerBenSearch> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBenSearch, CustomerBeneficiarySearchDTO>(entities, ToCBDTO);
        }
    }
}
