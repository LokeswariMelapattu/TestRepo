using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class StatusReasonMapper
    {
        
        static partial void OnDTO(this BENEFICIARY_STATUS_REASON entity, StatusReasonDTO dto);

        static partial void OnEntity(this StatusReasonDTO dto, BENEFICIARY_STATUS_REASON entity);

        public static BENEFICIARY_STATUS_REASON ToEntity(this StatusReasonDTO dto)
        {
            if (dto == null) return null;

            var entity = new BENEFICIARY_STATUS_REASON();

            entity.BENEFICIARY_STATUS_REASON_ID = dto.StatusReasonID;
            entity.BENEFICIARY_STATUS_ID = dto.StatusID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.DESCRIPTION = dto.Description;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }
       
        public static StatusReasonDTO ToDTO(this BENEFICIARY_STATUS_REASON entity)
        {
            if (entity == null) return null;

            var dto = new StatusReasonDTO();

            dto.StatusReasonID = entity.BENEFICIARY_STATUS_REASON_ID;
            dto.StatusID = entity.BENEFICIARY_STATUS_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }
               
        public static List<BENEFICIARY_STATUS_REASON> ToEntities(this IEnumerable<StatusReasonDTO> dtos)
        {
            return LinqExtension.ToEntity<BENEFICIARY_STATUS_REASON, StatusReasonDTO>(dtos, ToEntity);
        }

        public static List<StatusReasonDTO> ToDTOs(this IEnumerable<BENEFICIARY_STATUS_REASON> entities)
        {
            return LinqExtension.ToDTO<BENEFICIARY_STATUS_REASON, StatusReasonDTO>(entities, ToDTO);
        }

    }
}




