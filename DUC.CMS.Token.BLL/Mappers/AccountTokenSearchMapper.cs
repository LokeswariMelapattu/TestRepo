using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class AccountTokenSearchMapper
    {

        static partial void OnDTO(this CTTokenAccountSearch entity, TokenSearchDTO dto);
        public static TokenSearchDTO ToDTO(this CTTokenAccountSearch entity)
        {
            if (entity == null) return null;

            var dto = new TokenSearchDTO();

            dto.TokenId = entity.TOKEN_ID;
            dto.TokenCode = entity.TOKEN_CODE;
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
            dto.CustomerName = entity.CustomerName;
            dto.ExpiryDate = entity.EXPIRY_DATE;
            dto.IdNumber = entity.IdNumber;
            //dto.OrderCreatorUser = entity.OrderCreatorUser;
            dto.VehicleNo = entity.VehicleNo;
            entity.OnDTO(dto);

            return dto;
        }
        public static List<TokenSearchDTO> ToADTOs(this IEnumerable<CTTokenAccountSearch> entities)
        {
            return LinqExtension.ToDTO<CTTokenAccountSearch, TokenSearchDTO>(entities, ToDTO);
        }


        static partial void OnEntity(this AccountTokenSearchDTO dto, CTAccountTokenSearch entity);
        public static CTAccountTokenSearch ToAEntity(this AccountTokenSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTAccountTokenSearch
            {
                BeneficiaryName = dto.BeneficiaryName,
                CustomerName = dto.CustomerName,
                IDNumber = dto.IDNumber,
                RegisterFromDate = dto.RegisterFromDate,
                RegisterToDate = dto.RegisterToDate,
                RestrictionGroupID = dto.RestrictionGroupID,
                TokenCode = dto.TokenCode,
                TokenName = dto.TokenName,
                TokenSerial = dto.TokenSerial,
                TokenStatusID = dto.TokenStatusID,
                TokenTypeID = dto.TokenTypeID,
                UserId = dto.UserId,
                VehicleNo = dto.VehicleNo,
                EmployeeID = dto.EmployeeID
            };
            dto.OnEntity(entity);

            return entity;
        }


    }
}




