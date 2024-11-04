using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class DriverCardMapper
    {
        static partial void OnDTO(this CTDriverCard entity, DriverCardDTO dto);

        static partial void OnEntity(this DriverCardSearchDTO dto, CTDriverCardSearch entity);

        public static CTDriverCardSearch ToEntity(this DriverCardSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTDriverCardSearch();

            entity.TOKEN_ID = dto.TokenID;
            entity.CURRENT_TOKEN_ID = dto.CurrentTokenID;
            entity.TOKEN_NAME = dto.TokenName;
            entity.TOKEN_SERIAL = dto.TokenSerial;
            entity.TOKEN_CODE = dto.TokenCode;
            entity.STATUS_ID = dto.StatusID;
            entity.REG_FROM_DATE = dto.RegistrationFromDate == DateTime.MinValue ? null : dto.RegistrationFromDate;
            entity.REG_TO_DATE = dto.RegistrationToDate == DateTime.MinValue ? null : dto.RegistrationToDate;
            entity.CUSTOMER_ID = dto.CustomerID;

            dto.OnEntity(entity);

            return entity;
        }

        public static DriverCardDTO ToDTO(this CTDriverCard entity)
        {
            if (entity == null) return null;

            var dto = new DriverCardDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.TokenName = entity.TOKEN_NAME;
            dto.TokenSerial = entity.TOKEN_SERIAL;
            dto.RegistrationDate = entity.REGISTERATION_DATE;
            dto.TokenCode = entity.TOKEN_CODE;
            dto.Status = entity.TOKEN_STATUS_NAME;
            dto.StatusAr = entity.TOKEN_STATUS_NAME_AR;
            dto.StatusID = entity.TOKEN_STATUS_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<DriverCardDTO> ToDTOs(this IEnumerable<CTDriverCard> entities)
        {
            return LinqExtension.ToDTO<CTDriverCard, DriverCardDTO>(entities, ToDTO);
        }
    }
}
