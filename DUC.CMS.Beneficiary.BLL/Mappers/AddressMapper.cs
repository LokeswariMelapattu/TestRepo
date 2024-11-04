using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{
    public static partial class AddressMapper
    {
        static partial void OnDTO(this ADDRESS entity, AddressDTO dto);

        static partial void OnEntity(this AddressDTO dto, ADDRESS entity);

        public static ADDRESS ToEntity(this AddressDTO dto)
        {
            if (dto == null) return null;

            var entity = new ADDRESS();
            entity.ADDRESS_ID = dto.AddressID == null ? -1 : (int)dto.AddressID;
            entity.AREA_ID = dto.AreaID;
            entity.CITY_ID = dto.CityID;
            entity.COUNTRY_ID = dto.CountryID;
            entity.POST_CODE = dto.PostCode;
            entity.DETAILED_ADDRESS = dto.DetailedAddress;
            entity.PHONE_NUMBER = dto.PhoneNumber;
            entity.FAX = dto.Fax;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdateUser;
            entity.LAST_UPDATED_DATE = dto.LastUpdateDate;
            entity.LAST_LOCATION_ID = dto.LocationID;

            dto.OnEntity(entity);
            return entity;
        }

        public static AddressDTO ToDTO(this ADDRESS entity)
        {
            if (entity == null) return null;

            var dto = new AddressDTO();
            dto.AddressID = entity.ADDRESS_ID;
            dto.AreaID = entity.AREA_ID;
            dto._AreaDTO = entity.AREA_ID == null ? null : new Lazy<AreaDTO>(() => new BeneficiaryAppService().GetAreaByID((int)entity.AREA_ID));
            dto.CityID = entity.CITY_ID;
            dto._CityDTO = entity.CITY_ID == null ? null : new Lazy<CityDTO>(() => new BeneficiaryAppService().GetCityByID((int)entity.CITY_ID));
            dto.CountryID = entity.COUNTRY_ID;
            dto._CountryDTO = entity.COUNTRY_ID == null ? null : new Lazy<CountryDTO>(() => new BeneficiaryAppService().GetCountryByID((int)entity.COUNTRY_ID));
            dto.PostCode = entity.POST_CODE;
            dto.DetailedAddress = entity.DETAILED_ADDRESS;
            dto.PhoneNumber = entity.PHONE_NUMBER;
            dto.Fax = entity.FAX;
            dto.LastUpdateDate = entity.LAST_UPDATED_DATE;
            dto.LocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdateUser = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<ADDRESS> ToEntities(this IEnumerable<AddressDTO> dtos)
        {
            return LinqExtension.ToEntity<ADDRESS, AddressDTO>(dtos, ToEntity);
        }

        public static List<AddressDTO> ToDTOs(this IEnumerable<ADDRESS> entities)
        {
            return LinqExtension.ToDTO<ADDRESS, AddressDTO>(entities, ToDTO);
        }
    }
}
