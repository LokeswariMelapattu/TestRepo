using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestPersonalizationMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTRequestPersonalization entity, RequestPersonalizationDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestPersonalizationDTO ToDTO(this CTRequestPersonalization entity)
        {
            if (entity == null) return null;

            var dto = new RequestPersonalizationDTO();
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.AuthPersonIDNumber = entity.AuthPersonIDNumber;
            dto.AuthPersonIDType = entity.AuthPersonIDType;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.TokenTypeName = entity.TokenType;
            dto.PreferredDateFrom = entity.PreferredDateFrom;
            dto.PreferredDateTo = entity.PreferredDateTo;
            dto.RequestId = entity.RequestId;
            dto.TokenCode = entity.TokenCode;
            dto.TokenName = entity.TokenName;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.PreferredLocationId = entity.PreferredLocationId;
            dto.Request = entity.RequestId == null ? null : new CustomerAppService().GetRequestById((int)entity.RequestId);
            dto.PreferredDateTo = entity.PreferredDateTo;
            dto.RequestPersonalizationOrderID = entity.RequestPersonalizationOrderID;
            dto.TokenSerial = entity.TokenSerial;
            dto.ExpiryDate = entity.ExpiryDate;
            dto.ScheduledDate = entity.ScheduledDate;
            dto.ScheduledLocationID = entity.ScheduledLocationID;
            dto.TokenStatusID = entity.TokenStatusID;
            dto.ReasonID = entity.ReasonID;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestPersonalizationDTO> ToDTOs(this IEnumerable<CTRequestPersonalization> entities)
        {
            return LinqExtension.ToDTO<CTRequestPersonalization, RequestPersonalizationDTO>(entities, ToDTO);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this RequestPersonalizationDTO dto, CTRequestPersonalization entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CTRequestPersonalization ToEntity(this RequestPersonalizationDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestPersonalization();
            entity.AuthPersonIDNumber = dto.AuthPersonIDNumber;
            entity.AuthPersonIDType = dto.AuthPersonIDType;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.ExpiryDate = dto.ExpiryDate;
            entity.IsActive = dto.IsActive ? 0 : 1;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.PreferredDateFrom = dto.PreferredDateFrom;
            entity.PreferredDateTo = dto.PreferredDateTo;
            entity.PreferredLocationId = dto.PreferredLocationId;
            entity.RequestId = dto.RequestId;
            entity.RequestPersonalizationOrderID = dto.RequestPersonalizationOrderID == null ? -1 : (int)dto.RequestPersonalizationOrderID; 
            entity.ScheduledDate = dto.ScheduledDate;
            entity.ScheduledLocationID = dto.ScheduledLocationID;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.TokenType = dto.TokenTypeName;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.ReasonID = dto.ReasonID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastLocationID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestPersonalization> ToEntities(this IEnumerable<RequestPersonalizationDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRequestPersonalization, RequestPersonalizationDTO>(dtos, ToEntity);
        }
    }
}
