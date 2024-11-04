using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CeilingLimitMappers
    {
        static partial void OnDTO(this CEILING_LIMIT entity, CeilingLimitDTO dto);

        public static CeilingLimitDTO ToDTO(this CEILING_LIMIT entity)
        {
            if (entity == null) return null;

            var dto = new CeilingLimitDTO();

            dto.CeilingLimitID = entity.CEILING_LIMIT_ID;
            dto.Limit = entity.LIMIT;

            entity.OnDTO(dto);

            return dto;
        }
    }
}
