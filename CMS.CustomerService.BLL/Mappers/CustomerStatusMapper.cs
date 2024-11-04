using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_STATUS"/> and <see cref="CustomerStatusDTO"/>.
    /// </summary>
    public static partial class CustomerStatusMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerStatusDTO"/> converted from <see cref="CUSTOMER_STATUS"/>.</param>
        static partial void OnDTO(this CUSTOMER_STATUS entity, CustomerStatusDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_STATUS"/> converted from <see cref="CustomerStatusDTO"/>.</param>
        static partial void OnEntity(this CustomerStatusDTO dto, CUSTOMER_STATUS entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerStatusDTO"/> to an instance of <see cref="CUSTOMER_STATUS"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerStatusDTO"/> to convert.</param>
        public static CUSTOMER_STATUS ToEntity(this CustomerStatusDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_STATUS();

            entity.CUSTOMER_STATUS_ID = dto.CustomerStatusId;
            entity.EN_CUSTOMER_STATUS = dto.CustomerStatus;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.AR_CUSTOMER_STATUS = dto.ARCustomerStatus;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_STATUS"/> to an instance of <see cref="CustomerStatusDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_STATUS"/> to convert.</param>
        public static CustomerStatusDTO ToDTO(this CUSTOMER_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new CustomerStatusDTO();

            dto.CustomerStatusId = entity.CUSTOMER_STATUS_ID;
            dto.CustomerStatus = entity.EN_CUSTOMER_STATUS;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ARCustomerStatus = entity.AR_CUSTOMER_STATUS;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerStatusDTO"/> to an instance of <see cref="CUSTOMER_STATUS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_STATUS> ToEntities(this IEnumerable<CustomerStatusDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_STATUS, CustomerStatusDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_STATUS"/> to an instance of <see cref="CustomerStatusDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerStatusDTO> ToDTOs(this IEnumerable<CUSTOMER_STATUS> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_STATUS, CustomerStatusDTO>(entities, ToDTO);
        }

    }
}
