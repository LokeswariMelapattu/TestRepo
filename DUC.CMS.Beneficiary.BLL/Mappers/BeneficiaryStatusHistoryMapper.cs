using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class BeneficiaryStatusHistoryMapper
    {        
        static partial void OnDTO(this CTBeneficiaryStatusHistory entity, BeneficiaryStatusHistoryDTO dto);
        
        static partial void OnEntity(this BeneficiaryStatusHistoryDTO dto, CTBeneficiaryStatusHistory entity);
             
        public static CTBeneficiaryStatusHistory ToEntity(this BeneficiaryStatusHistoryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBeneficiaryStatusHistory();
            entity.customer_id = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.BENEFICIARY_STATUS_ID = dto.StatusID;
            entity.EN_BENEFICIARY_STATUS = dto.StatusName;
            entity.AR_BENEFICIARY_STATUS = dto.StatusNameAr;
            entity.BENEFICIARY_STATUS_REASON_ID = dto.StatusReasonID;
            entity.BENEFICIARY_STATUS_REASON_NAME = dto.StatusReasonName;
            entity.BENEFICIARY_STATUS_REASON_NAME_ar = dto.StatusReasonNameAr;
            entity.STATUS_CHANGE_DATE=dto.StatusChangeDate;

            dto.OnEntity(entity);

            return entity;
        }

        public static BeneficiaryStatusHistoryDTO ToDTO(this CTBeneficiaryStatusHistory entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiaryStatusHistoryDTO();

            dto.CustomerID = entity.customer_id;
            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.StatusID = entity.BENEFICIARY_STATUS_ID;
            dto.StatusName = entity.EN_BENEFICIARY_STATUS;
            dto.StatusNameAr = entity.AR_BENEFICIARY_STATUS;
            dto.StatusReasonID = entity.BENEFICIARY_STATUS_REASON_ID;
            dto.StatusReasonName = entity.BENEFICIARY_STATUS_REASON_NAME;
            dto.StatusReasonNameAr = entity.BENEFICIARY_STATUS_REASON_NAME_ar;
            dto.StatusChangeDate = entity.STATUS_CHANGE_DATE;
            dto.BeneficiaryCode = entity.CODE;
            dto.UserName = entity.USER_NAME;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTBeneficiaryStatusHistory> ToEntities(this IEnumerable<BeneficiaryStatusHistoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBeneficiaryStatusHistory, BeneficiaryStatusHistoryDTO>(dtos, ToEntity);
        }

        public static List<BeneficiaryStatusHistoryDTO> ToDTOs(this IEnumerable<CTBeneficiaryStatusHistory> entities)
        {
            return LinqExtension.ToDTO<CTBeneficiaryStatusHistory, BeneficiaryStatusHistoryDTO>(entities, ToDTO);
        }

    }
}
