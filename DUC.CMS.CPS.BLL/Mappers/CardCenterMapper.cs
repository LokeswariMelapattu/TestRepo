using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class CardCenterMapper
    {
        static partial void OnDTO(this CARD_CENTER entity, CardCenterDTO dto);

        static partial void OnEntity(this CardCenterDTO dto, CARD_CENTER entity);

        public static CARD_CENTER ToEntity(this CardCenterDTO dto)
        {
            if (dto == null) return null;

            var entity = new CARD_CENTER();

            entity.CARD_CENTER_ID = dto.CardCenterID;
            entity.NAME = dto.EnName;
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);

            dto.OnEntity(entity);

            return entity;
        }

        public static CardCenterDTO ToDTO(this CARD_CENTER entity)
        {
            if (entity == null) return null;

            var dto = new CardCenterDTO();
            dto.CardCenterID = entity.CARD_CENTER_ID;
            dto.EnName = entity.NAME;
            dto.IsActive = Convert.ToBoolean(entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CARD_CENTER> ToEntities(this IEnumerable<CardCenterDTO> dtos)
        {
            return LinqExtension.ToEntity<CARD_CENTER, CardCenterDTO>(dtos, ToEntity);
        }

        public static List<CardCenterDTO> ToDTOs(this IEnumerable<CARD_CENTER> entities)
        {
            return LinqExtension.ToDTO<CARD_CENTER, CardCenterDTO>(entities, ToDTO);
        }

    }
}
