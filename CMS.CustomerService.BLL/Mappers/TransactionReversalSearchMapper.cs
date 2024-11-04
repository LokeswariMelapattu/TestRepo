using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class TransactionReversalSearchMapper
    {
        internal static CTTransactionReversalSearch ToEntity(this TransactionReversalSearchDTO dto)
        {
            if (dto == null)
                return null;
            return new CTTransactionReversalSearch
            {
                AUTHORIZATION_CODE = dto.AuthorizationCode,
                BENEFICIARY_CODE = dto.BeneficiaryCode,
                BENEFICIARY_NAME = dto.BeneficiaryName,
                CUSTOMER_CODE = dto.CustomerCode,
                CUSTOMER_NAME = dto.CustomerName,
                FROM_DATE = dto.FromDate,
                PRODUCT_ID = dto.ProductId,
                RECEIPT_ID = dto.ReceiptId,
                STATION_ID = dto.StationId,
                TO_DATE = dto.ToDate,
                TOKEN_SERIAL = dto.TokenSerial,
                TOKEN_TYPE_ID = dto.TokenTypeId,
                TRANSACTION_TYPE_ID = dto.TransactionTypeId,
                VAT_INV_NUM = dto.VATInvoiceNumber,
                IsPremiumService = dto.IsPremiumService.HasValue ? (dto.IsPremiumService.Value ? (short)1 : (short)0) : (short?)null
            };
        }
    }
}
