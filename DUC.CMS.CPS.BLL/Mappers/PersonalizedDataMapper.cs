using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PersonalizedDataMapper
    {
        static partial void OnDTO(this CTPersonalizedData entity, PersonalizedDataDTO dto);

        static partial void OnEntity(this PersonalizedDataDTO dto, CTPersonalizedData entity);

        public static CTPersonalizedData ToEntity(this PersonalizedDataDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPersonalizedData();

            entity.TOKEN_ID = dto.TokenID;
            entity.CardSerial = dto.CardSerial;
            entity.IS_VIP = Convert.ToInt16(dto.IsVIPAccess);
            entity.PRINTER_ID = dto.PrinterID;
            entity.CARD_CENTER_ID = dto.CardCentreID;
            entity.TOKEN_STATUS_ID = dto.TokenStatusID;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.BENEFICIARY_ID = dto.BenefiicaryID;
            entity.BeneficiaryCode = dto.BenefiicaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CUSTOMER_TYPE_ID = dto.CustomerTypeID;
            entity.CustomerType = dto.CustomerType;
            entity.CustomerTypeAr = dto.CustomerTypeAR;
            entity.TokenName = dto.TokenName;
            entity.TOKEN_CODE = dto.TokenCode;

            dto.OnEntity(entity);

            return entity;
        }

        public static PersonalizedDataDTO ToDTO(this CTPersonalizedData entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizedDataDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.CardSerial = entity.CardSerial;
            dto.IsVIPAccess = Convert.ToBoolean(entity.IS_VIP);
            dto.PrinterID = entity.PRINTER_ID;
            dto.CardCentreID = entity.CARD_CENTER_ID;
            dto.TokenStatusID = entity.TOKEN_STATUS_ID;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.BenefiicaryID = entity.BENEFICIARY_ID;
            dto.BenefiicaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.CustomerTypeID = entity.CUSTOMER_TYPE_ID;
            dto.CustomerType = entity.CustomerType;
            dto.CustomerTypeAR = entity.CustomerTypeAr;
            dto.TokenCode = entity.TOKEN_CODE;
            dto.TokenName = entity.TokenName;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPersonalizedData> ToEntities(this IEnumerable<PersonalizedDataDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPersonalizedData, PersonalizedDataDTO>(dtos, ToEntity);
        }

        public static List<PersonalizedDataDTO> ToDTOs(this IEnumerable<CTPersonalizedData> entities)
        {
            return LinqExtension.ToDTO<CTPersonalizedData, PersonalizedDataDTO>(entities, ToDTO);
        }
    }
}

