using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class VoucherTransactionMAPMapper
    {
        static partial void OnDTO(this CTTransactionEXTVoucherMapSA entity, VoucherTransactionMapDTO dto);

        static partial void OnEntity(this VoucherTransactionMapDTO dto, CTTransactionEXTVoucherMapSA entity);

        public static CTTransactionEXTVoucherMapSA ToEntity(this VoucherTransactionMapDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTransactionEXTVoucherMapSA();
            entity.ACTION = dto.Action;
            entity.EXT_VOUCHER_NO = dto.EXTVoucherNo;
            entity.LOCATION_NAME = dto.LocationName;
            entity.OPERATION_DATE = dto.OperationDate;
            entity.RESPONSIBLE_USER = dto.UserName;
            entity.VAT_INVOICE_NO = dto.VATInvoiceNo;
            entity.VOUCHER_SERIAL_NUMBER = dto.VoucherSerialNo;
            dto.OnEntity(entity);
            return entity;
        }

        public static VoucherTransactionMapDTO ToDTO(this CTTransactionEXTVoucherMapSA entity)
        {
            if (entity == null) return null;

            var dto = new VoucherTransactionMapDTO();
            dto.Action = entity.ACTION;
            dto.EXTVoucherNo = entity.EXT_VOUCHER_NO;
            dto.LocationName = entity.LOCATION_NAME;
            dto.OperationDate = entity.OPERATION_DATE;
            dto.UserName = entity.RESPONSIBLE_USER;
            dto.VATInvoiceNo = entity.VAT_INVOICE_NO;
            dto.VoucherSerialNo = entity.VOUCHER_SERIAL_NUMBER;
            entity.OnDTO(dto);
            return dto;
        }


        public static List<VoucherTransactionMapDTO> ToDTOs(this IEnumerable<CTTransactionEXTVoucherMapSA> entities)
        {
            return LinqExtension.ToDTO<CTTransactionEXTVoucherMapSA, VoucherTransactionMapDTO>(entities, ToDTO);
        }

    }
}
