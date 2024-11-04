using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{
    public static partial class StatusMapper
    {
        
        static partial void OnDTO(this BENEFICIARY_STATUS entity, StatusDTO dto);

        static partial void OnEntity(this StatusDTO dto, BENEFICIARY_STATUS entity);

        public static BENEFICIARY_STATUS ToEntity(this StatusDTO dto)
        {
            if (dto == null) return null;

            var entity = new BENEFICIARY_STATUS();

            entity.BENEFICIARY_STATUS_ID = dto.StatusID;
            entity.AR_BENEFICIARY_STATUS = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.EN_BENEFICIARY_STATUS = dto.EnName;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdateUser;
            entity.LAST_UPDATED_DATE = dto.LastUpdateDate;
            entity.LAST_LOCATION_ID = dto.LocationID;
            dto.OnEntity(entity);

            return entity;
        }

        public static StatusDTO ToDTO(this BENEFICIARY_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new StatusDTO();

            dto.StatusID = entity.BENEFICIARY_STATUS_ID;
            dto.ArName = entity.AR_BENEFICIARY_STATUS;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.EnName = entity.EN_BENEFICIARY_STATUS;
            dto.LastUpdateDate = entity.LAST_UPDATED_DATE;
            dto.LocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdateUser = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<BENEFICIARY_STATUS> ToEntities(this IEnumerable<StatusDTO> dtos)
        {
            return LinqExtension.ToEntity<BENEFICIARY_STATUS, StatusDTO>(dtos, ToEntity);
        }
              
        public static List<StatusDTO> ToDTOs(this IEnumerable<BENEFICIARY_STATUS> entities)
        {
            return LinqExtension.ToDTO<BENEFICIARY_STATUS, StatusDTO>(entities, ToDTO);
        }

    }
}
