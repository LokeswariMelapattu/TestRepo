using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class LocationMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="LocationDto"/> converted from <see cref="LOCATION"/>.</param>
        static partial void OnDTO(this CTLocation entity, LocationDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="LOCATION"/> to an instance of <see cref="LocationDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="LOCATION"/> to convert.</param>
        public static LocationDTO ToDTO(this CTLocation entity)
        {
            if (entity == null) return null;

            var dto = new LocationDTO();

            dto.LocationID = entity.LocationID;
            dto.AddressID = entity.AddressID;
            dto.LocationName = entity.LocationName;
            dto.LocationTypeID = entity.LocationTypeID;
            dto.Phone = entity.Phone;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.Fax = entity.Fax;

            entity.OnDTO(dto);

            return dto;
        }


        /// <summary>
        /// Converts each instance of <see cref="LOCATION"/> to an instance of <see cref="LocationDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<LocationDTO> ToDTOs(this IEnumerable<CTLocation> entities)
        {
            if (entities == null) return null;
            var dtos = new List<LocationDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
