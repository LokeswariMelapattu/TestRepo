using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerBillingDate"/> and <see cref="CustomerBillingDateDTO"/>.
    /// </summary>
    public static partial class CTCustomerBillingDateMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingDateDTO"/> converted from <see cref="CTCustomerBillingDate"/>.</param>
        static partial void OnDTO(this CTCustomerBillingDate entity, CustomerBillingDateDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingDate"/> converted from <see cref="CustomerBillingDateDTO"/>.</param>
        static partial void OnEntity(this CustomerBillingDateDTO dto, CTCustomerBillingDate entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerBillingDateDTO"/> to an instance of <see cref="CTCustomerBillingDate"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingDateDTO"/> to convert.</param>
        public static CTCustomerBillingDate ToEntity(this CustomerBillingDateDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerBillingDate();

            entity.billing_date = dto.BillingDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerBillingDate"/> to an instance of <see cref="CustomerBillingDateDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingDate"/> to convert.</param>
        public static CustomerBillingDateDTO ToDTO(this CTCustomerBillingDate entity)
        {
            if (entity == null) return null;

            var dto = new CustomerBillingDateDTO();

            dto.BillingDate = entity.billing_date;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerBillingDateDTO"/> to an instance of <see cref="CTCustomerBillingDate"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerBillingDate> ToEntities(this IEnumerable<CustomerBillingDateDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBillingDate, CustomerBillingDateDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerBillingDate"/> to an instance of <see cref="CustomerBillingDateDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerBillingDateDTO> ToDTOs(this IEnumerable<CTCustomerBillingDate> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBillingDate, CustomerBillingDateDTO>(entities, ToDTO);

        }

    }
}
