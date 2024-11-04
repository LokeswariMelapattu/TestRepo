using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_STATUS_REASON"/> and <see cref="StatusReasonDTO"/>.
    /// </summary>
    public static partial class CustomerStatusReasonMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="StatusReasonDTO"/> converted from <see cref="CUSTOMER_STATUS_REASON"/>.</param>
        static partial void OnDTO(this CUSTOMER_STATUS_REASON entity, StatusReasonDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_STATUS_REASON"/> converted from <see cref="StatusReasonDTO"/>.</param>
        static partial void OnEntity(this StatusReasonDTO dto, CUSTOMER_STATUS_REASON entity);

        /// <summary>
        /// Converts this instance of <see cref="StatusReasonDTO"/> to an instance of <see cref="CUSTOMER_STATUS_REASON"/>.
        /// </summary>
        /// <param name="dto"><see cref="StatusReasonDTO"/> to convert.</param>
        public static CUSTOMER_STATUS_REASON ToStatusReasonEntity(this StatusReasonDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_STATUS_REASON();

            entity.CUSTOMER_STATUS_REASON_ID = dto.CUSTOMER_STATUS_REASON_ID;
            entity.CUSTOMER_STATUS_ID = dto.CUSTOMER_STATUS_ID;
            entity.EN_NAME = dto.EN_NAME;
            entity.DESCRIPTION = dto.DESCRIPTION;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.AR_NAME = dto.AR_NAME;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_STATUS_REASON"/> to an instance of <see cref="StatusReasonDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_STATUS_REASON"/> to convert.</param>
        public static StatusReasonDTO ToStatusReasonDTO(this CUSTOMER_STATUS_REASON entity)
        {
            if (entity == null) return null;

            var dto = new StatusReasonDTO();

            dto.CUSTOMER_STATUS_REASON_ID = entity.CUSTOMER_STATUS_REASON_ID;
            dto.CUSTOMER_STATUS_ID = entity.CUSTOMER_STATUS_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.DESCRIPTION = entity.DESCRIPTION;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.AR_NAME = entity.AR_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="StatusReasonDTO"/> to an instance of <see cref="CUSTOMER_STATUS_REASON"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_STATUS_REASON> ToEntities(this IEnumerable<StatusReasonDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_STATUS_REASON, StatusReasonDTO>(dtos, ToStatusReasonEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_STATUS_REASON"/> to an instance of <see cref="StatusReasonDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<StatusReasonDTO> ToDTOs(this IEnumerable<CUSTOMER_STATUS_REASON> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_STATUS_REASON, StatusReasonDTO>(entities, ToStatusReasonDTO);
        }

    }
}
