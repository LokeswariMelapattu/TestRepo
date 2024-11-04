using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTProductServiceBilling"/> and <see cref="ProductServiceBillingTypeDTO"/>.
    /// </summary>
    public static partial class ProductServiceBillingTypeMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ProductServiceBillingTypeDTO"/> converted from <see cref="CTProductServiceBilling"/>.</param>
        static partial void OnDTO(this CTProductServiceBilling entity, ProductServiceBillingTypeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTProductServiceBilling"/> converted from <see cref="ProductServiceBillingTypeDTO"/>.</param>
        static partial void OnEntity(this ProductServiceBillingTypeDTO dto, CTProductServiceBilling entity);
 

        /// <summary>
        /// Converts this instance of <see cref="CTProductServiceBilling"/> to an instance of <see cref="ProductServiceBillingTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTProductServiceBilling"/> to convert.</param>
        public static ProductServiceBillingTypeDTO ToDTO(this CTProductServiceBilling entity)
        {
            if (entity == null) return null;

            var dto = new ProductServiceBillingTypeDTO()
            {
               BillingTypeId=entity.BILLING_TYPE_ID,
               BillingTypeNameEN=entity.EN_NAME,
               BillingTypeNameAR=entity.AR_NAME
            };
            entity.OnDTO(dto);
            return dto;
        }

      

        /// <summary>
        /// Converts each instance of <see cref="CTProductServiceBilling"/> to an instance of <see cref="ProductServiceBillingTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ProductServiceBillingTypeDTO> ToDTOs(this IEnumerable<CTProductServiceBilling> entities)
        {
            return LinqExtension.ToDTO<CTProductServiceBilling, ProductServiceBillingTypeDTO>(entities, ToDTO);
        }

    }
}
