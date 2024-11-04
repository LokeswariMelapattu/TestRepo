using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTEmployeeIdentityCard"/> and <see cref="EmployeeIdentityCardDTO"/>.
    /// </summary>
    public static partial class EmployeeIdentityCardMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="EmployeeIdentityCardDTO"/> converted from <see cref="CTEmployeeIdentityCard"/>.</param>
        static partial void OnDTO(this CTEmployeeIdentityCard entity, EmployeeIdentityCardDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTEmployeeIdentityCard"/> converted from <see cref="EmployeeIdentityCardDTO"/>.</param>
        static partial void OnEntity(this EmployeeIdentityCardDTO dto, CTEmployeeIdentityCard entity);

        /// <summary>
        /// Converts this instance of <see cref="EmployeeIdentityCardDTO"/> to an instance of <see cref="CTEmployeeIdentityCard"/>.
        /// </summary>
        /// <param name="dto"><see cref="EmployeeIdentityCardDTO"/> to convert.</param>
        public static CTEmployeeIdentityCard ToEntity(this EmployeeIdentityCardDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTEmployeeIdentityCard();

            entity.P_TOKEN_ID = dto.TokenId;
            entity.P_CUSTOMER_ID = dto.CustomerId;
            entity.P_PERSONALIZATION_NUMBER = dto.PersonalizationNumber;
            entity.P_PERSONALIZATION_STATUS_ID = dto.PersonalizationStatusId;
            entity.P_CARD_CENTER_ID = dto.CardCenterId;
            entity.P_APPOINTMENT_DATE = dto.AppointmentDate;
            entity.P_PRSNLIZTION_ORDR_TYP_ID = dto.PersonalizationOrderTypeId;
            entity.P_PERSONALIZATION_REASON_ID = dto.PersonalizationReasonId;
            entity.P_EMPLOYEE_ID = dto.EmployeeId;
            entity.P_IDENTIFICATION_TYPE_ID = dto.IdentificationTypeID;
            entity.P_IDENTITY_NUMBER = dto.IdentityNumber;
            entity.P_Last_updated_DATE = dto.LastUpdatedDate;
            entity.P_Location_ID = dto.LastUpdatedLocationID;
            entity.P_User_ID = dto.LastUpdatedUserId;
            
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTEmployeeIdentityCard"/> to an instance of <see cref="EmployeeIdentityCardDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTEmployeeIdentityCard"/> to convert.</param>
        public static EmployeeIdentityCardDTO ToDTO(this CTEmployeeIdentityCard entity)
        {
            if (entity == null) return null;

            var dto = new EmployeeIdentityCardDTO();

            dto.TokenId = entity.P_TOKEN_ID;
            dto.PersonalizationNumber = entity.P_PERSONALIZATION_NUMBER;
            dto.PersonalizationStatusId = entity.P_PERSONALIZATION_STATUS_ID;
            dto.CardCenterId = entity.P_CARD_CENTER_ID;
            dto.AppointmentDate = entity.P_APPOINTMENT_DATE;
            dto.PersonalizationOrderTypeId = entity.P_PRSNLIZTION_ORDR_TYP_ID;
            dto.PersonalizationReasonId = entity.P_PERSONALIZATION_REASON_ID;
            dto.EmployeeId = entity.P_EMPLOYEE_ID;
            dto.IdentificationTypeID = entity.P_IDENTIFICATION_TYPE_ID;
            dto.IdentityNumber = entity.P_IDENTITY_NUMBER;
            dto.LastUpdatedUserId = entity.P_User_ID;
            dto.LastUpdatedLocationID = (int)entity.P_Location_ID;
            dto.LastUpdatedDate = entity.P_Last_updated_DATE;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="EmployeeIdentityCardDTO"/> to an instance of <see cref="CTEmployeeIdentityCard"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTEmployeeIdentityCard> ToEntities(this IEnumerable<EmployeeIdentityCardDTO> dtos)
        {
            return LinqExtension.ToEntity<CTEmployeeIdentityCard, EmployeeIdentityCardDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTEmployeeIdentityCard"/> to an instance of <see cref="EmployeeIdentityCardDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<EmployeeIdentityCardDTO> ToDTOs(this IEnumerable<CTEmployeeIdentityCard> entities)
        {
            return LinqExtension.ToDTO<CTEmployeeIdentityCard, EmployeeIdentityCardDTO>(entities, ToDTO);
        }

    }
}
