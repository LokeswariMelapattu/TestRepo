using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class BatchTokenMapper
    {
        static partial void OnDTO(this CTBatchToken entity, BatchTokenDTO dto);

        static partial void OnEntity(this BatchTokenDTO dto, CTBatchToken entity);
        static partial void OnEntity(this BatchTokenDTODetails dto, TOKEN entity);

        public static CTBatchToken ToEntity(this BatchTokenDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBatchToken();

            entity.CustomerID = dto.CustomerID;
            entity.BeneficiaryID = dto.BeneficiaryID;
            entity.TokenName = dto.TokenName;
            entity.TokenTypeId = dto.TokenTypeId;
            entity.ExpiryDate = dto.ExpiryDate;
            entity.RestrictionGroupId = dto.RestrictionGroupId;
            entity.TokenStatusId = dto.TokenStatusId;
            entity.TokenStatusReasonId = dto.TokenStatusReasonId;
            entity.IsActive = Convert.ToInt16(dto.IsActive);
            entity.CardCentreID = dto.CardCentreID;
            entity.AppointmentDate = dto.AppointmentDate;
            entity.ReasonID = dto.PersonalizationReasonID;
            entity.PersonalizationOrderStatusID = dto.PersonalizationOrderStatusID;
            entity.PersonalizationOrderTypeID = dto.PersonalizationOrderTypeID;
            entity.IdentificationTypeID = dto.IdentificationTypeID;
            entity.IdentityNumber = dto.IdentificationNumber;
            entity.PersonalizationOrderID = dto.PersonalizationOrderID;

            dto.OnEntity(entity);

            return entity;
        }
        public static TOKEN ToEntity(this BatchTokenDTODetails dto)
        {
            if (dto == null) return null;

            var entity = new TOKEN();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.NAME = dto.TokenName;
            entity.TOKEN_TYPE_ID =(int)dto.TokenTypeId;
            entity.EXPIRY_DATE = dto.ExpiryDate;
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupId;
            entity.TOKEN_STATUS_ID = dto.TokenStatusId;
            entity.TOKEN_STATUS_REASON_ID = dto.TokenStatusReasonId;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            //entity.CardCentreID = dto.CardCentreID;
           // entity.a = dto.AppointmentDate;
           // entity.TOKEN_STATUS_REASON_ID = dto.PersonalizationReasonID;
           // entity.PersonalizationOrderStatusID = dto.PersonalizationOrderStatusID;
           // entity.PersonalizationOrderTypeID = dto.PersonalizationOrderTypeID;
            //entity.IdentificationTypeID = dto.IdentificationTypeID;
          //  entity.IdentityNumber = dto.IdentificationNumber;
           // entity.PersonalizationOrderID = dto.PersonalizationOrderID; 
            dto.OnEntity(entity);

            return entity;
        }

        public static BatchTokenDTO ToDTO(this CTBatchToken entity)
        {
            if (entity == null) return null;

            var dto = new BatchTokenDTO();

            dto.CustomerID = entity.CustomerID;
            dto.BeneficiaryID = entity.BeneficiaryID;
            dto.TokenName = entity.TokenName;
            dto.TokenTypeId = entity.TokenTypeId;
            dto.ExpiryDate = entity.ExpiryDate;
            dto.RestrictionGroupId = entity.RestrictionGroupId;
            dto.TokenStatusId = entity.TokenStatusId;
            dto.TokenStatusReasonId = entity.TokenStatusReasonId;
            dto.IsActive = entity.IsActive == null ? false : Convert.ToBoolean(entity.IsActive);
            dto.CardCentreID = entity.CardCentreID;
            dto.AppointmentDate = entity.AppointmentDate;
            dto.PersonalizationReasonID = entity.ReasonID;
            dto.PersonalizationOrderStatusID = entity.PersonalizationOrderStatusID;
            dto.PersonalizationOrderTypeID = entity.PersonalizationOrderTypeID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTBatchToken> ToEntities(this IEnumerable<BatchTokenDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBatchToken, BatchTokenDTO>(dtos, ToEntity);
        }

        public static List<BatchTokenDTO> ToDTOs(this IEnumerable<CTBatchToken> entities)
        {
            return LinqExtension.ToDTO<CTBatchToken, BatchTokenDTO>(entities, ToDTO);
        }
    }
}
