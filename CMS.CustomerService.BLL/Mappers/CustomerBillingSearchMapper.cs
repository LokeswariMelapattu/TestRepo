using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    
    public static partial class CustomerBillingSearchMapper
    {
       
        static partial void OnDTO(this CTCustomerBillingSearch entity, CustomerBillingSearchDTO dto);
      
        static partial void OnEntity(this CustomerBillingSearchDTO dto, CTCustomerBillingSearch entity);
        
        public static CTCustomerBillingSearch ToEntity(this CustomerBillingSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerBillingSearch();

            if (dto.BillingPeriod != null)
            {
                entity.DATE_FROM = Convert.ToDateTime(dto.BillingPeriod.Substring(5, 9));
                entity.DATE_TO = Convert.ToDateTime(dto.BillingPeriod.Substring(18, 9));
            }
            else
            {
                entity.DATE_FROM = dto.DateFrom;
                entity.DATE_TO = dto.DateTo;
            }
          
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.INVOICE_NUMBER = dto.InvoiceNumber;
            entity.BILLING_DATE = dto.BillingDate;

            dto.OnEntity(entity);

            return entity;
        }
        
        public static CustomerBillingSearchDTO ToDTO(this CTCustomerBillingSearch entity)
        {
            if (entity == null) return null;

            var dto = new CustomerBillingSearchDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.InvoiceNumber = entity.INVOICE_NUMBER;
            dto.BillingDate = entity.BILLING_DATE;
            dto.DateFrom = entity.DATE_FROM;
            dto.DateTo = entity.DATE_TO;
            dto.BillingID = entity.INVOICE_ID;
            dto.BillingPeriod = entity.BILLING_PERIOD;
            dto.TransactionAmount = entity.TOTAL_TRANSACTION_AMOUNT;
            dto.Adjustment = entity.TOTAL_ADJUSTMENT;
            dto.TotalAmount = entity.TOTAL_AMOUNT;
            dto.Status = entity.STATUS_NAME;
            dto.StatusAR = entity.STATUS_NAME_ar;
            dto.PaidAmount = entity.PaidAmount;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTCustomerBillingSearch> ToEntities(this IEnumerable<CustomerBillingSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerBillingSearch, CustomerBillingSearchDTO>(dtos, ToEntity);
        }
      
        public static List<CustomerBillingSearchDTO> ToDTOs(this IEnumerable<CTCustomerBillingSearch> entities)
        {
            return LinqExtension.ToDTO<CTCustomerBillingSearch, CustomerBillingSearchDTO>(entities, ToDTO);
        }
    }
}
