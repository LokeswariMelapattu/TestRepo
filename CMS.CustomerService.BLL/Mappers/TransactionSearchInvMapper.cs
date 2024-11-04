using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTTransactionSearch"/> and <see cref="TransactionSearchDTO"/>.
    /// </summary>
    public static partial class TransactionSearchInvMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="TransactionSearchDTO"/> converted from <see cref="CTTransactionSearch"/>.</param>
        static partial void OnDTO(this CTTransactionSearchInv entity, TransactionSearchInvDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTTransactionSearch"/> converted from <see cref="TransactionSearchDTO"/>.</param>
        static partial void OnEntity(this TransactionSearchInvDTO dto, CTTransactionSearchInv entity);

        /// <summary>
        /// Converts this instance of <see cref="TransactionSearchDTO"/> to an instance of <see cref="CTTransactionSearch"/>.
        /// </summary>
        /// <param name="dto"><see cref="TransactionSearchDTO"/> to convert.</param>
        public static CTTransactionSearchInv ToEntity(this TransactionSearchInvDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTransactionSearchInv();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.BENEFICIARY_CODE = dto.BeneficiaryCode;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.TRANS_FROM_DATE = dto.FromDate;
            entity.TRANS_TO_DATE = dto.ToDate;
            entity.TOKEN_TYPE_ID = dto.TokenTypeID;
            entity.TOKEN_TYPE = dto.TokenType;
            entity.STATION_ID = dto.StationID;
            entity.PRODUCT_ID = dto.ProductID;
            entity.SERIAL = dto.Serial;
            entity.GROUP_ID = dto.GroupID;
            entity.TRANSACTION_DATE = dto.TransactionDate == System.DateTime.MinValue ? null : dto.TransactionDate;
            entity.TRANSACTION_AMOUNT = dto.TransactionAmount;
            entity.TRANSACTION_ADJUSTMENT = dto.Adjustment;
            entity.TRANSACTION_PAID_AMOUNT = dto.PaidAmount;
            entity.Invoice_ID = dto.InvoiceID;
            entity.VAT_INV_NUM = dto.VAT_INV_NUM;


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTTransactionSearch"/> to an instance of <see cref="TransactionSearchDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTTransactionSearch"/> to convert.</param>
        public static TransactionSearchInvDTO ToDTO(this CTTransactionSearchInv entity)
        {
            if (entity == null) return null;

            var dto = new TransactionSearchInvDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.BeneficiaryCode = entity.BENEFICIARY_CODE;
            dto.FromDate = entity.TRANS_FROM_DATE;
            dto.ToDate = entity.TRANS_TO_DATE;
            dto.TokenTypeID = entity.TOKEN_TYPE_ID;
            dto.TokenType = entity.TOKEN_TYPE;
            dto.StationID = entity.STATION_ID;
            dto.ProductID = entity.PRODUCT_ID;
            dto.Serial = entity.SERIAL;
            dto.GroupID = entity.GROUP_ID;
            dto.TransactionDate = entity.TRANSACTION_DATE;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.Adjustment = entity.TRANSACTION_ADJUSTMENT;
            dto.PaidAmount = entity.TRANSACTION_PAID_AMOUNT;
            dto.StationNameEn = entity.StationNameEn;
            dto.ProductNameEn = entity.ProductNameEn;
            dto.StationNameAr = entity.StationNameAr;
            dto.ProductNameAr = entity.ProductNameAr;
            // dto.TokenTypeAr = entity.TOKEN_TYPE_AR;   
            dto.OnlineDPRuleName = entity.ONLINE_DP_RULE_NAME;
            dto.OnlineDPRuleId = entity.ONLINE_DP_RULE_ID;
            dto.EOMDPRuleName = entity.EOM_DP_RILE_NAME;
            dto.EOMDPRuleId = entity.EOM_DP_RULE_ID;
            dto.VAT_Amount = entity.VAT_Amount;
            dto.VAT_Code = entity.VAT_Code;
            dto.VAT_INV_NUM = entity.VAT_INV_NUM;
            dto.VAT_RATE = entity.VAT_RATE;


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="TransactionSearchDTO"/> to an instance of <see cref="CTTransactionSearch"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTTransactionSearchInv> ToEntities(this IEnumerable<TransactionSearchInvDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTransactionSearchInv, TransactionSearchInvDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTTransactionSearch"/> to an instance of <see cref="TransactionSearchDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<TransactionSearchInvDTO> ToDTOs(this IEnumerable<CTTransactionSearchInv> entities)
        {
            return LinqExtension.ToDTO<CTTransactionSearchInv, TransactionSearchInvDTO>(entities, ToDTO);
        }

    }
}
