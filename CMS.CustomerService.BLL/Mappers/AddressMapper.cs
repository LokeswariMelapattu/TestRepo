using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using System;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="ADDRESS"/> and <see cref="AddressDTO"/>.
    /// </summary>
    public static partial class AddressMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
        static partial void OnDTO(this ADDRESS entity, AddressDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> converted from <see cref="AddressDTO"/>.</param>
        static partial void OnEntity(this AddressDTO dto, ADDRESS entity);

        /// <summary>
        /// Converts this instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> to convert.</param>
        public static ADDRESS ToEntity(this AddressDTO dto)
        {
            if (dto == null) return null;

            var entity = new ADDRESS();

            entity.ADDRESS_ID = dto.AddressId == null ? -1 : (int)dto.AddressId;
            entity.AREA_ID = dto.AreaId;
            entity.CITY_ID = dto.CityId;
            entity.COUNTRY_ID = dto.CountryId;
            entity.POST_CODE = dto.PostCode;
            entity.DETAILED_ADDRESS = dto.DetailedAddress;
            entity.PHONE_NUMBER = dto.PhoneNumber;
            entity.FAX = dto.Fax;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.IS_ACTIVE = (short) (dto.IsActive==true?1:0);          

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static AddressDTO ToDTO(this ADDRESS entity)
        {
            if (entity == null) return null;

            var dto = new AddressDTO();

            dto.AddressId = entity.ADDRESS_ID;
            dto.AreaId = entity.AREA_ID;
            dto.CityId = entity.CITY_ID;
            dto.CountryId = entity.COUNTRY_ID;
            dto.PostCode = entity.POST_CODE;
            dto.DetailedAddress = entity.DETAILED_ADDRESS;
            dto.Area = entity.AREA.ToDTO();
            dto.City = entity.CITY.ToDTO();
            dto.Country = entity.COUNTRY.ToDTO();
            dto.PhoneNumber = entity.PHONE_NUMBER;
            dto.Fax = entity.FAX;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID ;
            dto.LastUpdatedUserId =(int?) entity.LAST_UPDATED_USER_ID;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ADDRESS> ToEntities(this IEnumerable<AddressDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<ADDRESS>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<AddressDTO> ToDTOs(this IEnumerable<ADDRESS> entities)
        {
            if (entities == null) return null;
            var dtos = new List<AddressDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
