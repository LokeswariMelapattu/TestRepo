using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    //CTSearchTokenIssuanceResult SearchTokenIssuance(CTSearchTokenIssuance
    public static partial class SearchTokenIssuanceMapper
    {
        static partial void OnDTO(this CTSearchTokenIssuanceResult entity, SearchTokenIssuanceResultDTO dto);

        static partial void OnEntity(this SearchTokenIssuanceDTO dto, CTSearchTokenIssuance entity);

        public static CTSearchTokenIssuance ToEntity(this SearchTokenIssuanceDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchTokenIssuance();
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.TokenStatusID = dto.TokenStatusID;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.CompanyRegistrationID = dto.CompanyRegistrationID;
            entity.CustomerstatusID = dto.CustomerstatusID;
            entity.ClassificationID = dto.ClassificationID;
            entity.CustomerAccountTypeID = dto.CustomerAccountTypeID;
            entity.EmployeeNumber = dto.EmployeeNumber;
            entity.MobileNumber = dto.MobileNumber;
            entity.RegsiterFromDate = dto.RegsiterFromDate;
            entity.RegsiterToDate = dto.RegsiterToDate;
            entity.FinancialAccountNumber = dto.FinancialAccountNumber;

            dto.OnEntity(entity);
            return entity;
        }

        public static SearchTokenIssuanceResultDTO ToDTO(this CTSearchTokenIssuanceResult entity)
        {
            if (entity == null) return null;

            var dto = new SearchTokenIssuanceResultDTO();
            dto.TokenName = entity.TokenName;
            dto.CustomerCode = entity.CustomerCode;
            dto.MobileNumber = entity.MobileNumber;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.CustomerStatusID = entity.CustomerStatusID;
            dto.TokenSerial = entity.TokenSerial;
            dto.TokenCode = entity.TokenCode;
            dto.CustomerName = entity.CustomerName;
            dto.CompanyRegistrationID = entity.CompanyRegistrationID;
            dto.ClassificationID = entity.ClassificationID;
            dto.RegistrationDate = entity.RegistrationDate;
            dto.FinancialAccountNumber = entity.FinancialAccountNumber;
            dto.EmployeeNumber = entity.EmployeeNumber;
            dto.TokenType = entity.TokenType;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.TokenStatus = entity.TokenStatus;
            dto.TokenID = entity.TokenID;


            entity.OnDTO(dto);

            return dto;
        }


        public static List<SearchTokenIssuanceResultDTO> ToDTOs(this IEnumerable<CTSearchTokenIssuanceResult> entities)
        {
            return LinqExtension.ToDTO<CTSearchTokenIssuanceResult, SearchTokenIssuanceResultDTO>(entities, ToDTO);
        }

    }
}
