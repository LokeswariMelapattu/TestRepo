using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
  public static partial class FeeCustomerPaymentTransactionMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
        static partial void OnDTO(this CTCustomerPaymentTransaction entity, FeeCustomerPaymentTransactionDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static FeeCustomerPaymentTransactionDTO ToDTO(this CTCustomerPaymentTransaction entity)
        {
            if (entity == null) return null;

            var dto = new FeeCustomerPaymentTransactionDTO();
            dto.Amount = entity.Amount;
            dto.CustomerID = entity.CustomerID;
            dto.PaymentDocRefNo = entity.PaymentDocRefNo;
            dto.PaymentMethod = entity.PaymentMethod;
            dto.PaymentType = entity.PaymentType;
            dto.Remarks = entity.Remarks;
            dto.TransactionDate = entity.TransactionDate;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<FeeCustomerPaymentTransactionDTO> ToDTOs(this IEnumerable<CTCustomerPaymentTransaction> entities)
        {
            if (entities == null) return null;
            var dtos = new List<FeeCustomerPaymentTransactionDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
