using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PrinterQueueMapper
    {
        static partial void OnDTO(this CTPrinterQueue entity, PrinterQueueDTO dto);

        static partial void OnEntity(this PrinterQueueDTO dto, CTPrinterQueue entity);

        public static CTPrinterQueue ToEntity(this PrinterQueueDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPrinterQueue();

            entity.PRINTER_QUEUE_ID = dto.PrinterQueueID;
            entity.PERSONALIZATION_ORDER_ID = dto.PersonlizationOrderID;
            entity.PersonalizationRequestNumber = dto.PersonalizationRequestNumber;
            entity.ADD_DATE = dto.DateAdded;
            entity.PRINTER_ID = dto.PrinterID;
            entity.PrinterName = dto.PrinterName;
            entity.PERSONALIZATION_ORDER_TYPE = dto.PersonlizationOrderType;
            entity.REMARK = dto.Remarks;
            entity.PRINT_STATUS_ID = dto.PrintStatusID;
            entity.PrintingStatusAr = dto.PrintingStatusAR;
            entity.PrintingStatus = dto.PrintingStatus;
            entity.ENCODER_NAME = dto.EncoderName;
            entity.ROW_NUM = dto.RowNum;

            dto.OnEntity(entity);

            return entity;
        }

        public static PrinterQueueDTO ToDTO(this CTPrinterQueue entity)
        {
            if (entity == null) return null;

            var dto = new PrinterQueueDTO();

            dto.PrinterQueueID = entity.PRINTER_QUEUE_ID;
            dto.PersonlizationOrderID = entity.PERSONALIZATION_ORDER_ID;
            dto.PersonalizationRequestNumber = entity.PersonalizationRequestNumber;
            dto.DateAdded = entity.ADD_DATE;
            dto.PrinterID = entity.PRINTER_ID;
            dto.PrinterName = entity.PrinterName;
            dto.PersonlizationOrderType = entity.PERSONALIZATION_ORDER_TYPE;
            dto.Remarks = entity.REMARK;
            dto.PrintStatusID = entity.PRINT_STATUS_ID;
            dto.PrintingStatusAR = entity.PrintingStatusAr;
            dto.PrintingStatus = entity.PrintingStatus;
            dto.EncoderName = entity.ENCODER_NAME;
            dto.RowNum = entity.ROW_NUM;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPrinterQueue> ToEntities(this IEnumerable<PrinterQueueDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPrinterQueue, PrinterQueueDTO>(dtos, ToEntity);
        }

        public static List<PrinterQueueDTO> ToDTOs(this IEnumerable<CTPrinterQueue> entities)
        {
            return LinqExtension.ToDTO<CTPrinterQueue, PrinterQueueDTO>(entities, ToDTO);
        }
    }
}

