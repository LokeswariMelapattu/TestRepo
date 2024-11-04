using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="PRODUCT"/> and <see cref="ProductDTO"/>.
    /// </summary>
    public static partial class ProductMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ProductDTO"/> converted from <see cref="PRODUCT"/>.</param>
        static partial void OnDTO(this PRODUCT entity, ProductDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PRODUCT"/> converted from <see cref="ProductDTO"/>.</param>
        static partial void OnEntity(this ProductDTO dto, PRODUCT entity);

        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ProductDTO"/> converted from <see cref="PRODUCT"/>.</param>
        static partial void OnDTO(this CTProductDTO entity, ProductDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PRODUCT"/> converted from <see cref="ProductDTO"/>.</param>
        static partial void OnEntity(this ProductDTO dto, CTProductDTO entity);

        /// <summary>
        /// Converts this instance of <see cref="ProductDTO"/> to an instance of <see cref="PRODUCT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ProductDTO"/> to convert.</param>
        public static PRODUCT ToEntity(this ProductDTO dto)
        {
            if (dto == null) return null;

            var entity = new PRODUCT();

            entity.PRODUCT_ID = dto.ProductID;
            entity.EN_NAME = dto.ProductName;
            entity.UNIT_PRICE = dto.UnitPrice;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            // entity.ISDRY = dto.ISDRY;
            entity.AR_NAME = dto.ARProductName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="PRODUCT"/> to an instance of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="PRODUCT"/> to convert.</param>
        public static ProductDTO ToDTO(this PRODUCT entity)
        {
            if (entity == null) return null;

            var dto = new ProductDTO();

            dto.ProductID = entity.PRODUCT_ID;
            dto.ProductName = entity.EN_NAME;
            dto.UnitPrice = entity.UNIT_PRICE.HasValue ? entity.UNIT_PRICE.Value : 0;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.ISDRY = entity.IS_DRY;
            dto.ARProductName = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.ColorCode = entity.COLOR_CODE;
            dto.ProductCategoryID = (int?)entity.PRODUCT_CATEGORY_ID;
            entity.OnDTO(dto);

            return dto;
        }


        /// <summary>
        /// Converts this instance of <see cref="PRODUCT"/> to an instance of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="PRODUCT"/> to convert.</param>
        public static ProductDTO ToDTO(this CTProductDTO entity)
        {
            if (entity == null) return null;

            var dto = new ProductDTO();

            dto.ProductID = entity.ProductID;
            dto.ProductName = entity.ProductName;
            dto.UnitPrice = entity.UnitPrice;
            //dto.ISDRY = entity.ISDRY;


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ProductDTO"/> to an instance of <see cref="PRODUCT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PRODUCT> ToEntities(this IEnumerable<ProductDTO> dtos)
        {
            return LinqExtension.ToEntity<PRODUCT, ProductDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="PRODUCT"/> to an instance of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ProductDTO> ToDTOs(this IEnumerable<PRODUCT> entities)
        {
           // return LinqExtension.ToDTO<PRODUCT, ProductDTO>(entities, ToDTO);
            if (entities == null) return null;
            var dtos = new List<ProductDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }



        /// <summary>
        /// Converts each instance of <see cref="PRODUCT"/> to an instance of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ProductDTO> ToDTOs(this IEnumerable<CTProductDTO> entities)
        {
            return LinqExtension.ToDTO<CTProductDTO, ProductDTO>(entities, ToDTO);
        }

    }
}
