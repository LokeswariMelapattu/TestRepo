using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class CustomerCardSearchMapper
    {
        static partial void OnDTO(this CTCustomerCardSearch entity, CustomerCardSearchDTO dto);

        static partial void OnEntity(this CustomerCardSearchDTO dto, CTCustomerCardSearch entity);

        public static CTCustomerCardSearch ToEntity(this CustomerCardSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerCardSearch();

            entity.PersonalizationOrderID = dto.PersonalizationOrderID;
            entity.PersonalizationRequestNumber = dto.PersonalizationRequestNumber;
            entity.AppointmentDate = dto.AppointmentDate;
            entity.CustomerName = dto.CustomerName;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerType = dto.Type;
            entity.CustomerTypeID = dto.CustomerTypeID;
            entity.CustomerType = dto.CustomerType;
            entity.CustomerTypeAR = dto.CustomerTypeAR;
            entity.RecipientIdentityType = dto.RecipientIdentityType;
            entity.RecipientIdentityTypeAR = dto.RecipientIdentityTypeAR;
            entity.RecipientIdentityID = dto.RecipientIdentityID;
            entity.IDENTITY_NUMBER = dto.RecipientIdentityNumber;
            entity.CustomerCode = dto.CustomerCode;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.TokenCode = dto.TokenCode;
            entity.TokenType = dto.TokenType;
            entity.TokenTypeAR = dto.TokenTypeAR;
            entity.ROW_NUM = dto.RowNum;

            dto.OnEntity(entity);

            return entity;
        }

        public static CustomerCardSearchDTO ToDTO(this CTCustomerCardSearch entity)
        {
            if (entity == null) return null;

            var dto = new CustomerCardSearchDTO();

            dto.PersonalizationOrderID = entity.PersonalizationOrderID;
            dto.PersonalizationRequestNumber = entity.PersonalizationRequestNumber;
            dto.AppointmentDate = entity.AppointmentDate;
            dto.CustomerName = entity.CustomerName;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.Type = entity.CustomerType;
            dto.CustomerTypeID = entity.CustomerTypeID;
            dto.CustomerType = entity.CustomerType;
            dto.CustomerTypeAR = entity.CustomerTypeAR;
            dto.RecipientIdentityType = entity.RecipientIdentityType;
            dto.RecipientIdentityTypeAR = entity.RecipientIdentityTypeAR;
            dto.RecipientIdentityID = entity.RecipientIdentityID;
            dto.RecipientIdentityNumber = entity.IDENTITY_NUMBER;
            dto.CustomerCode = entity.CustomerCode;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.TokenCode = entity.TokenCode;
            dto.TokenType = entity.TokenType;
            dto.TokenTypeAR = entity.TokenTypeAR;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTCustomerCardSearch> ToEntities(this IEnumerable<CustomerCardSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerCardSearch, CustomerCardSearchDTO>(dtos, ToEntity);
        }

        public static List<CustomerCardSearchDTO> ToDTOs(this IEnumerable<CTCustomerCardSearch> entities)
        {
            return LinqExtension.ToDTO<CTCustomerCardSearch, CustomerCardSearchDTO>(entities, ToDTO);
        }

    }
}

