using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PrinterMapper
    {
        static partial void OnDTO(this PRINTER entity, PrinterDTO dto);

        static partial void OnEntity(this PrinterDTO dto, PRINTER entity);

        public static PRINTER ToEntity(this PrinterDTO dto)
        {
            if (dto == null) return null;

            var entity = new PRINTER();

            entity.PRINTER_ID = dto.PrinterID;
            entity.AR_NAME = dto.PrinterNameAR;
            entity.EN_NAME = dto.PrinterNameEN;
            entity.DESCRIPTION = dto.Description;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.IS_DEFAULT = Convert.ToInt16(dto.IsDefault);
            entity.CARD_CENTER_ID = dto.CardCenterID;
            entity.ENCODER_NAME = dto.EncoderName;

            dto.OnEntity(entity);

            return entity;
        }

        public static PrinterDTO ToDTO(this PRINTER entity)
        {
            if (entity == null) return null;

            var dto = new PrinterDTO();

            dto.PrinterID = entity.PRINTER_ID;
            dto.PrinterNameAR = entity.AR_NAME;
            dto.PrinterNameEN = entity.EN_NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.IsDefault = Convert.ToBoolean(entity.IS_DEFAULT);
            dto.CardCenterID = entity.CARD_CENTER_ID;
            dto.EncoderName = entity.ENCODER_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<PRINTER> ToEntities(this IEnumerable<PrinterDTO> dtos)
        {
            return LinqExtension.ToEntity<PRINTER, PrinterDTO>(dtos, ToEntity);
        }

        public static List<PrinterDTO> ToDTOs(this IEnumerable<PRINTER> entities)
        {
            return LinqExtension.ToDTO<PRINTER, PrinterDTO>(entities, ToDTO);
        }
    }
}

