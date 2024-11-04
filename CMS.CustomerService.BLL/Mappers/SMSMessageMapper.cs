using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="SMS_MESSAGE"/> and <see cref="SMSMessageDTO"/>.
    /// </summary>
    public static partial class SMSMessageMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SMSMessageDTO"/> converted from <see cref="SMS_MESSAGE"/>.</param>
        static partial void OnDTO(this SMS_MESSAGE entity, SMSMessageDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="SMS_MESSAGE"/> converted from <see cref="SMSMessageDTO"/>.</param>
        static partial void OnEntity(this SMSMessageDTO dto, SMS_MESSAGE entity);

        /// <summary>
        /// Converts this instance of <see cref="SMSMessageDTO"/> to an instance of <see cref="SMS_MESSAGE"/>.
        /// </summary>
        /// <param name="dto"><see cref="SMSMessageDTO"/> to convert.</param>
        public static SMS_MESSAGE ToEntity(this SMSMessageDTO dto)
        {
            if (dto == null) return null;

            var entity = new SMS_MESSAGE();

            entity.MESSAGE_ID = dto.MessageId == null ? -1 : (int)dto.MessageId;
            entity.MESSAGE_BODY = dto.MessageBody;
            entity.MOBILE_NUMBER = dto.MobileNumber;
            entity.IS_SENT = (short?)(dto.IsSent ? 1 : 0);
            entity.IS_ACTIVE = (short?)(dto.IsActive ? 1 : 0);
            entity.CUSTOMER_ID = dto.CustomerId;
            entity.BENEFICIARY_ID = dto.BeneficiaryId;
            entity.MESSAGE_DATE_TIME = dto.MessageDateTime;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="SMS_MESSAGE"/> to an instance of <see cref="SMSMessageDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="SMS_MESSAGE"/> to convert.</param>
        public static SMSMessageDTO ToDTO(this SMS_MESSAGE entity)
        {
            if (entity == null) return null;

            var dto = new SMSMessageDTO();

            dto.MessageId = entity.MESSAGE_ID;
            dto.MessageBody = entity.MESSAGE_BODY;
            dto.MobileNumber = entity.MOBILE_NUMBER;
            dto.IsSent = entity.IS_SENT.HasValue && entity.IS_SENT.Value == 1;
            dto.IsActive = !entity.IS_ACTIVE.HasValue || entity.IS_ACTIVE.Value == 1;
            dto.CustomerId = entity.CUSTOMER_ID;
            dto.BeneficiaryId = entity.BENEFICIARY_ID;
            dto.MessageDateTime = entity.MESSAGE_DATE_TIME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="SMSMessageDTO"/> to an instance of <see cref="SMS_MESSAGE"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<SMS_MESSAGE> ToEntities(this IEnumerable<SMSMessageDTO> dtos)
        {
            return LinqExtension.ToEntity<SMS_MESSAGE, SMSMessageDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="SMS_MESSAGE"/> to an instance of <see cref="SMSMessageDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SMSMessageDTO> ToDTOs(this IEnumerable<SMS_MESSAGE> entities)
        {
            return LinqExtension.ToDTO<SMS_MESSAGE, SMSMessageDTO>(entities, ToDTO);
        }

    }
}
