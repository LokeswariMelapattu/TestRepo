using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class NotificationMessageMapper
    {

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> converted from <see cref="AddressDTO"/>.</param>
        static partial void OnDTO(this NOTIFICATION_MESSAGE entity, NotificationMessageDto dto);


        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static NotificationMessageDto ToDTO(this NOTIFICATION_MESSAGE entity)
        {
            if (entity == null) return null;

            var dto = new NotificationMessageDto();

            dto.MessageCode = entity.MESSAGE_CODE;
            dto.MessageBody = entity.MESSAGE_BODY;
            dto.ArMessageBody = entity.AR_MESSAGE_BODY;
            dto.MessageSubject = entity.MESSAGE_SUBJECT;
            dto.ArMessageSubject = entity.AR_MESSAGE_SUBJECT;
            dto.MessageType = entity.MESSAGE_TYPE;

            entity.OnDTO(dto);

            return dto;
        }


        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<NotificationMessageDto> ToDTOs(this IEnumerable<NOTIFICATION_MESSAGE> entities)
        {
            if (entities == null) return null;
            var dtos = new List<NotificationMessageDto>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
