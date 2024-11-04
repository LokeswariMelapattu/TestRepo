using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
 
    public static partial class TimeFrequencyMapper
    {
       
        static partial void OnDTO(this TIME_FREQUENCY  entity, TimeFrequencyDTO  dto);
       
        static partial void OnEntity(this TimeFrequencyDTO  dto, TIME_FREQUENCY  entity);
     
        public static TIME_FREQUENCY  ToEntity(this TimeFrequencyDTO  dto)
        {
            if (dto == null) return null;

            var entity = new TIME_FREQUENCY ();

            entity.TIME_FREQUENCY_ID = dto.TimeFrequencyID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }
       
        public static TimeFrequencyDTO  ToDTO(this TIME_FREQUENCY  entity)
        {
            if (entity == null) return null;

            var dto = new TimeFrequencyDTO ();

            dto.TimeFrequencyID = entity.TIME_FREQUENCY_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<TIME_FREQUENCY > ToEntities(this IEnumerable<TimeFrequencyDTO > dtos)
        {
            return LinqExtension.ToEntity<TIME_FREQUENCY , TimeFrequencyDTO >(dtos, ToEntity);
        }
      
        public static List<TimeFrequencyDTO > ToDTOs(this IEnumerable<TIME_FREQUENCY > entities)
        {
            return LinqExtension.ToDTO<TIME_FREQUENCY , TimeFrequencyDTO >(entities, ToDTO);
        }

    }
}




