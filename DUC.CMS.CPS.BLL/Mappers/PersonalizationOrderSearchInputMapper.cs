using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class PersonalizationOrderSearchInputMapper
    {
        static partial void OnDTO(this CTPersonalizationOrderSearchInput entity, PersonalizationOrderSearchInputDTO dto);

        static partial void OnEntity(this PersonalizationOrderSearchInputDTO dto, CTPersonalizationOrderSearchInput entity);

        public static CTPersonalizationOrderSearchInput ToEntity(this PersonalizationOrderSearchInputDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTPersonalizationOrderSearchInput();

            entity.PersonalizationOrderID = dto.PersonalizationOrderID;
            entity.PersonalizationRequestNumber = dto.PersonalizationRequestNumber;
            entity.AppointmentFrom = dto.AppointmentFrom;
            entity.AppointmentTo = dto.AppointmentTo;
            entity.CustomerCode = dto.CustomerCode;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.OrderTypeID = dto.OrderTypeID;
            entity.OrderStatusID = dto.OrderStatusID;
            entity.CardCenterID = dto.CardCenterID;
            entity.PrintingStatusID = dto.PrintingStatusID;
            entity.CardSerial = dto.CardSerial;
            entity.PrintingDateFrom = dto.PrintingDateFrom;
            entity.PrintingDateTo = dto.PrintingDateTo;
            entity.PageNo = dto.PageNo;
            entity.PageSize = dto.PageSize;

            dto.OnEntity(entity);

            return entity;
        }

        public static PersonalizationOrderSearchInputDTO ToDTO(this CTPersonalizationOrderSearchInput entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderSearchInputDTO();

            dto.PersonalizationOrderID = entity.PersonalizationOrderID;
            dto.PersonalizationRequestNumber = entity.PersonalizationRequestNumber;
            dto.AppointmentFrom = entity.AppointmentFrom;
            dto.AppointmentTo = entity.AppointmentTo;
            dto.CustomerCode = entity.CustomerCode;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.OrderTypeID = entity.OrderTypeID;
            dto.OrderStatusID = entity.OrderStatusID;
            dto.CardCenterID = entity.CardCenterID;
            dto.PrintingStatusID = entity.PrintingStatusID;
            dto.CardSerial = entity.CardSerial;
            dto.PrintingDateFrom = entity.PrintingDateFrom;
            dto.PrintingDateTo = entity.PrintingDateTo;
            dto.PageNo = entity.PageSize;
            dto.PageSize = entity.PageSize;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTPersonalizationOrderSearchInput> ToEntities(this IEnumerable<PersonalizationOrderSearchInputDTO> dtos)
        {
            return LinqExtension.ToEntity<CTPersonalizationOrderSearchInput, PersonalizationOrderSearchInputDTO>(dtos, ToEntity);
        }

        public static List<PersonalizationOrderSearchInputDTO> ToDTOs(this IEnumerable<CTPersonalizationOrderSearchInput> entities)
        {
            return LinqExtension.ToDTO<CTPersonalizationOrderSearchInput, PersonalizationOrderSearchInputDTO>(entities, ToDTO);
        }

    }
}
