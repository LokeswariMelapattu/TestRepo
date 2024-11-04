using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class PropertyMapper
    {
        static partial void OnDTO(this CTProperty entity, PropertyDTO dto);      

        static partial void OnTTDTO(this TOKEN_TYPE entity, PropertyDTO dto);

        static partial void OnPODTO(this PERSONALIZATION_ORDER_REASON entity, PropertyDTO dto);

        static partial void OnWODTO(this WORK_ORDER_REASON entity, PropertyDTO dto);

        static partial void OnEntity(this PropertyDTO dto, CTProperty entity);

        public static CTProperty ToEntity(this PropertyDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTProperty();
            entity.ID = dto.ID;
            entity.AR_NAME = dto.ArName;
            entity.EN_NAME = dto.EnName;
            dto.OnEntity(entity);
            return entity;
        }

        public static PropertyDTO ToDTO(this CTProperty entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.ID;
            dto.ArName = entity.AR_NAME;
            dto.EnName = entity.EN_NAME;


            entity.OnDTO(dto);

            return dto;
        }     

        public static PropertyDTO ToTTDTO(this TOKEN_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.TOKEN_TYPE_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnTTDTO(dto);

            return dto;
        }

        public static PropertyDTO ToPODTO(this PERSONALIZATION_ORDER_REASON entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.PERSONALIZATION_REASON_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnPODTO(dto);

            return dto;
        }

        public static PropertyDTO ToWODTO(this WORK_ORDER_REASON entity)
        {
            if (entity == null) return null;

            var dto = new PropertyDTO();
            dto.ID = entity.WORK_ORDER_REASON_ID;
            dto.EnName = entity.EN_NAME;
            dto.ArName = entity.AR_NAME;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnWODTO(dto);

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

        public static List<PropertyDTO> ToTTDTOs(this IEnumerable<TOKEN_TYPE> entities)
        {
            return LinqExtension.ToDTO<TOKEN_TYPE, PropertyDTO>(entities, ToTTDTO);
        }

        public static List<PropertyDTO> ToPODTOs(this IEnumerable<PERSONALIZATION_ORDER_REASON> entities)
        {
            return LinqExtension.ToDTO<PERSONALIZATION_ORDER_REASON, PropertyDTO>(entities, ToPODTO);
        }

        public static List<PropertyDTO> ToWODTOs(this IEnumerable<WORK_ORDER_REASON> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER_REASON, PropertyDTO>(entities, ToWODTO);
        }
    }
}
