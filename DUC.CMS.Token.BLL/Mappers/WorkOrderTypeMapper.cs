using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
   public static partial class WorkOrderTypeMapper
    {
        static partial void OnDTO(this WORK_ORDER_TYPE entity, WorkOrderTypeDTO dto);

        public static WorkOrderTypeDTO ToDTO(this WORK_ORDER_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new WorkOrderTypeDTO();
            dto.AR_NAME = entity.AR_NAME;
            dto.EN_NAME = entity.EN_NAME;
            dto.WorkOrderTypeID = entity.WORK_ORDER_TYPE_ID;
            dto.isActive = entity.IS_ACTIVE;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID =(int?) entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<WorkOrderTypeDTO> ToDTOs(this IEnumerable<WORK_ORDER_TYPE> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER_TYPE, WorkOrderTypeDTO>(entities, ToDTO);
        }
    }
}
