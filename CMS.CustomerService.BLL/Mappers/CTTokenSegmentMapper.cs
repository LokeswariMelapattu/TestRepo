using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTTokenSegmentMapper
    {
        static partial void OnEntity(this TokenSegmentDTO dto, CTTokenSegmentDTO entity);

        public static CTTokenSegmentDTO ToEntity(this TokenSegmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTokenSegmentDTO();

            entity.RuleID = dto.RuleID;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.IsActive = dto.IsActive;

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTTokenSegmentDTO> ToEntities(this IEnumerable<TokenSegmentDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTokenSegmentDTO, TokenSegmentDTO>(dtos, ToEntity);

        }
    }
}
