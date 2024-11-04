using DUC.CMS.Token.BLL.DTO;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class MapSearchMapper
    {
        static partial void OnEntity(this MapSearchDTO dto, CTMapSearch entity);

        public static CTMapSearch ToEntity(this MapSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTMapSearch();

            entity.RecordCount = dto.RecordCount;
            entity.CustomerID = dto.CustomerID;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;

            dto.OnEntity(entity);

            return entity;
        }
    }
}