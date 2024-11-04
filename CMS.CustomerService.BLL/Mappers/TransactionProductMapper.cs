using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="PRODUCT"/> and <see cref="ProductDTO"/>.
    /// </summary>
    public static partial class TransactionProductMapper
    {

        static partial void OnDTO(this CTProduct entity, TransactionProductDTO dto);


        static partial void OnEntity(this TransactionProductDTO dto, CTProduct entity);


        public static CTProduct ToEntity(this TransactionProductDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTProduct();

            entity.PRODUCT_ID = dto.ProductID;
            entity.EN_NAME = dto.ProductName;
            entity.UNIT_PRICE = dto.UnitPrice;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.IS_DRY = dto.ISDRY;
            entity.AR_NAME = dto.ARProductName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.INTEGRATION_CODE = dto.IntegrationCode;
            entity.INTEGRATION_ID = dto.IntegrationID;
            entity.IS_SERVICE = dto.IsService;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            entity.COLOR_CODE = dto.ColorCode;
            dto.OnEntity(entity);

            return entity;
        }


        public static TransactionProductDTO ToDTO(this CTProduct entity)
        {
            if (entity == null) return null;

            var dto = new TransactionProductDTO();

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
            dto.IntegrationCode = entity.INTEGRATION_CODE;
            dto.IntegrationID = entity.INTEGRATION_ID;
            dto.IsService = entity.IS_SERVICE;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTProduct> ToEntities(this IEnumerable<TransactionProductDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProduct, TransactionProductDTO>(dtos, ToEntity);
        }


        public static List<TransactionProductDTO> ToDTOs(this IEnumerable<CTProduct> entities)
        {
            // return LinqExtension.ToDTO<PRODUCT, ProductDTO>(entities, ToDTO);
            if (entities == null) return null;
            var dtos = new List<TransactionProductDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }

    public static partial class ProductCategoryMapper
    {
        static partial void OnDTO(this CTProductCategory entity, ProductCategoryDTO dto);


        static partial void OnEntity(this ProductCategoryDTO dto, CTProductCategory entity);


        public static CTProductCategory ToEntity(this ProductCategoryDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTProductCategory();
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            entity.EN_NAME = dto.Name;
            entity.AR_NAME = dto.NameAr;
            entity.IS_ACTIVE = dto.IsActive;
            entity.IS_AMOUNT_RESTRICTION = dto.IsAmountRestriction == true ? 1 : 0;
            entity.IS_PER_TRANSACTION_LIMIT = dto.IsPerTransactionLimit == true ? 1 : 0;
            entity.IS_PRODUCT_RESTRICTION = dto.IsProductRestriction == true ? 1 : 0;
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            entity.IS_QUANTITY_RESTRICTION = dto.IsQuantityRestriction == true ? 1 : 0;
            entity.IS_TRANSACTION_FREQUENCY = dto.IsTransactionFrequency == true ? 1 : 0;
            dto.OnEntity(entity);

            return entity;
        }


        public static ProductCategoryDTO ToDTO(this CTProductCategory entity)
        {
            if (entity == null) return null;

            var dto = new ProductCategoryDTO();
            dto.ProductCategoryID = entity.PRODUCT_CATEGORY_ID;
            dto.Name = entity.EN_NAME;
            dto.NameAr = entity.AR_NAME;
            dto.IsActive = entity.IS_ACTIVE;
            dto.IsAmountRestriction = entity.IS_AMOUNT_RESTRICTION == 1 ? true : false;
            dto.IsPerTransactionLimit = entity.IS_PER_TRANSACTION_LIMIT == 1 ? true : false;
            dto.IsProductRestriction = entity.IS_PRODUCT_RESTRICTION == 1 ? true : false;
            dto.IsQuantityRestriction = entity.IS_QUANTITY_RESTRICTION == 1 ? true : false;
            dto.IsTransactionFrequency = entity.IS_TRANSACTION_FREQUENCY == 1 ? true : false;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTProductCategory> ToEntities(this IEnumerable<ProductCategoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProductCategory, ProductCategoryDTO>(dtos, ToEntity);
        }


        public static List<ProductCategoryDTO> ToDTOs(this IEnumerable<CTProductCategory> entities)
        {
            if (entities == null) return null;
            var dtos = new List<ProductCategoryDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }

    public static partial class CategoryMapper
    {
        static partial void OnDTO(this CTProductCategoryDTO entity, CategoryDTO dto);


        static partial void OnEntity(this CategoryDTO dto, CTProductCategoryDTO entity);

        public static CTProductCategoryDTO ToEntity(this CategoryDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTProductCategoryDTO();
            entity.PRODUCT_CATEGORY_ID = dto.ProductCategoryID;
            entity.EN_NAME = dto.ProductCategoryName;
            entity.AR_NAME = dto.ProductCategoryARName;
            dto.OnEntity(entity);

            return entity;
        }


        public static CategoryDTO ToDTO(this CTProductCategoryDTO entity)
        {
            if (entity == null) return null;

            var dto = new CategoryDTO();
            dto.ProductCategoryID = entity.PRODUCT_CATEGORY_ID;
            dto.ProductCategoryName = entity.EN_NAME;
            dto.ProductCategoryARName = entity.AR_NAME;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTProductCategoryDTO> ToEntities(this IEnumerable<CategoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProductCategoryDTO, CategoryDTO>(dtos, ToEntity);
        }


        public static List<CategoryDTO> ToDTOs(this IEnumerable<CTProductCategoryDTO> entities)
        {
            if (entities == null) return null;
            var dtos = new List<CategoryDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
