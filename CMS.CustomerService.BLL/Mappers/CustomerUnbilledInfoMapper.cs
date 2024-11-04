using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerUnbilledInfo"/> and <see cref="CustomerUnBilledDTO"/>.
    /// </summary>
    public static partial class CustomerUnbilledInfoMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerUnBilledDTO"/> converted from <see cref="CTCustomerUnbilledInfo"/>.</param>
        static partial void OnDTO(this CTCustomerUnbilledInfo entity, CustomerUnBilledDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerUnbilledInfo"/> converted from <see cref="CustomerUnBilledDTO"/>.</param>
        static partial void OnEntity(this CustomerUnBilledDTO dto, CTCustomerUnbilledInfo entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerUnBilledDTO"/> to an instance of <see cref="CTCustomerUnbilledInfo"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerUnBilledDTO"/> to convert.</param>
        public static CTCustomerUnbilledInfo ToEntity(this CustomerUnBilledDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerUnbilledInfo();

            entity.CUSTOMER_ID = dto.CustomerId;
            entity.BENEFICIARY_ID = dto.BeneficiaryId;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.TRANSACTION_ID = dto.TransactionId;
            entity.TOKEN_TYPE_ID = dto.TokenTypeId;
            entity.Token_Type = dto.TokenType;
            entity.Token_Type_AR = dto.TokenTypeAr;
            entity.STATION_ID = dto.StationId;
            entity.STATION_NAME = dto.StationName;
            entity.STATION_NAME_AR = dto.StationNameAr;
            entity.PRODUCT_ID = dto.ProductId;
            entity.PRODUCT_NAME = dto.ProductName;
            entity.PRODUCT_NAME_AR = dto.ProductNameAr;
            entity.SERIAL = dto.Serial;
            entity.GROUP_ID = dto.GroupId;
            entity.TRANSACTION_DATE_TIME = dto.TransactionDateTime;
            entity.TRANSACTION_AMOUNT = dto.TransactionAmount;
            entity.Adjustment = dto.Adjustment;
            entity.PAID_AMOUNT = dto.PaidAmount;
            entity.LastBilledDate = dto.LastBilledDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerUnbilledInfo"/> to an instance of <see cref="CustomerUnBilledDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerUnbilledInfo"/> to convert.</param>
        public static CustomerUnBilledDTO ToDTO(this CTCustomerUnbilledInfo entity)
        {
            if (entity == null) return null;

            var dto = new CustomerUnBilledDTO();

            dto.CustomerId = entity.CUSTOMER_ID;
            dto.BeneficiaryId = entity.BENEFICIARY_ID;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.TransactionId = entity.TRANSACTION_ID;
            dto.TokenTypeId = entity.TOKEN_TYPE_ID;
            dto.TokenTypeAr = entity.Token_Type_AR;
            dto.TokenType = entity.Token_Type;
            dto.StationId = entity.STATION_ID;
            dto.StationName = entity.STATION_NAME;
            dto.StationNameAr = entity.STATION_NAME_AR;
            dto.ProductId = entity.PRODUCT_ID;
            dto.ProductName = entity.PRODUCT_NAME;
            dto.ProductNameAr = entity.PRODUCT_NAME_AR;
            dto.Serial = entity.SERIAL;
            dto.GroupId = entity.GROUP_ID;
            dto.TransactionDateTime = entity.TRANSACTION_DATE_TIME;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.Adjustment = entity.Adjustment;
            dto.PaidAmount = entity.PAID_AMOUNT;
            dto.LastBilledDate = entity.LastBilledDate;
            dto.OnlineDPRuleName = entity.ONLINE_DP_RULE_NAME;
            dto.OnlineDPRuleId = entity.ONLINE_DP_RULE_ID;
            dto.EOMDPRuleName = entity.EOM_DP_RILE_NAME;
            dto.EOMDPRuleId = entity.EOM_DP_RULE_ID;
            dto.VAT_Amount = entity.VAT_Amount;
            dto.VAT_Code = entity.VAT_Code;
            dto.VAT_INV_NUM = entity.VAT_INV_NUM;
            dto.VAT_Rate = entity.VAT_Rate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerUnBilledDTO"/> to an instance of <see cref="CTCustomerUnbilledInfo"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTCustomerUnbilledInfo> ToEntities(this IEnumerable<CustomerUnBilledDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerUnbilledInfo, CustomerUnBilledDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerUnbilledInfo"/> to an instance of <see cref="CustomerUnBilledDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerUnBilledDTO> ToDTOs(this IEnumerable<CTCustomerUnbilledInfo> entities)
        {
            return LinqExtension.ToDTO<CTCustomerUnbilledInfo, CustomerUnBilledDTO>(entities, ToDTO);
        }

    }
}
