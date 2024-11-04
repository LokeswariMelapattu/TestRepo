using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PrintingStatusMapper
    {
        static partial void OnDTO(this CTPrintingStatus entity, PrintingStatusDTO dto);

        static partial void OnEntity(this PrintingStatusDTO dto, CTPrintingStatus entity);

        public static CTPrintingStatus ToEntity(this PrintingStatusDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPrintingStatus();

            entity.PRINTING_STATUS_ID = dto.PrintingStatusID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static PrintingStatusDTO ToDTO(this CTPrintingStatus entity)
        {
            if (entity == null) return null;

            var dto = new PrintingStatusDTO();
            dto.PrintingStatusID = entity.PRINTING_STATUS_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPrintingStatus> ToEntities(this IEnumerable<PrintingStatusDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPrintingStatus, PrintingStatusDTO>(dtos, ToEntity);
        }

        public static List<PrintingStatusDTO> ToDTOs(this IEnumerable<CTPrintingStatus> entities)
        {
            return LinqExtension.ToDTO<CTPrintingStatus, PrintingStatusDTO>(entities, ToDTO);
        }
    }
}
