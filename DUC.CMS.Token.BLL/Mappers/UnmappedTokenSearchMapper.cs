using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class UnmappedTokenSearchMapper
    {
        static partial void OnDTO(this CTUnmappedTokenSearch entity, UnmappedTokenSearchDTO dto);

        static partial void OnEntity(this UnmappedTokenSearchDTO dto, CTUnmappedTokenSearch entity);

        public static CTUnmappedTokenSearch ToEntity(this UnmappedTokenSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTUnmappedTokenSearch();

            entity.TOKEN_ID = dto.TokenID;
            entity.TOKEN_NAME = dto.TokenName;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.BENEFICIARY_NAME = dto.BeneficiaryName;
            entity.EMPLOYEE_ID = dto.EmployeeID;

            dto.OnEntity(entity);

            return entity;
        }

        public static UnmappedTokenSearchDTO ToDTO(this CTUnmappedTokenSearch entity)
        {
            if (entity == null) return null;

            var dto = new UnmappedTokenSearchDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.TokenName = entity.TOKEN_NAME;
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.BeneficiaryName = entity.BENEFICIARY_NAME;
            dto.EmployeeID = entity.EMPLOYEE_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTUnmappedTokenSearch> ToEntities(this IEnumerable<UnmappedTokenSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTUnmappedTokenSearch, UnmappedTokenSearchDTO>(dtos, ToEntity);
        }

        public static List<UnmappedTokenSearchDTO> ToDTOs(this IEnumerable<CTUnmappedTokenSearch> entities)
        {
            return LinqExtension.ToDTO<CTUnmappedTokenSearch, UnmappedTokenSearchDTO>(entities, ToDTO);
        }
    }
}

