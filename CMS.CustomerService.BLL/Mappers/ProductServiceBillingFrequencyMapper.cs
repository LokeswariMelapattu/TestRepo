using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTProductServiceBillingFreq"/> and <see cref="ProductServiceBillingFrequencyDTO"/>.
    /// </summary>
    public static partial class ProductServiceBillingFrequencyMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ProductServiceBillingFrequencyDTO"/> converted from <see cref="CTProductServiceBillingFreq"/>.</param>
        static partial void OnDTO(this CTProductServiceBillingFreq entity, ProductServiceBillingFrequencyDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTProductServiceBillingFreq"/> converted from <see cref="ProductServiceBillingFrequencyDTO"/>.</param>
        static partial void OnEntity(this ProductServiceBillingFrequencyDTO dto, CTProductServiceBillingFreq entity);
 

        /// <summary>
        /// Converts this instance of <see cref="CTProductServiceBillingFreq"/> to an instance of <see cref="ProductServiceBillingFrequencyDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTProductServiceBillingFreq"/> to convert.</param>
        public static ProductServiceBillingFrequencyDTO ToDTO(this CTProductServiceBillingFreq entity)
        {
            if (entity == null) return null;

            var dto = new ProductServiceBillingFrequencyDTO()
            {
                Id = entity.ID,
                BillingFrequencyId = entity.BILLING_FREQ_ID,
                BillingTypeId = entity.BILLING_TYPE_ID,
                BillingFrequencyNameEN= entity.BILLING_FREQUENCY,
                BillingTypeNameEN = entity.BILLING_TYPE,
                CustomerId = entity.CUSTOMER_ID
            };
            entity.OnDTO(dto);
            return dto;
        }

      

        /// <summary>
        /// Converts each instance of <see cref="CTProductServiceBillingFreq"/> to an instance of <see cref="ProductServiceBillingFrequencyDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ProductServiceBillingFrequencyDTO> ToDTOs(this IEnumerable<CTProductServiceBillingFreq> entities)
        {
            return LinqExtension.ToDTO<CTProductServiceBillingFreq, ProductServiceBillingFrequencyDTO>(entities, ToDTO);
        }

    }
}
