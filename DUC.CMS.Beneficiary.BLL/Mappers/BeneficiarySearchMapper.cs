using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class BeneficiarySearchMapper
    {

        static partial void OnDTO(this CTCustomerBeneficiaryResult entity, BeneficiarySearchDTO dto);

        static partial void OnEntity(this BeneficiarySearchDTO dto, CTCustomerBeneficiary entity);

        public static CTCustomerBeneficiary ToEntity(this BeneficiarySearchDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTCustomerBeneficiary();

            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.BENEFICIARY_CODE = dto.BeneficiaryCode;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.CUSTOMER_CODE = dto.CustomerCode;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.MOBILE = dto.MobileNumber;
            entity.STATUS_ID = dto.StatusID;
            entity.STATUS_NAME = dto.StatusName;
            entity.NATIONAL_ID = dto.NationalID;
            entity.NATIONALILTY_ID = dto.NationalityID;
            entity.NATIONALITY_NAME = dto.Nationality;
            entity.CUSTOMER_GROUP = dto.CustomerGroup;
            entity.REGISTRATION_DATE = dto.RegistrationDate == System.DateTime.MinValue ? null : dto.RegistrationDate;
            entity.REGISTER_FROM_DATE = dto.RegisterFrom == System.DateTime.MinValue ? null : dto.RegisterFrom;
            entity.REGISTER_TO_DATE = dto.RegisterTo == System.DateTime.MinValue ? null : dto.RegisterTo;
            entity.EmployeeID = dto.EmployeeID;
            entity.TokenCode = dto.TokenCode;
            entity.IdNumber = dto.IdNumber;
            entity.CustomerName = dto.CustomerName;
            if (dto.IsVIP == null)
                entity.IS_VIP = null;
            else
                entity.IS_VIP = Convert.ToInt16(dto.IsVIP);
            entity.UserID = dto.UserID;

            dto.OnEntity(entity);

            return entity;
        }

        public static BeneficiarySearchDTO ToDTO(this CTCustomerBeneficiaryResult entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiarySearchDTO();

            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.BeneficiaryCode=entity.BENEFICIARY_CODE;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.CustomerCode = entity.CUSTOMER_CODE;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.MobileNumber = entity.MOBILE;
            dto.StatusID = entity.STATUS_ID;
            dto.StatusName = entity.STATUS_NAME;
            dto.NationalID = entity.NATIONAL_ID;
            dto.NationalityID = entity.NATIONALILTY_ID;
            dto.Nationality = entity.NATIONALITY_NAME;
            dto.CustomerGroup = entity.CUSTOMER_GROUP;
            dto.RegisterFrom = entity.REGISTER_FROM_DATE;
            dto.RegisterTo = entity.REGISTER_TO_DATE;
            dto.RegistrationDate = entity.REGISTRATION_DATE;
            dto.EmployeeID = entity.EmployeeID;
            dto.IsVIP = Convert.ToBoolean(entity.IS_VIP);
            dto.UserID = entity.UserID;
            dto.IdNumber = entity.IdNumber;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTCustomerBeneficiary> ToEntities(this IEnumerable<BeneficiarySearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBeneficiary, BeneficiarySearchDTO>(dtos, ToEntity);
        }

        public static List<BeneficiarySearchDTO> ToDTOs(this IEnumerable<CTCustomerBeneficiaryResult> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBeneficiaryResult, BeneficiarySearchDTO>(entities, ToDTO);
        }

    }
}
