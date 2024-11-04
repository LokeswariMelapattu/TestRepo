using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
   public static partial class PersonalizationOrderStatusMapper
    {
       static partial void OnDTO(this PERSONALIZATION_ORDER_STATUS entity, PersonalizationOrderStatusDTO dto);

       public static PersonalizationOrderStatusDTO ToDTO(this PERSONALIZATION_ORDER_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new PersonalizationOrderStatusDTO();
            dto.AR_NAME = entity.AR_NAME;
            dto.EN_NAME = entity.EN_NAME;
            dto.PersonalizationOrderStatusID = entity.PERSONALIZATION_STATUS_ID;
            dto.isActive = entity.IS_ACTIVE;
            entity.OnDTO(dto);

            return dto;
        }

       public static List<PersonalizationOrderStatusDTO> ToDTOs(this IEnumerable<PERSONALIZATION_ORDER_STATUS> entities)
        {
            return LinqExtension.ToDTO<PERSONALIZATION_ORDER_STATUS, PersonalizationOrderStatusDTO>(entities, ToDTO);
        }
    }
}
