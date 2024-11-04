using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class TransactionReversalMapper
    {
        internal static TransactionReversalDTO ToDTO(this CTTransactionReversal ct)
        {
            if (ct == null)
                return null;
            return new TransactionReversalDTO
            {
                AuthorizationCode = ct.AUTHORIZATION_CODE,
                BeneficiaryCode = ct.BENEFICIARY_CODE,
                BeneficiaryName = ct.BENEFICIARY_NAME,
                CustomerCode = ct.CUSTOMER_CODE,
                CustomerName = ct.CUSTOMER_NAME,
                IsPayment = ct.IS_PAYMENT.HasValue && ct.IS_PAYMENT.Value == 1,
                ProductName = ct.PRODUCT_NAME,
                ReceiptId = ct.RECEIPT_ID,
                ReversedTransactionDetailId = ct.REVERSED_TRANSACTION_DETAIL_ID,
                ReversedTransactionId = ct.REVERSED_TRANSACTION_ID,
                StationName = ct.STATION_NAME,
                TokenSerial = ct.TOKEN_SERIAL,
                TokenType = ct.TOKEN_TYPE,
                TransactionAmount = ct.TRANSACTION_AMOUNT,
                TransactionDate = ct.TRANSACTION_DATE,
                TransactionDetailId = ct.TRANSACTION_DETAIL_ID,
                TransactionId = ct.TRANSACTION_ID,
                TransactionType = ct.TRANSACTION_TYPE,
                VATAmount = ct.VAT_AMOUNT,
                VatInvoiceNumber = ct.VAT_INVOICE_NO,
                IsPremiumService = ct.IS_PREMIUM_SERVICE.HasValue && ct.IS_PREMIUM_SERVICE.Value == (short)1
            };
        }

        internal static List<TransactionReversalDTO> ToDTOs(this List<CTTransactionReversal> cts)
        {
            var res = new List<TransactionReversalDTO>();
            foreach (var ct in cts)
                res.Add(ct.ToDTO());
            return res;
        }
    }
}
