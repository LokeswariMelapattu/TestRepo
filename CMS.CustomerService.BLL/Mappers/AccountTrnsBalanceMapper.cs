using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static class AccountTrnsBalanceMapper
    {
        public static PrintReceiptTransDTO ToDTO(this CTAccountTrnsBalance entity)
        {
            if (entity == null) return null;

            var dto = new PrintReceiptTransDTO();
            dto.Amount = entity.AMOUNT;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.BeneficiaryNo = entity.BENEFICIARY_NO;
            dto.CustomerId = entity.CUSTOMER_ID;
            //dto.IsPrintable = entity.IS_PRINTABLE;
            dto.LocationName = entity.LOCATION_NAME;
            dto.PaymentTypeId = entity.PAYMENT_TYPE_ID;
            dto.ServiceOrProdName = entity.SERVICE_OR_PROD_NAME;
            dto.TokenSerial = entity.TOKEN_SERIAL;
            dto.TokenTypeName = entity.TOKEN_TYPE_NAME;
            dto.TransactionDate = entity.TRANSACTION_DATE;
            dto.TransactionType = entity.TRANSACTION_TYPE;
            dto.VatCode = entity.VAT_CODE;
            dto.VatInvoiceNumber = entity.VAT_INVOICE_NUMBER;
            dto.VatPercentage = entity.VAT_PERCENT;
            dto.TransactionId = entity.TRANS_ID;
            dto.VatAmount = entity.VAT_AMOUNT;
            dto.IsPremiumService = entity.ISPREMIUMSERVICETRX.HasValue && entity.ISPREMIUMSERVICETRX.Value == (short)1;
            //dto.ExemptionType = entity.EXEMPTION_TYPE;
            dto.IsSplit = entity.Is_Split;

            return dto;
        }

        public static List<PrintReceiptTransDTO> ToDTOs(this List<CTAccountTrnsBalance> entities)
        {
            var dtos = new List<PrintReceiptTransDTO>();
            foreach (var entity in entities)
                dtos.Add(entity.ToDTO());
            return dtos;
        }

    }
}
