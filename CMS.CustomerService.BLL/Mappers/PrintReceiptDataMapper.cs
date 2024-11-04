using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static class PrintReceiptDataMapper
    {
        public static PrintReceiptDataDTO ToDTO(this CTPrintReceiptData entity)
        {
            if (entity == null) return null;

            var dto = new PrintReceiptDataDTO();
            dto.AdnocTransNo = entity.ADNOC_TRN_NO;
            dto.CustomerName = entity.CUSTOMER_NAME;
            dto.CustomerNo = entity.CUSTOMER_NO;
            dto.TransDateTime = entity.TRANS_DATE_TIME;
            dto.LocationName = entity.LOCATION_NAME;
            dto.Remarks = entity.REMARKS;
            dto.Address = entity.V_ADDRESS;
            dto.CustomerTRN = entity.TRN;

            return dto;
        }
    }
}
