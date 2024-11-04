using DUC.CMS.Token.BLL.DTO;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class AccountMapSearchMapper
    {
        static partial void OnEntity(this AccountMapSearchDTO dto, CTMapSearch entity);

        public static CTMapSearch ToEntity(this AccountMapSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTMapSearch();

            entity.CustomerID = dto.CustomerID;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.UserID = dto.UserID;

            dto.OnEntity(entity);

            return entity;
        }
    }
}
