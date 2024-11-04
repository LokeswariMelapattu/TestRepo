using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial  class RequestCustomerAddressMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
       static partial void OnDTO(this CTRequestCustomerAddress entity, RequestCustomerAddressDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
       public static RequestCustomerAddressDTO ToDTO(this CTRequestCustomerAddress entity)
        {
            if (entity == null) return null;

            var dto = new RequestCustomerAddressDTO();

            dto.ADDRESS_ID = entity.ADDRESS_ID;
            dto.POST_CODE = entity.POST_CODE;
            dto.DETAILED_ADDRESS = entity.DETAILED_ADDRESS;

            dto.enAreaName = entity.ENAreaName;
            dto.enCityName = entity.ENCityName;
            dto.enCountryName = entity.ENCountryName;

            dto.arAreaName = entity.ARAreaName;
            dto.arCityName = entity.ARCityName;
            dto.arCountryName = entity.ARCountryName;

            dto.AreaID = entity.area_id;
            dto.CityID = entity.City_id;
            dto.CountryID = entity.Country_id;

            dto.PHONE_NUMBER = entity.PHONE_NUMBER;
            dto.FAX = entity.FAX;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
       public static List<RequestCustomerAddressDTO> ToDTOs(this IEnumerable<CTRequestCustomerAddress> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestCustomerAddressDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

       static partial void OnEEntity(this RequestCustomerAddressDTO dto, RQST_REQUEST_CUSTOMER_ADDRESS entity);

       public static RQST_REQUEST_CUSTOMER_ADDRESS ToEEntity(this RequestCustomerAddressDTO dto)
       {
           if (dto == null) return null;
           var entity = new RQST_REQUEST_CUSTOMER_ADDRESS();
           entity.AREA_ID = dto.AreaID;
           entity.CITY_ID=dto.CityID;
           entity.COUNTRY_ID=dto.CountryID;
           entity.DETAILED_ADDRESS = dto.DETAILED_ADDRESS;
           entity.FAX = dto.FAX;
           entity.IS_ACTIVE=(short?)(dto.IsActive ? 1:1) ;
           entity.LAST_LOCATION_ID =dto.LastUpdatedLocationID ;
          // entity.LAST_UPDATED_DATE =dto.LastUpdatedDate ;
           entity.LAST_UPDATED_USER_ID=dto.LastUpdatedUserId;
           entity.PHONE_NUMBER=dto.PHONE_NUMBER;
           entity.POST_CODE= dto.POST_CODE;
           entity.REQUEST_ADDRESS_ID=dto.ADDRESS_ID==null?-1 :(int)dto.ADDRESS_ID;


           dto.OnEEntity(entity);

           return entity;
       }

       public static List<RQST_REQUEST_CUSTOMER_ADDRESS> ToEntities(this IEnumerable<RequestCustomerAddressDTO> dtos)
       {
           return LinqExtension.ToEntity<RQST_REQUEST_CUSTOMER_ADDRESS, RequestCustomerAddressDTO>(dtos, ToEEntity);

       }

    }
}
