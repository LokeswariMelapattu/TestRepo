using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerBillingPeriod"/> and <see cref="CustomerBillingPeriodDTO"/>.
    /// </summary>
    public static partial class CTCustomerBillingPeriodMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingPeriodDTO"/> converted from <see cref="CTCustomerBillingPeriod"/>.</param>
        static partial void OnDTO(this CTCustomerBillingPeriod entity, CustomerBillingPeriodDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingPeriod"/> converted from <see cref="CustomerBillingPeriodDTO"/>.</param>
        static partial void OnEntity(this CustomerBillingPeriodDTO dto, CTCustomerBillingPeriod entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerBillingPeriodDTO"/> to an instance of <see cref="CTCustomerBillingPeriod"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingPeriodDTO"/> to convert.</param>
        public static CTCustomerBillingPeriod ToEntity(this CustomerBillingPeriodDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerBillingPeriod();

            entity.DATE_FROM = dto.DateFrom;
            entity.DATE_TO = dto.DateTo;
            entity.PERIOD_EN = dto.PeriodEn;
            entity.PERIOD_AR = dto.PeriodAr;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerBillingPeriod"/> to an instance of <see cref="CustomerBillingPeriodDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingPeriod"/> to convert.</param>
        public static CustomerBillingPeriodDTO ToDTO(this CTCustomerBillingPeriod entity)
        {
            if (entity == null) return null;

            var dto = new CustomerBillingPeriodDTO();

            dto.DateFrom = entity.DATE_FROM;
            dto.DateTo = entity.DATE_TO;
            dto.PeriodEn = entity.PERIOD_EN;
            dto.PeriodAr = entity.PERIOD_AR;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerBillingPeriodDTO"/> to an instance of <see cref="CTCustomerBillingPeriod"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerBillingPeriod> ToEntities(this IEnumerable<CustomerBillingPeriodDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBillingPeriod, CustomerBillingPeriodDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerBillingPeriod"/> to an instance of <see cref="CustomerBillingPeriodDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerBillingPeriodDTO> ToDTOs(this IEnumerable<CTCustomerBillingPeriod> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBillingPeriod, CustomerBillingPeriodDTO>(entities, ToDTO);
        }

    }
}
