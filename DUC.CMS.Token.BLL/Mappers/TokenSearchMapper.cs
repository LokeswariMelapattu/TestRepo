using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class CustomerTokenSearchMapper
    {

        static partial void OnDTO(this CTCustomerTokenSearch entity, CustomerTokenSearchDTO dto);

        static partial void OnEntity(this CustomerTokenSearchDTO dto, CTCustomerTokenSearchInput entity);

        public static CTCustomerTokenSearchInput ToEntity(this CustomerTokenSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerTokenSearchInput();

            entity.TOKEN_ID = dto.TokenId;
            entity.CURRENT_TOKEN_ID = dto.CurrentTokenId;
            entity.CODE = dto.TokenCode;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.CUSTOMER_CODE = dto.CustomerCode;
            entity.CUSTOMER_NAME = dto.CustomerName;
            entity.BENEFICIARY_CODE = dto.BeneficiaryCode;
            entity.TOKEN_NAME = dto.TokenName;
            entity.BENEFICIARY_ID = dto.BeneficiaryId;
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TOKEN_STATUS_ID = dto.StatusId;
            entity.REGISTER_FROM_DATE = dto.RegisterFrom == DateTime.MinValue ? null : dto.RegisterFrom;
            entity.REGISTER_TO_DATE = dto.RegisterTo == DateTime.MinValue ? null : dto.RegisterTo;
            entity.TOKEN_TYPE_ID = dto.TokenTypeId;
            entity.SERIAL = dto.Serial;
            entity.CUSTOMER_ID = dto.CustomerId;
            entity.UserID = dto.UserID;
            entity.EMPLOYEE_ID = dto.EmployeeID;
            entity.IdNumber = dto.IdNumber;
            entity.CUSTOMER_CODE = dto.CustomerCode;
            entity.CUSTOMER_NAME = dto.CustomerName;
            

            dto.OnEntity(entity);

            return entity;
        }

        public static CustomerTokenSearchDTO ToDTO(this CTCustomerTokenSearch entity)
        {
            if (entity == null) return null;

            var dto = new CustomerTokenSearchDTO();

            dto.TokenId = entity.TOKEN_ID;
            dto.TokenCode = entity.CODE;
            dto.TokenName = entity.TOKEN_NAME;
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.RegistrationGroup = entity.RESTRICTION_GROUP_NAME;
            dto.StatusId = entity.TOKEN_STATUS_ID;
            dto.StatusNameAr = entity.TOKEN_STATUS_AR_NAME;
            dto.StatusNameEn = entity.TOKEN_STATUS_EN_NAME;
            dto.RegistrationDate = entity.REGISTERATION_DATE;
            dto.TokenTypeId = entity.TOKEN_TYPE_ID;
            dto.TokenTypeNameAr = entity.TOKEN_TYPE_AR_NAME;
            dto.TokenTypeNameEn = entity.TOKEN_TYPE_EN_NAME;
            dto.Serial = entity.SERIAL;
            dto.CustomerId = entity.CUSTOMER_ID;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.EomDifferentialPricing = entity.EOMDifferentialPricing;
            dto.OnlineDifferentialPricing = entity.OnlineDifferentialPricing;
            dto.ExpiryDate = entity.EXPIRY_DATE;
            dto.IdNumber = entity.IdNumber;
            dto.CustomerCode = entity.CUSTOMER_CODE;
            dto.CustomerName = entity.CUSTOMER_NAME;
            dto.BeneficiaryCode = entity.BENEFICIARY_CODE;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTCustomerTokenSearchInput> ToEntities(this IEnumerable<CustomerTokenSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerTokenSearchInput, CustomerTokenSearchDTO>(dtos, ToEntity);
        }

        public static List<CustomerTokenSearchDTO> ToDTOs(this IEnumerable<CTCustomerTokenSearch> entities)
        {
            return LinqExtension.ToDTO<CTCustomerTokenSearch, CustomerTokenSearchDTO>(entities, ToDTO);
        }


    }

    public static partial class TokenSearchMapper
    {

        static partial void OnDTO(this CTTokenSearch entity, TokenSearchDTO dto);

        static partial void OnEntity(this TokenSearchDTO dto, CTTokenSearchInput entity);

        public static CTTokenSearchInput ToEntity(this TokenSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTokenSearchInput();

            entity.TOKEN_ID = dto.TokenId;
            entity.CURRENT_TOKEN_ID = dto.CurrentTokenId;
            entity.CODE = dto.TokenCode;
            entity.TOKEN_NAME = dto.TokenName;
            entity.BENEFICIARY_ID = dto.BeneficiaryId;
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.TOKEN_STATUS_ID = dto.StatusId;
            entity.REGISTER_FROM_DATE = dto.RegisterFrom == DateTime.MinValue ? null : dto.RegisterFrom;
            entity.REGISTER_TO_DATE = dto.RegisterTo == DateTime.MinValue ? null : dto.RegisterTo;
            entity.TOKEN_TYPE_ID = dto.TokenTypeId;
            entity.SERIAL = dto.Serial;
            entity.CUSTOMER_ID = dto.CustomerId;
            entity.UserID = dto.UserID;
            entity.EMPLOYEE_ID = dto.EmployeeID;
            entity.IdNumber = dto.IdNumber;

            dto.OnEntity(entity);

            return entity;
        }

        public static TokenSearchDTO ToDTO(this CTTokenSearch entity)
        {
            if (entity == null) return null;

            var dto = new TokenSearchDTO();

            dto.TokenId = entity.TOKEN_ID;
            dto.TokenCode = entity.CODE;
            dto.TokenName = entity.TOKEN_NAME;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.RegistrationGroup = entity.RESTRICTION_GROUP_NAME;
            dto.StatusId = entity.TOKEN_STATUS_ID;
            dto.StatusNameAr = entity.TOKEN_STATUS_AR_NAME;
            dto.StatusNameEn = entity.TOKEN_STATUS_EN_NAME;
            dto.RegistrationDate = entity.REGISTERATION_DATE;
            dto.TokenTypeId = entity.TOKEN_TYPE_ID;
            dto.TokenTypeNameAr = entity.TOKEN_TYPE_AR_NAME;
            dto.TokenTypeNameEn = entity.TOKEN_TYPE_EN_NAME;
            dto.Serial = entity.SERIAL;
            dto.CustomerId = entity.CUSTOMER_ID;
            dto.EomDifferentialPricing = entity.EOMDifferentialPricing;
            dto.OnlineDifferentialPricing = entity.OnlineDifferentialPricing;
            dto.ExpiryDate = entity.EXPIRY_DATE;
            dto.IdNumber = entity.IdNumber;
            entity.OnDTO(dto);

            return dto;
        }      

        public static List<CTTokenSearchInput> ToEntities(this IEnumerable<TokenSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTokenSearchInput, TokenSearchDTO>(dtos, ToEntity);
        }

        public static List<TokenSearchDTO> ToDTOs(this IEnumerable<CTTokenSearch> entities)
        {
            return LinqExtension.ToDTO<CTTokenSearch, TokenSearchDTO>(entities, ToDTO);
        }

     
    }
}




