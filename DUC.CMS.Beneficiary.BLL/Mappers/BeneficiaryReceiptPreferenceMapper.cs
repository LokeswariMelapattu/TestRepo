using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{ 

    public static partial class BeneficiaryReceiptPreferenceMapper
    {
        static partial void OnDTO(this CTBeneficiaryReceiptPreference entity, BeneficiaryReceiptPreferenceDTO dto);

        static partial void OnEntity(this BeneficiaryReceiptPreferenceDTO dto, CTBeneficiaryReceiptPreference entity);

        public static CTBeneficiaryReceiptPreference ToEntity(this BeneficiaryReceiptPreferenceDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBeneficiaryReceiptPreference();
            entity.BENEFICIARY_ID = dto.BeneficiaryId ;
            entity.RECEIPT_TYPE_ID = dto.ReceiptTypeId;
          
            dto.OnEntity(entity);
            return entity;
        }

        public static BeneficiaryReceiptPreferenceDTO ToDTO(this CTBeneficiaryReceiptPreference entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiaryReceiptPreferenceDTO();
            dto.BeneficiaryId = entity.BENEFICIARY_ID;
            dto.ReceiptTypeId = entity.RECEIPT_TYPE_ID;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTBeneficiaryReceiptPreference> ToEntities(this IEnumerable<BeneficiaryReceiptPreferenceDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBeneficiaryReceiptPreference, BeneficiaryReceiptPreferenceDTO>(dtos, ToEntity);
        }

        public static List<BeneficiaryReceiptPreferenceDTO> ToDTOs(this IEnumerable<CTBeneficiaryReceiptPreference> entities)
        {
            return LinqExtension.ToDTO<CTBeneficiaryReceiptPreference, BeneficiaryReceiptPreferenceDTO>(entities, ToDTO);
        }
    }
}
