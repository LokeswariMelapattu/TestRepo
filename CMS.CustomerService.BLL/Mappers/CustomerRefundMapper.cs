using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CustomerRefundMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTCustomerRefund entity, CustomerRefundDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static CustomerRefundDTO ToDTO(this CTCustomerRefund entity)
        {
            if (entity == null) return null;

            var dto = new CustomerRefundDTO();

            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.CustomerType = entity.CustomerType;
            dto.CustomerStatus = entity.CustomerStatus;
            dto.RefundAmount = entity.RefundAmount;
            dto.CustomerID = entity.CustomerID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerRefundDTO> ToDTOs(this IEnumerable<CTCustomerRefund> entities)
        {
            return LinqExtension.ToDTO<CTCustomerRefund, CustomerRefundDTO>(entities, ToDTO);
        }
    }
}
