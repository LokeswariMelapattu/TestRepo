using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using System.Linq;
using DUC.CMS.CustomerService.DAL.Repository;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class TokenRestrictionMapper
    {
        static partial void OnDTO(this CTTokenRestriction entity, TokenRestrictionDTO dto);

        static partial void OnCDTO(this CTTokenRestrictionInfo entity, TokenRestrictionDTO dto);

        static partial void OnEntity(this TokenRestrictionDTO dto, CTTokenRestriction entity);

        public static CTTokenRestriction ToEntity(this TokenRestrictionDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTokenRestriction();

            entity.CUSTOMERID = dto.CustomerID;
            entity.BENEFICIARYID = dto.BeneficiaryID;
            entity.TOKENID = dto.TokenID;
            entity.TOKENNAME = dto.TokenName;
            entity.TOKENTYPEID = dto.TokenTypeID;
            entity.RESTRICTIONGROUPID = dto.RestrictionGroupID == null ? -1 : dto.RestrictionGroupID;
            entity.TOKENTYPE = dto.TokenType;
            entity.RESTRICTIONGROUPNAME = dto.RestrictionGroupName;
            entity.IS_SYSTEM_DEFINED_GROUP = Convert.ToInt16(dto.IsSystemDefinedRestrictionGroup);
            entity.CONSECUTIVE_USAGE_RESTRICTION = dto.ConsecutiveUsageRestriction;
            entity.IS_RESTRICTED_IN_HOLIDAY = Convert.ToInt16(dto.HolidayRestriction);
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.IS_REQUIRE_ODOMETER_INPUT = Convert.ToInt16(dto.RequireOdometerInput);
            entity.IS_REQUIRE_DRIVER_CARD = Convert.ToInt16(dto.RequireDriverCard);
            entity.CAN_BUY_DRY_STOCK = Convert.ToInt16(dto.CanBuyDryStock);
            entity.CAN_USE_ADNOC_SERVICE = Convert.ToInt16(dto.CanUseAdnocService);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATE_DATE = dto.LastUpdatedDate;
            entity.RS_AMOUNT = dto.RsAmount;
            entity.RS_PRODUCT = dto.RsProduct;
            entity.RS_QUANTITY = dto.RsQuantity;
            entity.RS_STATION = dto.RsStation;
            entity.RS_TRANSNO = dto.RsTransNo;
            entity.RS_TRANS = dto.RsTransaction;
            entity.RS_WEEKDAY = dto.RsWeekday;
            entity.RS_TIME = dto.RsTime;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATE_DATE = dto.LastUpdatedDate;
            entity.LastLocationID =(int)dto.LastUpdatedLocationID;


            dto.OnEntity(entity);

            return entity;
        }

        public static TokenRestrictionDTO ToDTO(this CTTokenRestriction entity)
        {
            if (entity == null) return null;

            var dto = new TokenRestrictionDTO();

            dto.CustomerID = entity.CUSTOMERID;
            dto.BeneficiaryID = entity.BENEFICIARYID;
            dto.TokenID = entity.TOKENID;
            dto.TokenName = entity.TOKENNAME;
            dto.TokenTypeID = entity.TOKENTYPEID;
            dto.TokenType = entity.TOKENTYPE;
            dto.RestrictionGroupID = entity.RESTRICTIONGROUPID;
            dto.RestrictionGroupName = entity.RESTRICTIONGROUPNAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static TokenRestrictionDTO ToCDTO(this CTTokenRestrictionInfo entity)
        {
            if (entity == null) return null;

            var dto = new TokenRestrictionDTO();

            dto.CustomerID = entity.CUSTOMERID;
            dto.BeneficiaryID = entity.BENEFICIARYID;
            dto.TokenID = entity.TOKENID;
            dto.TokenName = entity.TOKENNAME;
            dto.TokenTypeID = entity.TOKENTYPEID;
            dto.TokenType = entity.TOKENTYPE;
            dto.TokenTypeAr = entity.TokenTypeAR;
            dto.RestrictionGroupID = entity.RESTRICTIONGROUPID;
            dto.RestrictionGroupName = entity.RESTRICTIONGROUPNAME;


            //dto.ProductCategoryRestrictionLazy = new Lazy<List<ProductCategroryRestrictionDTO>>(() => LoadProductCategoryRestriction(entity.RESTRICTIONGROUPID.Value));

            //dto._RestrictionProductDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionProductDTO>>(() => new TokenAppService().GetRestrictionProduct((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionAmountDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionAmountDTO>>(() => new TokenAppService().GetRestrictionAmount((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionQuantityDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionQuantityDTO>>(() => new TokenAppService().GetRestrictionQuantity((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionStationDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionTransNoDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionTransNoDTO>>(() => new TokenAppService().GetRestrictionTransNo((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionTransactionDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionTransactionDTO>>(() => new TokenAppService().GetRestrictionTransaction((int)entity.RESTRICTIONGROUPID));
            //dto._RestrictionWeekDayDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RESTRICTIONGROUPID));

            //dto._RestrictionGroupTimeDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionGroupTimeDTO>>(() => new TokenAppService().GetRestrictionGroupTime((int)entity.RESTRICTIONGROUPID));


            dto.ProductCategoryRestrictionLazy = new Lazy<List<ProductCategroryRestrictionDTO>>(() => LoadProductCategoryRestriction(entity.RESTRICTIONGROUPID.Value));
            dto._RestrictionStationDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RESTRICTIONGROUPID));
            dto._RestrictionWeekDayDTO = entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RESTRICTIONGROUPID));
            dto._RestrictionGroupTimeDTO= entity.RESTRICTIONGROUPID == null ? null : new Lazy<List<RestrictionGroupTimeDTO>>(() => new TokenAppService().GetRestrictionGroupTime((int)entity.RESTRICTIONGROUPID));


            if (entity.RESTRICTIONGROUPID != null)
            {
                var otherRestriction = new TokenAppService().GetRestrictionGroupById((int)entity.RESTRICTIONGROUPID);
                if (otherRestriction != null)
                {
                    dto.IsSystemDefinedRestrictionGroup = otherRestriction.IsSystemDefinedRestrictionGroup;
                    dto.ConsecutiveUsageRestriction = otherRestriction.ConsecutiveUsageRestriction;
                    dto.HolidayRestriction = otherRestriction.HolidayRestriction;
                    dto.IsActive = otherRestriction.IsActive;
                    dto.RequireOdometerInput = otherRestriction.RequireOdometerInput;
                    dto.RequireDriverCard = otherRestriction.RequireDriverCard;
                    dto.CanBuyDryStock = otherRestriction.CanBuyDryStock;
                    dto.CanUseAdnocService = otherRestriction.CanUseAdnocService;
                }
            }
            entity.OnCDTO(dto);

            return dto;
        }

        private static List<ProductCategroryRestrictionDTO> LoadProductCategoryRestriction(int restrictionGroupID)
        {
            List<ProductCategroryRestrictionDTO> restrictions = new List<DTO.ProductCategroryRestrictionDTO>();
            using (var uow = new UnitOfWork())
            {
                var customerRepository = new CustomerRepository(uow);
                var tokenAppService = new TokenAppService();

                var productCategories = customerRepository.GetAllProductCategories();

                var productRestrictions = tokenAppService.GetRestrictionProduct(restrictionGroupID);
                var amountRestrictions = tokenAppService.GetRestrictionAmount(restrictionGroupID);
                var transactionRestrictions = tokenAppService.GetRestrictionTransaction(restrictionGroupID);
                var transNoRestrictions = tokenAppService.GetRestrictionTransNo(restrictionGroupID);
                var quantityRestrictions = tokenAppService.GetRestrictionQuantity(restrictionGroupID);

                foreach (var category in productCategories)
                {
                    var restriction = new ProductCategroryRestrictionDTO();
                    restriction.ProductCategoryID = category.PRODUCT_CATEGORY_ID.Value;

                    restriction.RestrictionProductDTO = new List<RestrictionProductDTO>(productRestrictions.Where(x => x.ProductCategoryID == category.PRODUCT_CATEGORY_ID));

                    if (category.IS_AMOUNT_RESTRICTION == 1)
                        restriction.RestrictionAmountDTO = new List<RestrictionAmountDTO>(amountRestrictions.Where(x => x.ProductCategoryID == category.PRODUCT_CATEGORY_ID));

                    if (category.IS_PER_TRANSACTION_LIMIT == 1)
                        restriction.RestrictionTransactionDTO = new List<RestrictionTransactionDTO>(transactionRestrictions.Where(x => x.ProductCategoryID == category.PRODUCT_CATEGORY_ID));

                    if (category.IS_TRANSACTION_FREQUENCY == 1)
                        restriction.RestrictionTransNoDTO = new List<RestrictionTransNoDTO>(transNoRestrictions.Where(x => x.ProductCategoryID == category.PRODUCT_CATEGORY_ID));

                    if (category.IS_QUANTITY_RESTRICTION == 1)
                        restriction.RestrictionQuantityDTO = new List<RestrictionQuantityDTO>(quantityRestrictions.Where(x => x.ProductCategoryID == category.PRODUCT_CATEGORY_ID));

                    restrictions.Add(restriction);
                }
            }
            return restrictions;
        }

        public static List<CTTokenRestriction> ToEntities(this IEnumerable<TokenRestrictionDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTokenRestriction, TokenRestrictionDTO>(dtos, ToEntity);
        }

        public static List<TokenRestrictionDTO> ToDTOs(this IEnumerable<CTTokenRestriction> entities)
        {
            return LinqExtension.ToDTO<CTTokenRestriction, TokenRestrictionDTO>(entities, ToDTO);
        }

        public static List<TokenRestrictionDTO> ToCDTOs(this IEnumerable<CTTokenRestrictionInfo> entities)
        {
            return LinqExtension.ToDTO<CTTokenRestrictionInfo, TokenRestrictionDTO>(entities, ToCDTO);
        }

    }
}




