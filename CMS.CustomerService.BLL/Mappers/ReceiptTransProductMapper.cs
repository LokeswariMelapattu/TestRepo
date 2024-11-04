using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static class ReceiptTransProductMapper
    {
        public static ReceiptTransProductDTO ToDTO(this CTReceiptTransProduct ct)
        {
            return new ReceiptTransProductDTO()
            {
                ProductID = ct.ProductId,
                ProductName = ct.ProductName,
                TransactionAmount = ct.TRANSACTION_AMOUNT,
                UnitPrice = ct.UnitPrice,
                VatAmount = ct.VAT_AMOUNT,
                VatPercentage = ct.VAT_RATE,
                VATCode = ct.VAT_CODE,
                Adjustment = ct.TRANSACTION_ADJUSTMENT,
                ChargedAmount = ct.TRANSACTION_PAID_AMOUNT
            };
        }

        public static List<ReceiptTransProductDTO> ToDTOs(this List<CTReceiptTransProduct> cts)
        {
            var dtos = new List<ReceiptTransProductDTO>();
            foreach (var ct in cts)
                dtos.Add(ct.ToDTO());
            return dtos;
        }
    }
}
