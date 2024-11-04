using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class CustomerQuotaMappers
    {
       static partial void OnDTO(this CTCustomerQuota entity, CustomerQuotaDTO dto);

       public static CustomerQuotaDTO ToDTO(this CTCustomerQuota entity)
       {
           if (entity == null) return null;

           var dto = new CustomerQuotaDTO { 
           CustomerId = entity.CUSTOMER_ID,
           ProductId = entity.PRODUCT_ID,
           ProductNameAr = entity.ProductNameAr,
           ProductNameEn = entity.ProductNameEn,
           Quota = entity.Quota,
           QuotaId = entity.QuotaId
           };

           entity.OnDTO(dto);

           return dto;
       }

       public static List<CustomerQuotaDTO> ToDTOs(this IEnumerable<CTCustomerQuota> entities)
       {
           return LinqExtension.ToDTO<CTCustomerQuota, CustomerQuotaDTO>(entities, ToDTO);
       }
    }
}
