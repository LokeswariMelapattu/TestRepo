using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static class PrintReceiptDetailsMapper
    {
        public static ReceiptDetailsDTO ToDTO(this CTReceiptDetails entity)
        {
            if (entity == null) return null;

            var dto = new ReceiptDetailsDTO();
            dto.Amount = entity.AMOUNT;
            dto.Name = entity.NAME;
            dto.VatCode = entity.VAT_CODE;
            dto.VatInvoiceNumber = entity.VAT_INVOICE_NUMBER;
            dto.VatRate = entity.VAT_RATE;
            dto.VatAmount = entity.VAT_AMOUNT;

            return dto;
        }

        public static List<ReceiptDetailsDTO> ToDTOs(this List<CTReceiptDetails> entities)
        {
            var dtos = new List<ReceiptDetailsDTO>();
            foreach (var entity in entities)
                dtos.Add(entity.ToDTO());
            return dtos;
        }
    }
}
