using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerStatusHistory"/> and <see cref="CustomerStatusHistoryDTO"/>.
    /// </summary>
    public static partial class CTCustomerStatusHistoryMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerStatusHistoryDTO"/> converted from <see cref="CTCustomerStatusHistory"/>.</param>
        static partial void OnDTO(this CTCustomerStatusHistory entity, CustomerStatusHistoryDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerStatusHistory"/> converted from <see cref="CustomerStatusHistoryDTO"/>.</param>
        static partial void OnEntity(this CustomerStatusHistoryDTO dto, CTCustomerStatusHistory entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerStatusHistoryDTO"/> to an instance of <see cref="CTCustomerStatusHistory"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerStatusHistoryDTO"/> to convert.</param>
        public static CTCustomerStatusHistory ToEntity(this CustomerStatusHistoryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerStatusHistory();

            entity.Customer_ID = dto.CustomerID;
            entity.CUSTOMER_STATUS_ID = dto.StatusID;
            entity.EN_CUSTOMER_STATUS = dto.StatusEnName;
            entity.AR_CUSTOMER_STATUS = dto.StatusArName;
            entity.CUSTOMER_STATUS_REASON_ID = dto.StatusReasonID;
            entity.Customer_STATUS_REASON_ENNAME = dto.StatusReasonEnName;
            entity.Customer_STATUS_REASON_ARNAME = dto.StatusReasonArName;
            entity.STATUS_CHANGE_DATE_TIME = dto.StatusChangeDate;
            entity.CODE = dto.CustomerCode;
            entity.USER_NAME = dto.UserName;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerStatusHistory"/> to an instance of <see cref="CustomerStatusHistoryDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerStatusHistory"/> to convert.</param>
        public static CustomerStatusHistoryDTO ToDTO(this CTCustomerStatusHistory entity)
        {
            if (entity == null) return null;

            var dto = new CustomerStatusHistoryDTO();

            dto.CustomerID = entity.Customer_ID;
            dto.StatusID = entity.CUSTOMER_STATUS_ID.HasValue ? entity.CUSTOMER_STATUS_ID.Value : 0;
            dto.StatusEnName = entity.EN_CUSTOMER_STATUS;
            dto.StatusArName = entity.AR_CUSTOMER_STATUS;
            dto.StatusReasonID = entity.CUSTOMER_STATUS_REASON_ID.HasValue ? entity.CUSTOMER_STATUS_REASON_ID.Value : 0;
            dto.StatusReasonEnName = entity.Customer_STATUS_REASON_ENNAME;
            dto.StatusReasonArName = entity.Customer_STATUS_REASON_ARNAME;
            dto.StatusChangeDate = entity.STATUS_CHANGE_DATE_TIME;
            dto.CustomerCode = entity.CODE;
            dto.UserName = entity.USER_NAME;

            
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerStatusHistoryDTO"/> to an instance of <see cref="CTCustomerStatusHistory"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerStatusHistory> ToEntities(this IEnumerable<CustomerStatusHistoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerStatusHistory, CustomerStatusHistoryDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerStatusHistory"/> to an instance of <see cref="CustomerStatusHistoryDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerStatusHistoryDTO> ToDTOs(this IEnumerable<CTCustomerStatusHistory> entities)
        {
            return LinqExtension.ToDTO<CTCustomerStatusHistory, CustomerStatusHistoryDTO>(entities, ToDTO);

        }

    }
}
