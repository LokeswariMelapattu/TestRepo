using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;

namespace DUC.CMS.Token.BLL.Mappers
{
   public static partial class WorkOrderStatusMapper
    {
        static partial void OnDTO(this WORK_ORDER_STATUS entity, WorkOrderStatusDTO dto);

        public static WorkOrderStatusDTO ToDTO(this WORK_ORDER_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new WorkOrderStatusDTO();
            dto.AR_NAME = entity.AR_NAME;
            dto.EN_NAME = entity.EN_NAME;
            dto.WorkOrderStatusID = entity.WORK_ORDER_STATUS_ID;
            dto.isActive = entity.IS_ACTIVE;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<WorkOrderStatusDTO> ToDTOs(this IEnumerable<WORK_ORDER_STATUS> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER_STATUS, WorkOrderStatusDTO>(entities, ToDTO);
        }
    }
}
