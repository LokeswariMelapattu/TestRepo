/*
//------------------------------------------------------------------------------
// Author - Diyar United Company
// Dated  - 21 July 2014
// Project- CMS Customer Service
//------------------------------------------------------------------------------
*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014-07-22 - 07:52:20
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="NOTIFICATION_CHANNEL"/> and <see cref="NotificationChannelDTO"/>.
    /// </summary>
    public static partial class NotificationChannelMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="NotificationChannelDTO"/> converted from <see cref="NOTIFICATION_CHANNEL"/>.</param>
        static partial void OnDTO(this NOTIFICATION_CHANNEL entity, NotificationChannelDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="NOTIFICATION_CHANNEL"/> converted from <see cref="NotificationChannelDTO"/>.</param>
        static partial void OnEntity(this NotificationChannelDTO dto, NOTIFICATION_CHANNEL entity);

        /// <summary>
        /// Converts this instance of <see cref="NotificationChannelDTO"/> to an instance of <see cref="NOTIFICATION_CHANNEL"/>.
        /// </summary>
        /// <param name="dto"><see cref="NotificationChannelDTO"/> to convert.</param>
        public static NOTIFICATION_CHANNEL ToEntity(this NotificationChannelDTO dto)
        {
            if (dto == null) return null;

            var entity = new NOTIFICATION_CHANNEL();

            entity.NOTIFICATION_CHANNEL_ID = dto.NOTIFICATION_CHANNEL_ID;
            entity.EN_NAME = dto.EN_NAME;
            entity.IS_ACTIVE = dto.IS_ACTIVE;
            entity.AR_NAME = dto.AR_NAME;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="NOTIFICATION_CHANNEL"/> to an instance of <see cref="NotificationChannelDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="NOTIFICATION_CHANNEL"/> to convert.</param>
        public static NotificationChannelDTO ToDTO(this NOTIFICATION_CHANNEL entity)
        {
            if (entity == null) return null;

            var dto = new NotificationChannelDTO();

            dto.NOTIFICATION_CHANNEL_ID = entity.NOTIFICATION_CHANNEL_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.AR_NAME = entity.AR_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="NotificationChannelDTO"/> to an instance of <see cref="NOTIFICATION_CHANNEL"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<NOTIFICATION_CHANNEL> ToEntities(this IEnumerable<NotificationChannelDTO> dtos)
        {
            return LinqExtension.ToEntity<NOTIFICATION_CHANNEL, NotificationChannelDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="NOTIFICATION_CHANNEL"/> to an instance of <see cref="NotificationChannelDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<NotificationChannelDTO> ToDTOs(this IEnumerable<NOTIFICATION_CHANNEL> entities)
        {
            return LinqExtension.ToDTO<NOTIFICATION_CHANNEL, NotificationChannelDTO>(entities, ToDTO);
        }

    }
}
