using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

   
    public static partial class CountryMapper
    {
       
        static partial void OnDTO(this COUNTRY entity, CountryDTO dto);
     
        static partial void OnEntity(this CountryDTO dto, COUNTRY entity);

        public static COUNTRY ToEntity(this CountryDTO dto)
        {
            if (dto == null) return null;

            var entity = new COUNTRY();

            entity.COUNTRY_ID = dto.CountryID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }
      
        public static CountryDTO ToDTO(this COUNTRY entity)
        {
            if (entity == null) return null;

            var dto = new CountryDTO();

            dto.CountryID = entity.COUNTRY_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }
            
        public static List<COUNTRY> ToEntities(this IEnumerable<CountryDTO> dtos)
        {
            return LinqExtension.ToEntity<COUNTRY, CountryDTO>(dtos, ToEntity);
        }
               
        public static List<CountryDTO> ToDTOs(this IEnumerable<COUNTRY> entities)
        {
            return LinqExtension.ToDTO<COUNTRY, CountryDTO>(entities, ToDTO);
        }

    }
}


