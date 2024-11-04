using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
  
    public static partial class TokenStatusHistoryMapper
    {
       
        static partial void OnDTO(this CTTokenStatusHistory entity, TokenStatusHistoryDTO dto);

        static partial void OnEntity(this TokenStatusHistoryDTO dto, CTTokenStatusHistory entity);

        public static CTTokenStatusHistory ToEntity(this TokenStatusHistoryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTTokenStatusHistory();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.TOKEN_STATUS_ID = dto.StatusID;
            entity.TOKEN_STATUS_NAME = dto.StatusName;
            entity.TOKEN_STATUS_NAME_AR = dto.StatusNameAr;
            entity.TOKEN_STATUS_REASON_ID = dto.StatusReasonID;
            entity.TOKEN_STATUS_REASON_NAME = dto.StatusReasonName;
            entity.token_STATUS_REASON_NAME_AR = dto.StatusReasonNameAr;
            entity.TOKEN_ID = dto.TokenID;
            entity.STATUS_CHANGE_DATE_TIME = dto.DateTime;
            entity.code = dto.TokenCode;
            dto.OnEntity(entity);

            return entity;
        }
       
        public static TokenStatusHistoryDTO ToDTO(this CTTokenStatusHistory entity)
        {
            if (entity == null) return null;

            var dto = new TokenStatusHistoryDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.StatusID = entity.TOKEN_STATUS_ID;
            dto.StatusName = entity.TOKEN_STATUS_NAME;
            dto.StatusNameAr = entity.TOKEN_STATUS_NAME_AR;
            dto.StatusReasonID = entity.TOKEN_STATUS_REASON_ID;
            dto.StatusReasonName = entity.TOKEN_STATUS_REASON_NAME;
            dto.StatusReasonNameAr = entity.token_STATUS_REASON_NAME_AR;
            dto.TokenID = entity.TOKEN_ID;
            dto.TokenCode = entity.code;
            dto.UserName = entity.USER_NAME;
            dto.DateTime = entity.STATUS_CHANGE_DATE_TIME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTTokenStatusHistory> ToEntities(this IEnumerable<TokenStatusHistoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTTokenStatusHistory, TokenStatusHistoryDTO>(dtos, ToEntity);
        }
       
        public static List<TokenStatusHistoryDTO> ToDTOs(this IEnumerable<CTTokenStatusHistory> entities)
        {
            return LinqExtension.ToDTO<CTTokenStatusHistory, TokenStatusHistoryDTO>(entities, ToDTO);
        }

    }
}





