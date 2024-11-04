using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class TransactionSearchMapper
    {
        
        static partial void OnDTO(this CTTransactionSearch entity, TransactionSearchDTO dto);

        static partial void OnEntity(this TransactionSearchDTO dto, CTTransactionSearch entity);

        public static CTTransactionSearch ToEntity(this TransactionSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTransactionSearch();
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.TRANS_FROM_DATE = dto.FromDate == System.DateTime.MinValue ? null : dto.FromDate;
            entity.TRANS_TO_DATE = dto.ToDate == System.DateTime.MinValue ? null : dto.ToDate;
            entity.TOKEN_TYPE_ID = dto.TokenTypeID;
            entity.TOKEN_TYPE = dto.TokenType;
            entity.TOKEN_TYPE_AR = dto.TokenTypeAr;
            entity.STATION_ID = dto.StationID;
            entity.StationNameAr = dto.StationNameAr;
            entity.StationNameEn = dto.StationNameEn;
            entity.ProductNameEn = dto.ProductNameEn;
            entity.ProductNameAr = dto.ProductNameAr;
            entity.PRODUCT_ID = dto.ProductID;
            entity.SERIAL = dto.Serial;
            entity.GROUP_ID = dto.GroupID;
            entity.TRANSACTION_DATE = dto.TransactionDate == System.DateTime.MinValue ? null : dto.TransactionDate;
            entity.TRANSACTION_AMOUNT = dto.TransactionAmount;
            entity.TRANSACTION_ADJUSTMENT = dto.Adjustment;
            entity.TRANSACTION_PAID_AMOUNT = dto.PaidAmount;

            dto.OnEntity(entity);

            return entity;
        }
      
        public static TransactionSearchDTO ToDTO(this CTTransactionSearch entity)
        {
            if (entity == null) return null;

            var dto = new TransactionSearchDTO();
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.FromDate = entity.TRANS_FROM_DATE;
            dto.ToDate = entity.TRANS_TO_DATE;
            dto.TokenTypeID = entity.TOKEN_TYPE_ID;
            dto.TokenType = entity.TOKEN_TYPE;
            dto.TokenTypeAr = entity.TOKEN_TYPE_AR;
            dto.StationID = entity.STATION_ID;
            dto.StationNameEn = entity.StationNameEn;
            dto.StationNameAr = entity.StationNameAr;
            dto.ProductID = entity.PRODUCT_ID;
            dto.ProductNameEn = entity.ProductNameEn;
            dto.ProductNameAr = entity.ProductNameAr;
            dto.Serial = entity.SERIAL;
            dto.GroupID = entity.GROUP_ID;
            dto.TransactionDate = entity.TRANSACTION_DATE;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.Adjustment = entity.TRANSACTION_ADJUSTMENT;
            dto.PaidAmount = entity.TRANSACTION_PAID_AMOUNT;

            entity.OnDTO(dto);

            return dto;
        }
       
        public static List<CTTransactionSearch> ToEntities(this IEnumerable<TransactionSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTransactionSearch, TransactionSearchDTO>(dtos, ToEntity);
        }

        public static List<TransactionSearchDTO> ToDTOs(this IEnumerable<CTTransactionSearch> entities)
        {
            return LinqExtension.ToDTO<CTTransactionSearch, TransactionSearchDTO>(entities, ToDTO);
        }

    }
}




