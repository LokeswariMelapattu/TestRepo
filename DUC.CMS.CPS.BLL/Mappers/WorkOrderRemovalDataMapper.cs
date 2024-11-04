using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class WorkOrderRemovalDataMapper
    {
        static partial void OnEntity(this WorkOrderRemovalDataDTO dto, CTWorkOrderRemovalData entity);

        public static CTWorkOrderRemovalData ToEntity(this WorkOrderRemovalDataDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTWorkOrderRemovalData();

            entity.Token_ID = dto.Token_ID;
            entity.DepotCentreID = dto.DepotCentreID;
            entity.WORK_ORDER_ID = dto.WORK_ORDER_ID;
            entity.WORK_ORDER_TYPE_ID = dto.WORK_ORDER_TYPE_ID;
            entity.Reason = dto.Reason;
            entity.ISTOKENPROFILETERMINATE = dto.ISTOKENPROFILETERMINATE;
            entity.USER_ID = dto.USER_ID;
            entity.Tag_Serial = dto.Tag_Serial;
            entity.Tag_Number = dto.Tag_Number;
            entity.Tag_Serial_Opt = dto.Tag_Serial_Opt;
            entity.Tag_Number_Opt = dto.Tag_Number_Opt;
            entity.Remarks = dto.Remarks;

            dto.OnEntity(entity);

            return entity;
        }


        public static List<CTWorkOrderRemovalData> ToEntities(this IEnumerable<WorkOrderRemovalDataDTO> dtos)
        {
            return LinqExtension.ToEntity<CTWorkOrderRemovalData, WorkOrderRemovalDataDTO>(dtos, ToEntity);
        }
    }
}
