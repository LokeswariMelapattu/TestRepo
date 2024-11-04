using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{

    public static partial class SMSMapper
    {
       
        static partial void OnDTO(this SMS_MESSAGE entity, SMSDTO dto);

        static partial void OnEntity(this SMSDTO dto, SMS_MESSAGE entity);

        public static SMS_MESSAGE ToEntity(this SMSDTO dto)
        {
            if (dto == null) return null;

            var entity = new SMS_MESSAGE();

            entity. CUSTOMER_ID = dto.CustomerID;
            entity.BENEFICIARY_ID = dto.BeneficiaryID;
            entity.MOBILE_NUMBER = dto.Mobile;
            entity.MESSAGE_BODY = dto.Message;
            
            dto.OnEntity(entity);

            return entity;
        }
      
        public static SMSDTO ToDTO(this SMS_MESSAGE entity)
        {
            if (entity == null) return null;

            var dto = new SMSDTO();

            dto.CustomerID = (int)entity.CUSTOMER_ID;
            dto.BeneficiaryID = (int)entity.BENEFICIARY_ID;
            dto.Mobile = entity.MOBILE_NUMBER;
            dto.Message = entity.MESSAGE_BODY;

            entity.OnDTO(dto);

            return dto;
        }
            
        public static List<SMS_MESSAGE> ToEntities(this IEnumerable<SMSDTO> dtos)
        {
            return LinqExtension.ToEntity<SMS_MESSAGE, SMSDTO>(dtos, ToEntity);
        }
      
        public static List<SMSDTO> ToDTOs(this IEnumerable<SMS_MESSAGE> entities)
        {
            return LinqExtension.ToDTO<SMS_MESSAGE, SMSDTO>(entities, ToDTO);
        }

    }
}



