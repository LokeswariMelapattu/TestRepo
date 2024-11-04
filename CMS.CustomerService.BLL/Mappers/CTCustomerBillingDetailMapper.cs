using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerBillingDetail"/> and <see cref="CustomerBillingDTO"/>.
    /// </summary>
    public static partial class CTCustomerBillingDetailMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingDTO"/> converted from <see cref="CTCustomerBillingDetail"/>.</param>
        static partial void OnDTO(this CTCustomerBillingDetail entity, CustomerBillingDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingDetail"/> converted from <see cref="CustomerBillingDTO"/>.</param>
        static partial void OnEntity(this CustomerBillingDTO dto, CTCustomerBillingDetail entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerBillingDTO"/> to an instance of <see cref="CTCustomerBillingDetail"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerBillingDTO"/> to convert.</param>
        public static CTCustomerBillingDetail ToEntity(this CustomerBillingDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerBillingDetail();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.INVOICE_ID = dto.InvoiceID;
            entity.billing_date = dto.BillingDate;
            entity.DUE_DATE = dto.DueDate;
            entity.INVOICE_NUMBER = dto.InvoiceNumber;
            entity.DATE_FROM = dto.DateFrom;
            entity.DATE_TO = dto.DateTo;
            entity.billing_period_en = dto.BillingPeriod_EN;
            entity.billing_period_AR = dto.BillingPeriod_AR;
            entity.STATUS_ID = dto.StatusID;
            entity.STATUS_NAME = dto.StatusName;
            entity.STATUS_NAME_ar = dto.StatusNameAR;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerBillingDetail"/> to an instance of <see cref="CustomerBillingDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerBillingDetail"/> to convert.</param>
        public static CustomerBillingDTO ToDTO(this CTCustomerBillingDetail entity)
        {
            if (entity == null) return null;

            var dto = new CustomerBillingDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.InvoiceID = entity.INVOICE_ID;
            dto.BillingDate = entity.billing_date;
            dto.DueDate = entity.DUE_DATE;
            dto.InvoiceNumber = entity.INVOICE_NUMBER;
            dto.DateFrom = entity.DATE_FROM;
            dto.DateTo = entity.DATE_TO;
            dto.BillingPeriod_EN = entity.billing_period_en;
            dto.StatusID = entity.STATUS_ID;
            dto.StatusName = entity.STATUS_NAME;
            dto.StatusNameAR = entity.STATUS_NAME_ar;
            dto.BillingPeriod_AR = entity.billing_period_AR;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerBillingDTO" /> to an instance of <see cref="CTCustomerBillingDetail" />.
        /// </summary>
        /// <param name="dtos">The dtos.</param>
        /// <returns></returns>
        public static List<CTCustomerBillingDetail> ToEntities(this IEnumerable<CustomerBillingDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBillingDetail, CustomerBillingDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerBillingDetail" /> to an instance of <see cref="CustomerBillingDTO" />.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public static List<CustomerBillingDTO> ToDTOs(this IEnumerable<CTCustomerBillingDetail> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBillingDetail, CustomerBillingDTO>(entities, ToDTO);

        }

    }
}
