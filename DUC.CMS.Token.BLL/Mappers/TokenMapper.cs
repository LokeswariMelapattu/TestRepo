using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class TokenMapper
    {
      
        static partial void OnDTO(this TOKEN entity, TokenDTO  dto);

        static partial void OnEntity(this TokenDTO  dto, TOKEN entity);

        public static TOKEN ToEntity(this TokenDTO  dto)
        {
            if (dto == null) return null;

            var entity = new TOKEN();

            entity.TOKEN_ID = dto.TokenID == null ? -2 : (int)dto.TokenID;
            entity.TOKEN_TYPE_ID = dto.TokenTypeID;
            entity.CODE = dto.Code;
            entity.EXPIRY_DATE = dto.ExpiryDate;
            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.NUMBER_OF_ACTIVE_TAGS = dto.NoOfActiveTags;
            entity.TOKEN_STATUS_ID = dto.TokenStatusID;
            entity.TOKEN_STATUS_REASON_ID = dto.TokenStatusReasonID;
            entity.IS_STATUS_INHERITED = Convert.ToInt16(dto.IsStatusInherited);
            entity.WORK_ORDER_ID = dto.WorkOrderID;
            entity.PERSONALIZATION_ORDER_ID = dto.PersonalizationOrderID;
            entity.SERIAL = dto.Serial;
            entity.SECOND_SERIAL = dto.SecondSerial;
            entity.THIRD_SERIAL = dto.ThirdSerial;
            entity.TOKEN_CHIP_NUMBER = dto.TokenChipNo;
            entity.SECOND_TOKEN_CHIP_NUMBER = dto.SecondTokenChipNo;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.NAME = dto.Name;
            entity.VEHICLE_INFO_ID = dto.VehicleInfoID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.CUSTOM_EXPIRY_YEARS = dto.CustomExpiryYears;
            entity.IS_TRX_NOTIFY = (short)(dto.IsTransactionNotification ? 1 : 0);
            entity.IS_FEE_WAIVED_OFF = (short)(dto.IsFeeWaivedOff ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }
     
        public static TokenDTO  ToDTO(this TOKEN entity)
        {
            if (entity == null) return null;

            var dto = new TokenDTO ();

            dto.TokenID = entity.TOKEN_ID;
            dto.TokenTypeID = entity.TOKEN_TYPE_ID;
            dto.Code = entity.CODE;
            dto.ExpiryDate = entity.EXPIRY_DATE;
            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.NoOfActiveTags = entity.NUMBER_OF_ACTIVE_TAGS;
            dto.TokenStatusID = entity.TOKEN_STATUS_ID;
            dto.TokenStatusReasonID = entity.TOKEN_STATUS_REASON_ID;
            dto.IsStatusInherited = entity.IS_STATUS_INHERITED == null ? false : Convert.ToBoolean(entity.IS_STATUS_INHERITED);
            dto.WorkOrderID = entity.WORK_ORDER_ID;
            dto.PersonalizationOrderID = entity.PERSONALIZATION_ORDER_ID;
            dto.Serial = entity.SERIAL;
            dto.SecondSerial = entity.SECOND_SERIAL;
            dto.ThirdSerial = entity.THIRD_SERIAL;
            dto.TokenChipNo = entity.TOKEN_CHIP_NUMBER;
            dto.SecondTokenChipNo = entity.SECOND_TOKEN_CHIP_NUMBER;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.Name = entity.NAME;
            dto.VehicleInfoID = entity.VEHICLE_INFO_ID;
            dto.RegistrationDate = entity.REGISTERATION_DATE;
            dto._VehicleInfoDTO = entity.VEHICLE_INFO_ID == null ? null : new Lazy<VehicleInfoDTO>(() => new TokenAppService().GetVehicleInfoByID((int)entity.VEHICLE_INFO_ID));
            dto.CustomExpiryYears = entity.CUSTOM_EXPIRY_YEARS;
            dto.IsTransactionNotification = (entity.IS_TRX_NOTIFY != null && entity.IS_TRX_NOTIFY == 1);
            dto.IsFeeWaivedOff = (entity.IS_FEE_WAIVED_OFF != null && entity.IS_FEE_WAIVED_OFF == 1);
            //new TokenAppService().GetVehicleInfoByID((int)entity.VEHICLE_INFO_ID);
            //new Lazy<VehicleInfoDTO>(() => new TokenAppService().GetVehicleInfoByID((int)entity.VEHICLE_INFO_ID));
            //dto.VehicleInfoDTO.VehicleRegisterDTO = entity.VEHICLE_INFO_ID == null ? null : new TokenAppService().GetVehicleRegisterByID((int)entity.VEHICLE_INFO.VEHICLE_REGISTER_ID);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<TOKEN> ToEntities(this IEnumerable<TokenDTO > dtos)
        {
            return LinqExtension.ToEntity<TOKEN, TokenDTO >(dtos, ToEntity);
        }

        public static List<TokenDTO > ToDTOs(this IEnumerable<TOKEN> entities)
        {
            return LinqExtension.ToDTO<TOKEN, TokenDTO >(entities, ToDTO);
        }

    }
}




