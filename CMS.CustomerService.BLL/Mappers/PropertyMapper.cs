using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    public static partial class PropertyMapper
    {
        static partial void OnDTO(this CTProperty entity, PropertyDTO dto);
        static partial void OnCDTO(this CTCustomerTypes entity, PropertyDTO dto);

        static partial void OnFDTO(this FAMILY entity, PropertyDTO dto);

        static partial void OnEntity(this PropertyDTO dto, CTProperty entity);

        public static CTProperty ToEntity(this PropertyDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTProperty();
            entity.ID = dto.ID;
            entity.EN_NAME = dto.EnName;
            entity.AR_NAME = dto.ArName;
            dto.OnEntity(entity);
            return entity;
        }

        public static PropertyDTO ToDTO(this CTProperty entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static PropertyDTO ToFDTO(this FAMILY entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.FAMILY_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnFDTO(dto);

            return dto;
        }

        public static PropertyDTO ToCDTO(this CTCustomerTypes entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.CUSTOMER_TYPE_ID;
            dto.EnName = entity.EN_CUSTOMER_TYPE;
            dto.ArName = entity.AR_CUSTOMER_TYPE;

            entity.OnCDTO(dto);

            return dto;
        }
        public static List<CTProperty> ToEntities(this IEnumerable<PropertyDTO> dtos)
        {
            return LinqExtension.ToEntity<CTProperty, PropertyDTO>(dtos, ToEntity);
        }

        public static List<PropertyDTO> ToDTOs(this IEnumerable<CTProperty> entities)
        {
            return LinqExtension.ToDTO<CTProperty, PropertyDTO>(entities, ToDTO);
        }

        public static List<PropertyDTO> ToFDTOs(this IEnumerable<FAMILY> entities)
        {
            return LinqExtension.ToDTO<FAMILY, PropertyDTO>(entities, ToFDTO);
        }
        public static List<PropertyDTO> ToCDTOs(this IEnumerable<CTCustomerTypes> entities)
        {
            return LinqExtension.ToDTO<CTCustomerTypes, PropertyDTO>(entities, ToCDTO);
        }
    }
}
