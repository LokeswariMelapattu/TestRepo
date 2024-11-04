using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class TokenSegmentMapper
    {
        static partial void OnDTO(this CTTokenSegmentDTO entity, TokenSegmentDTO dto);

        public static TokenSegmentDTO ToDTO(this CTTokenSegmentDTO entity)
        {
            if (entity == null) return null;

            var dto = new TokenSegmentDTO();
            dto.RuleID = entity.RuleID;
            dto.TokenTypeID = entity.TokenTypeID;;
            dto.IsActive = entity.IsActive;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<TokenSegmentDTO> ToDTOs(this IEnumerable<CTTokenSegmentDTO> entities)
        {
            return LinqExtension.ToDTO<CTTokenSegmentDTO, TokenSegmentDTO>(entities, ToDTO);
        }

        static partial void OnEEntity(this TokenSegmentDTO dto, CTTokenSegmentDTO entity);

        public static CTTokenSegmentDTO ToEEntity(this TokenSegmentDTO dto)
        {
            if (dto == null) return null;
            var entity = new CTTokenSegmentDTO();
            entity.RuleID = dto.RuleID;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.IsActive = Convert.ToBoolean(dto.IsActive);

            dto.OnEEntity(entity);

            return entity;
        }

        public static List<CTTokenSegmentDTO> ToEntities(this IEnumerable<TokenSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTokenSegmentDTO, TokenSegmentDTO>(dtos, ToEEntity);

        }
    }
}
