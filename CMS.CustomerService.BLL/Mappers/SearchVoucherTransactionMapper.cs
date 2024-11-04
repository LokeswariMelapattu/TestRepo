using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class SearchVoucherTransactionMapper
    {
        static partial void OnDTO(this CTSearchVoucherTRX entity, SearchVoucherTransactionDTO dto);

        static partial void OnEntity(this SearchVoucherTransactionDTO dto, CTSearchVoucherTRX entity);

        public static CTSearchVoucherTRX ToEntity(this SearchVoucherTransactionDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchVoucherTRX();
            entity.RECEIPT_ID = dto.ReceiptID;
            entity.AR_NUMBER = dto.ARNumber;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.BENEFICIARY_NUMBER = dto.BeneficiaryNo;
            entity.CUSTOMER_NAME = dto.CustomerName;
            entity.CUSTOMER_NUMBER = dto.CustomerNo;
            entity.EN_PAYMENT_METHOD = dto.ENPaymentMethod;
            entity.IS_DISABLE_BENEFICIARY = dto.IsDisableBeneficiary;
            entity.IS_OFFLINE_TRANSACTION = dto.IsOfflineTransaction;
            entity.PAID_AMOUNT = dto.PaidAmount;
            entity.PRODUCT_NAME = dto.ProductName;
            entity.PRODUCT_PRICE = dto.ProductPrice;
            entity.PRODUCT_QUANTITY = dto.ProductQuantity;
            entity.STATION_NAME = dto.StationName;
            entity.TOTAL_AMOUNT = dto.TotalAmount;
            entity.TRANSACTIONTYPE = dto.TransactionType;
            entity.TRANSACTION_DATE = dto.TransactionDate;
            entity.TRANSACTION_AMOUNT = dto.TransactionAmount;
            entity.VAT_INVOICE_NO = dto.VATInvoiceNo;
            entity.VOUCHER_SERIAL = dto.VoucherSerialNo;
            entity.EXT_VOUCHER_NO = dto.ExternalVoucherNo;
            entity.FinancialAccountName = dto.FinancialAccountName;
            entity.SiteName = dto.SiteName;
            dto.OnEntity(entity);
            return entity;
        }

        public static SearchVoucherTransactionDTO ToDTO(this CTSearchVoucherTRX entity)
        {
            if (entity == null) return null;

            var dto = new SearchVoucherTransactionDTO();
            dto.ReceiptID = entity.RECEIPT_ID;
            dto.ARNumber = entity.AR_NUMBER;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.BeneficiaryNo = entity.BENEFICIARY_NUMBER;
            dto.CustomerName = entity.CUSTOMER_NAME;
            dto.CustomerNo = entity.CUSTOMER_NUMBER;
            dto.ENPaymentMethod = entity.EN_PAYMENT_METHOD;
            dto.IsDisableBeneficiary = entity.IS_DISABLE_BENEFICIARY;
            dto.IsOfflineTransaction = entity.IS_OFFLINE_TRANSACTION;
            dto.PaidAmount = entity.PAID_AMOUNT;
            dto.ProductName = entity.PRODUCT_NAME;
            dto.ProductPrice = entity.PRODUCT_PRICE;
            dto.ProductQuantity = entity.PRODUCT_QUANTITY;
            dto.StationName = entity.STATION_NAME;
            dto.TotalAmount = entity.TOTAL_AMOUNT;
            dto.TransactionType = entity.TRANSACTIONTYPE;
            dto.TransactionDate = entity.TRANSACTION_DATE;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.VATInvoiceNo = entity.VAT_INVOICE_NO;
            dto.VoucherSerialNo = entity.VOUCHER_SERIAL;
            dto.ExternalVoucherNo = entity.EXT_VOUCHER_NO;
            dto.FinancialAccountName = entity.FinancialAccountName;
            dto.SiteName = entity.SiteName;
            entity.OnDTO(dto);
            return dto;
        }


        public static List<SearchVoucherTransactionDTO> ToDTOs(this IEnumerable<CTSearchVoucherTRX> entities)
        {
            return LinqExtension.ToDTO<CTSearchVoucherTRX, SearchVoucherTransactionDTO>(entities, ToDTO);
        }

    }
}
