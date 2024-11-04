using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class RestrictionStationMapper
    {       
        static partial void OnDTO(this CTRestrictionGroupStations entity, RestrictionStationDTO dto);

        static partial void OnEntity(this RestrictionStationDTO dto, RESTRICTION_GROUP_STATIONS entity);

        public static RESTRICTION_GROUP_STATIONS ToEntity(this RestrictionStationDTO dto)
        {
            if (dto == null) return null;

            var entity = new RESTRICTION_GROUP_STATIONS();

            entity.RESTRICTION_GROUP_ID = dto.RestrictionGroupID;
            entity.STATION_ID = dto.StationID;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;

            dto.OnEntity(entity);

            return entity;
        }
     
        public static RestrictionStationDTO ToDTO(this CTRestrictionGroupStations entity)
        {
            if (entity == null) return null;

            var dto = new RestrictionStationDTO();

            dto.RestrictionGroupID = entity.RESTRICTION_GROUP_ID;
            dto.StationID = entity.STATION_ID;
            dto.StationName = entity.EN_NAME;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.AR_NAME = entity.EN_NAME;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<RESTRICTION_GROUP_STATIONS> ToEntities(this IEnumerable<RestrictionStationDTO> dtos)
        {
            return LinqExtension.ToEntity<RESTRICTION_GROUP_STATIONS, RestrictionStationDTO>(dtos, ToEntity);
        }
      
        public static List<RestrictionStationDTO> ToDTOs(this IEnumerable<CTRestrictionGroupStations> entities)
        {
            return LinqExtension.ToDTO<CTRestrictionGroupStations, RestrictionStationDTO>(entities, ToDTO);
        }
    }
}

