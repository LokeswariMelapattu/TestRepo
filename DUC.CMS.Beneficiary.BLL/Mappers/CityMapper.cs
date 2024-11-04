using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{
    public static partial class CityMapper
    {       
        static partial void OnDTO(this CITY entity, CityDTO dto);

        static partial void OnEntity(this CityDTO dto, CITY entity);

        public static CITY ToEntity(this CityDTO dto)
        {
            if (dto == null) return null;

            var entity = new CITY();

            entity.CITY_ID = dto.CityID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }
      
        public static CityDTO ToDTO(this CITY entity)
        {
            if (entity == null) return null;

            var dto = new CityDTO();

            dto.CityID = entity.CITY_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CITY> ToEntities(this IEnumerable<CityDTO> dtos)
        {
            return LinqExtension.ToEntity<CITY, CityDTO>(dtos, ToEntity);
        }
      
        public static List<CityDTO> ToDTOs(this IEnumerable<CITY> entities)
        {
            return LinqExtension.ToDTO<CITY, CityDTO>(entities, ToDTO);
        }
    }
}

