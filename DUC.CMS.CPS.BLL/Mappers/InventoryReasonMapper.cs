using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class InventoryReasonMapper
    {
        static partial void OnDTO(this CTInventoryReason entity, InventoryReasonDTO dto);

        static partial void OnEntity(this InventoryReasonDTO dto, CTInventoryReason entity);

        public static CTInventoryReason ToEntity(this InventoryReasonDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTInventoryReason();

            entity.STATUS_ID = dto.StatusID;
            entity.EN_Name = dto.EnName;
            entity.Ar_Name = dto.ArName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.STATUS_ID = dto.StatusID;
            entity.Status = dto.Status;

            dto.OnEntity(entity);

            return entity;
        }

        public static InventoryReasonDTO ToDTO(this CTInventoryReason entity)
        {
            if (entity == null) return null;

            var dto = new InventoryReasonDTO();

            dto.StatusID = entity.STATUS_ID;
            dto.EnName = entity.EN_Name;
            dto.ArName = entity.Ar_Name;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.StatusID = entity.STATUS_ID;
            dto.Status = entity.Status;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTInventoryReason> ToEntities(this IEnumerable<InventoryReasonDTO> dtos)
        {
            return LinqExtension.ToEntity<CTInventoryReason, InventoryReasonDTO>(dtos, ToEntity);
        }

        public static List<InventoryReasonDTO> ToDTOs(this IEnumerable<CTInventoryReason> entities)
        {
            return LinqExtension.ToDTO<CTInventoryReason, InventoryReasonDTO>(entities, ToDTO);
        }
    }
}
