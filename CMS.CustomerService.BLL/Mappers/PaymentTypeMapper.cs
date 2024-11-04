using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class PaymentTypeMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PaymentTypeDTO"/> converted from <see cref="PAYMENT_TYPE"/>.</param>
        static partial void OnDTO(this PAYMENT_TYPE entity, PaymentTypeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PAYMENT_TYPE"/> converted from <see cref="PaymentTypeDTO"/>.</param>
        static partial void OnEntity(this PaymentTypeDTO dto, PAYMENT_TYPE entity);

        /// <summary>
        /// Converts this instance of <see cref="PaymentTypeDTO"/> to an instance of <see cref="PAYMENT_TYPE"/>.
        /// </summary>
        /// <param name="dto"><see cref="PaymentTypeDTO"/> to convert.</param>
        public static PAYMENT_TYPE ToEntity(this PaymentTypeDTO dto)
        {
            if (dto == null) return null;

            var entity = new PAYMENT_TYPE();

            entity.PAYMENT_TYPE_ID = dto.PaymentTypeID;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(!dto.IsActive ? 1 : 0);
            entity.EN_NAME = dto.EnName;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="PAYMENT_TYPE"/> to an instance of <see cref="PaymentTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="PAYMENT_TYPE"/> to convert.</param>
        public static PaymentTypeDTO ToDTO(this PAYMENT_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new PaymentTypeDTO();

            dto.PaymentTypeID = entity.PAYMENT_TYPE_ID;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.EnName = entity.EN_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="PaymentTypeDTO"/> to an instance of <see cref="PAYMENT_TYPE"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PAYMENT_TYPE> ToEntities(this IEnumerable<PaymentTypeDTO> dtos)
        {
            return LinqExtension.ToEntity<PAYMENT_TYPE, PaymentTypeDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="PAYMENT_TYPE"/> to an instance of <see cref="PaymentTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PaymentTypeDTO> ToDTOs(this IEnumerable<PAYMENT_TYPE> entities)
        {
            return LinqExtension.ToDTO<PAYMENT_TYPE, PaymentTypeDTO>(entities, ToDTO);
        }
    }
}
