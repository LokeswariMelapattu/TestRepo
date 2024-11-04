using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PersonalizationOrderSearchMapper
    {
        static partial void OnDTO(this CTPersonalizationOrderSearch entity, PersonalizationOrderSearchDTO dto);

        static partial void OnEntity(this PersonalizationOrderSearchDTO dto, CTPersonalizationOrderSearch entity);

        public static CTPersonalizationOrderSearch ToEntity(this PersonalizationOrderSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPersonalizationOrderSearch();

            entity.PersonalizationOrderID = dto.PersonalizationOrderID;
            entity.PersonalizationRequestNumber = dto.PersonalizationRequestNumber;
            entity.AppointmentDate = dto.AppointmentDate;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.PERSONALIZATION_ORDER_TYPE_ID = dto.OrderTypeID;
            entity.OrderTypeName = dto.OrderTypeNameEN;
            entity.OrderTypeNameAR = dto.OrderTypeNameAR;
            entity.PERSONALIZATION_STATUS_ID = dto.OrderStatusID;
            entity.OrderStatusName = dto.OrderStatusNameEN;
            entity.OrderStatusNameAR = dto.OrderStatusNameAR;
            entity.CARD_CENTER_ID = dto.CardCenterID;
            entity.CardCenterName = dto.CardCenterName;
            entity.PRINTING_STATUS_ID = dto.PrintingStatusID;
            entity.PrintingStatus = dto.PrintingStatusEN;
            entity.PrintingStatusAR = dto.PrintingStatusAR;
            entity.SERIAL = dto.CardSerial;
            entity.PrinterName = dto.PrinterName;
            entity.PrintingDate = dto.PrintingDate;
            entity.REMARK = dto.Remarks;

            dto.OnEntity(entity);

            return entity;
        }

        public static PersonalizationOrderSearchDTO ToDTO(this CTPersonalizationOrderSearch entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderSearchDTO();

            dto.PersonalizationOrderID = entity.PersonalizationOrderID; 
            dto.PersonalizationRequestNumber = entity.PersonalizationRequestNumber;
            dto.AppointmentDate = entity.AppointmentDate;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.OrderTypeID = entity.PERSONALIZATION_ORDER_TYPE_ID;
            dto.OrderTypeNameEN = entity.OrderTypeName;
            dto.OrderTypeNameAR = entity.OrderTypeNameAR;
            dto.OrderStatusID = entity.PERSONALIZATION_STATUS_ID;
            dto.OrderStatusNameEN = entity.OrderStatusName;
            dto.OrderStatusNameAR = entity.OrderStatusNameAR;
            dto.CardCenterID = entity.CARD_CENTER_ID;
            dto.CardCenterName = entity.CardCenterName;
            dto.PrintingStatusID = entity.PRINTING_STATUS_ID;
            dto.PrintingStatusEN = entity.PrintingStatus;
            dto.PrintingStatusAR = entity.PrintingStatusAR;
            dto.CardSerial = entity.SERIAL;
            dto.PrinterName = entity.PrinterName;
            dto.PrintingDate = entity.PrintingDate;
            dto.Remarks = entity.REMARK;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPersonalizationOrderSearch> ToEntities(this IEnumerable<PersonalizationOrderSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPersonalizationOrderSearch, PersonalizationOrderSearchDTO>(dtos, ToEntity);
        }

        public static List<PersonalizationOrderSearchDTO> ToDTOs(this IEnumerable<CTPersonalizationOrderSearch> entities)
        {
            return LinqExtension.ToDTO<CTPersonalizationOrderSearch, PersonalizationOrderSearchDTO>(entities, ToDTO);
        }

    }
}
