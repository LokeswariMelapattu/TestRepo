using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="PAYMENT_METHOD"/> and <see cref="PaymentMethodDTO"/>.
    /// </summary>
    public static partial class PaymentMethodMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PaymentMethodDTO"/> converted from <see cref="PAYMENT_METHOD"/>.</param>
        static partial void OnDTO(this PAYMENT_METHOD entity, PaymentMethodDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PAYMENT_METHOD"/> converted from <see cref="PaymentMethodDTO"/>.</param>
        static partial void OnEntity(this PaymentMethodDTO dto, PAYMENT_METHOD entity);

        /// <summary>
        /// Converts this instance of <see cref="PaymentMethodDTO"/> to an instance of <see cref="PAYMENT_METHOD"/>.
        /// </summary>
        /// <param name="dto"><see cref="PaymentMethodDTO"/> to convert.</param>
        public static PAYMENT_METHOD ToEntity(this PaymentMethodDTO dto)
        {
            if (dto == null) return null;

            var entity = new PAYMENT_METHOD();

            entity.PAYMENT_METHOD_ID = dto.PaymentMethodId == null ? -1 : (int)dto.PaymentMethodId;
            entity.EN_PAYMENT_METHOD = dto.PaymentMethodName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.AR_PAYMENT_METHOD = dto.ARPaymentMethodName;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="PAYMENT_METHOD"/> to an instance of <see cref="PaymentMethodDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="PAYMENT_METHOD"/> to convert.</param>
        public static PaymentMethodDTO ToDTO(this PAYMENT_METHOD entity)
        {
            if (entity == null) return null;

            var dto = new PaymentMethodDTO();

            dto.PaymentMethodId = entity.PAYMENT_METHOD_ID;
            dto.PaymentMethodName = entity.EN_PAYMENT_METHOD;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ARPaymentMethodName = entity.AR_PAYMENT_METHOD;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="PaymentMethodDTO"/> to an instance of <see cref="PAYMENT_METHOD"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PAYMENT_METHOD> ToEntities(this IEnumerable<PaymentMethodDTO> dtos)
        {
            return LinqExtension.ToEntity<PAYMENT_METHOD, PaymentMethodDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="PAYMENT_METHOD"/> to an instance of <see cref="PaymentMethodDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PaymentMethodDTO> ToDTOs(this IEnumerable<PAYMENT_METHOD> entities)
        {
            return LinqExtension.ToDTO<PAYMENT_METHOD, PaymentMethodDTO>(entities, ToDTO);

        }

    }
}
