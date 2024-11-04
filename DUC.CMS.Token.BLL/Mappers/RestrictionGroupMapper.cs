using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.DAL.Repository;
using System.Linq;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class RestrictionGroupMapper
    {       
        static partial void OnDTO(this CTRestrictionGroup entity, RestrictionGroupDTO dto);

        static partial void OnCDTO(this CTRestrictionGroupInfo entity, RestrictionGroupDTO dto);

        static partial void OnPDTO(this CTRestrictionGroupProfile entity, RestrictionGroupDTO dto);

        static partial void OnPSDTO(this CTRestrictionGroupProfile entity, RestrictionGroupDTO dto);   

        static partial void OnEntity(this RestrictionGroupDTO dto, CTRestrictionGroup entity);
       
        public static CTRestrictionGroup ToEntity(this RestrictionGroupDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRestrictionGroup();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID == null ? -1 : dto.RestrictionGroupID;
            entity.RS_GRP_NAME = dto.Name;
            entity.RS_GRP_DESCRIPTION = dto.Description;
            entity.RS_GRP_IS_SYS_DEF_GRP = Convert.ToInt16(dto.IsSystemDefinedRestrictionGroup);
            entity.CONSECUTIVE_USAGE_RESTRICTION = dto.ConsecutiveUsageRestriction;
            entity.IS_RESTRICTED_IN_HOLIDAY = Convert.ToInt16(dto.HolidayRestriction);
            entity.IS_REQUIRE_ODOMETER_INPUT = Convert.ToInt16(dto.RequireOdometerInput);
            entity.IS_REQUIRE_DRIVER_CARD = Convert.ToInt16(dto.RequireDriverCard);
            entity.CAN_BUY_DRY_STOCK = Convert.ToInt16(dto.CanBuyDryStock);
            entity.CAN_USE_ADNOC_SERVICE = Convert.ToInt16(dto.CanUseAdnocService);
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.RS_AMOUNT = dto.RsAmount;
            entity.RS_PRODUCT = dto.RsProduct;
            entity.RS_QUANTITY = dto.RsQuantity;
            entity.RS_STATION = dto.RsStation;
            entity.RS_TRANSNO = dto.RsTransNo;
            entity.RS_TRANS = dto.RsTransaction;
            entity.RS_WEEKDAY = dto.RsWeekday;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.RS_TIME = dto.RsTime;
            
            dto.OnEntity(entity);

            return entity;
        }
 
        public static RestrictionGroupDTO ToDTO(this CTRestrictionGroup entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionGroupDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.Name = entity.RS_GRP_NAME;
            dto.Description = entity.RS_GRP_DESCRIPTION;
            dto.ConsecutiveUsageRestriction = entity.CONSECUTIVE_USAGE_RESTRICTION;
            dto.HolidayRestriction = Convert.ToBoolean(entity.IS_RESTRICTED_IN_HOLIDAY);
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            //dto.LAST_UPDATED_USER_ID = entity.LAST_UPDATED_USER_ID;
            //dto.LAST_UPDATED_DATE = entity.LAST_UPDATED_DATE;
            dto.IsSystemDefinedRestrictionGroup = Convert.ToBoolean(entity.RS_GRP_IS_SYS_DEF_GRP);
            dto.RequireOdometerInput = Convert.ToBoolean(entity.IS_REQUIRE_ODOMETER_INPUT);
            dto.RequireDriverCard = Convert.ToBoolean(entity.IS_REQUIRE_DRIVER_CARD);
            dto.CanBuyDryStock = Convert.ToBoolean(entity.CAN_BUY_DRY_STOCK);
            dto.CanUseAdnocService = Convert.ToBoolean(entity.CAN_USE_ADNOC_SERVICE);

            entity.OnDTO(dto);

            return dto;
        }

        public static RestrictionGroupDTO ToCDTO(this CTRestrictionGroupInfo entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionGroupDTO();

            dto.RestrictionGroupID = entity.RS_GRP_ID;
            dto.Name = entity.RS_GRP_NAME;
            dto.Description = entity.RS_GRP_DESCRIPTION;
            dto.IsSystemDefinedRestrictionGroup = Convert.ToBoolean(entity.RS_GRP_IS_SYS_DEF_GRP);
            dto.ConsecutiveUsageRestriction = entity.RS_GRP_CONSEC_USG_RS;
            dto.HolidayRestriction = Convert.ToBoolean(entity.RS_GRP_IS_RS_IN_HILIDAY);
            dto.IsActive = Convert.ToBoolean(entity.RS_GRP_IS_ACTIVE);
            dto.RequireOdometerInput = Convert.ToBoolean(entity.RS_GRP_IS_REQ_ODOMTR_INPUT);
            dto.RequireDriverCard = Convert.ToBoolean(entity.RS_GRP_IS_REQ_DRIVER_CARD);
            dto.CanBuyDryStock = Convert.ToBoolean(entity.RS_GRP_CAN_BUY_DRY_STOCK);
            //dto._RestrictionAmountDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionAmountDTO>>(() => new TokenAppService().GetRestrictionAmount((int)entity.RS_GRP_ID));
            //dto._RestrictionProductDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionProductDTO>>(() => new TokenAppService().GetRestrictionProduct((int)entity.RS_GRP_ID));
            //dto._RestrictionQuantityDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionQuantityDTO>>(() => new TokenAppService().GetRestrictionQuantity((int)entity.RS_GRP_ID));
            //dto._RestrictionStationDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RS_GRP_ID));
            //dto._RestrictionTransNoDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionTransNoDTO>>(() => new TokenAppService().GetRestrictionTransNo((int)entity.RS_GRP_ID));
            //dto._RestrictionTransactionDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionTransactionDTO>>(() => new TokenAppService().GetRestrictionTransaction((int)entity.RS_GRP_ID));
            //dto._RestrictionWeekDayDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RS_GRP_ID));
            dto._RestrictionGroupTimeDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionGroupTimeDTO>>(() => new TokenAppService().GetRestrictionGroupTime((int)entity.RS_GRP_ID));

            dto.ProductCategoryRestrictionLazy = new Lazy<List<ProductCategroryRestrictionDTO>>(() => LoadProductCategoryRestriction(entity.RS_GRP_ID.Value));
            dto._RestrictionStationDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RS_GRP_ID));
            dto._RestrictionWeekDayDTO = entity.RS_GRP_ID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RS_GRP_ID));


            entity.OnCDTO(dto);

            return dto;
        }

        public static RestrictionGroupDTO ToPDTO(this CTRestrictionGroupProfile entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionGroupDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.Name = entity.NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsSystemDefinedRestrictionGroup = Convert.ToBoolean(entity.IS_SYSTEM_DEFINED_GROUP);
            dto.ConsecutiveUsageRestriction = entity.CONSECUTIVE_USAGE_RESTRICTION;
            dto.HolidayRestriction = Convert.ToBoolean(entity.IS_RESTRICTED_IN_HOLIDAY);
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.RequireOdometerInput = Convert.ToBoolean(entity.IS_REQUIRE_ODOMETER_INPUT);
            dto.RequireDriverCard = Convert.ToBoolean(entity.IS_REQUIRE_DRIVER_CARD);
            dto.CanBuyDryStock = Convert.ToBoolean(entity.CAN_BUY_DRY_STOCK);
            dto.CanUseAdnocService = Convert.ToBoolean(entity.CAN_USE_ADNOC_SERVICE);        
            entity.OnPDTO(dto);

            return dto;
        }

        public static RestrictionGroupDTO ToPSDTO(this CTRestrictionGroupProfile entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionGroupDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.Name = entity.NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsSystemDefinedRestrictionGroup = Convert.ToBoolean(entity.IS_SYSTEM_DEFINED_GROUP);
            dto.ConsecutiveUsageRestriction = entity.CONSECUTIVE_USAGE_RESTRICTION;
            dto.HolidayRestriction = Convert.ToBoolean(entity.IS_RESTRICTED_IN_HOLIDAY);
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.RequireOdometerInput = Convert.ToBoolean(entity.IS_REQUIRE_ODOMETER_INPUT);
            dto.RequireDriverCard = Convert.ToBoolean(entity.IS_REQUIRE_DRIVER_CARD);
            dto.CanBuyDryStock = Convert.ToBoolean(entity.CAN_BUY_DRY_STOCK);
            dto.CanUseAdnocService = Convert.ToBoolean(entity.CAN_USE_ADNOC_SERVICE);
            //dto._RestrictionAmountDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionAmountDTO>>(() => new TokenAppService().GetRestrictionAmount((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionProductDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionProductDTO>>(() => new TokenAppService().GetRestrictionProduct((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionQuantityDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionQuantityDTO>>(() => new TokenAppService().GetRestrictionQuantity((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionStationDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionTransNoDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionTransNoDTO>>(() => new TokenAppService().GetRestrictionTransNo((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionTransactionDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionTransactionDTO>>(() => new TokenAppService().GetRestrictionTransaction((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionWeekDayDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RESTRICTION_GROUP_ID));
            //dto._RestrictionGroupTimeDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionGroupTimeDTO>>(() => new TokenAppService().GetRestrictionGroupTime((int)entity.RESTRICTION_GROUP_ID));

            dto.ProductCategoryRestrictionLazy = new Lazy<List<ProductCategroryRestrictionDTO>>(() => LoadProductCategoryRestriction(entity.RESTRICTION_GROUP_ID.Value));
            dto._RestrictionStationDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionStationDTO>>(() => new TokenAppService().GetRestrictionStation((int)entity.RESTRICTION_GROUP_ID));
            dto._RestrictionWeekDayDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionWeekDayDTO>>(() => new TokenAppService().GetRestrictionWeekDay((int)entity.RESTRICTION_GROUP_ID));
            dto._RestrictionGroupTimeDTO = entity.RESTRICTION_GROUP_ID == null ? null : new Lazy<List<RestrictionGroupTimeDTO>>(() => new TokenAppService().GetRestrictionGroupTime((int)entity.RESTRICTION_GROUP_ID));


            entity.OnPSDTO(dto);

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

        public static List<CTRestrictionGroup> ToEntities(this IEnumerable<RestrictionGroupDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRestrictionGroup, RestrictionGroupDTO>(dtos, ToEntity);
        }

        public static List<RestrictionGroupDTO> ToDTOs(this IEnumerable<CTRestrictionGroup> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroup, RestrictionGroupDTO>(entities, ToDTO);
        }

        public static List<RestrictionGroupDTO> ToCDTOs(this IEnumerable<CTRestrictionGroupInfo> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupInfo, RestrictionGroupDTO>(entities, ToCDTO);
        }

        public static List<RestrictionGroupDTO> ToPDTOs(this IEnumerable<CTRestrictionGroupProfile> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupProfile, RestrictionGroupDTO>(entities, ToPDTO);
        }
       
    }
}







