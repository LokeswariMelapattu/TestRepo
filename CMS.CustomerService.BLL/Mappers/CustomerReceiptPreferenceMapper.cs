using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    public static partial class CustomerReceiptPreferenceMapper
    {
        static partial void OnDTO(this CTCustomerReceiptPreference entity, CustomerReceiptPreferenceDTO dto);

        static partial void OnEntity(this CustomerReceiptPreferenceDTO dto, CTCustomerReceiptPreference entity);

        public static CTCustomerReceiptPreference ToEntity(this CustomerReceiptPreferenceDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerReceiptPreference();

            entity.CUSTOMER_ID = dto.CustomerId;
            entity.RECEIPT_TYPE_ID = dto.ReceiptTypeId;
         
            dto.OnEntity(entity);

            return entity;
        }

        public static CustomerReceiptPreferenceDTO ToDTO(this CTCustomerReceiptPreference entity)
        {
            if (entity == null) return null;

            var dto = new CustomerReceiptPreferenceDTO();

            dto.CustomerId = entity.CUSTOMER_ID;
            dto.ReceiptTypeId = entity.RECEIPT_TYPE_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTCustomerReceiptPreference> ToEntities(this IEnumerable<CustomerReceiptPreferenceDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTCustomerReceiptPreference>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        public static List<CustomerReceiptPreferenceDTO> ToDTOs(this IEnumerable<CTCustomerReceiptPreference> entities)
        {
            if (entities == null) return null;
            var dtos = new List<CustomerReceiptPreferenceDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
