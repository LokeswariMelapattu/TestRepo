using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/> and <see cref="UpliftDiscountDTO"/>.
    /// </summary>
    public static partial class CustomerProductPriceUpliftMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UpliftDiscountDTO"/> converted from <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/>.</param>
        static partial void OnDTO(this CUSTOMER_PRODUCT_PRICE_UPLIFT entity, UpliftDiscountDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/> converted from <see cref="UpliftDiscountDTO"/>.</param>
        static partial void OnEntity(this UpliftDiscountDTO dto, CUSTOMER_PRODUCT_PRICE_UPLIFT entity);

        /// <summary>
        /// Converts this instance of <see cref="UpliftDiscountDTO"/> to an instance of <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/>.
        /// </summary>
        /// <param name="dto"><see cref="UpliftDiscountDTO"/> to convert.</param>
        public static UpliftDiscountArgument ToArgumentEntity(this UpliftDiscountDTO dto)
        {
            if (dto == null) return null;

            var entity = new UpliftDiscountArgument();

            entity.CustomerID = dto.CustomerID;
            entity.ProductID = dto.ProductID;
            entity.Quantity = dto.Quantity;
            entity.PriceUpliftDiscount = dto.PriceUpliftDiscount;
            entity.LastUpdatedDate = dto.LastUpdatedDate;
            entity.LastUpdatedUserId = dto.LastUpdatedUserId;
            entity.ProductName = dto.ProductName;
            entity.IsActive = (short)(dto.IsActive ? 1 : 0);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/> to an instance of <see cref="UpliftDiscountDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/> to convert.</param>
        public static UpliftDiscountDTO ToDTO(this CUSTOMER_PRODUCT_PRICE_UPLIFT entity)
        {
            if (entity == null) return null;

            var dto = new UpliftDiscountDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.ProductID = entity.PRODUCT_ID;
            dto.Quantity = entity.MONTHLY_QUANTITY.Value;
            dto.PriceUpliftDiscount = entity.UPLIFT_DISCOUNT_PERCENTAGE.Value;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ProductName = entity.PRODUCT != null ? entity.PRODUCT.EN_NAME : string.Empty;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="UpliftDiscountDTO"/> to an instance of <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<UpliftDiscountArgument> ToEntities(this IEnumerable<UpliftDiscountDTO> dtos)
        {
            return LinqExtension.ToEntity<UpliftDiscountArgument, UpliftDiscountDTO>(dtos, ToArgumentEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_PRODUCT_PRICE_UPLIFT"/> to an instance of <see cref="UpliftDiscountDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<UpliftDiscountDTO> ToDTOs(this IEnumerable<CUSTOMER_PRODUCT_PRICE_UPLIFT> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_PRODUCT_PRICE_UPLIFT, UpliftDiscountDTO>(entities, ToDTO);
        }

    }
}
