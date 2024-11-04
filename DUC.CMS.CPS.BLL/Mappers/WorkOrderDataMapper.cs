using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
   public static partial class WorkOrderDataMapper
    {

       static partial void OnEntity(this WorkOrderDataDTO dto, CTWorkOrderData entity);

       public static CTWorkOrderData ToEntity(this WorkOrderDataDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTWorkOrderData();

           entity.Tag_Serial =dto.Tag_Serial;
        entity.TagNumber =dto.TagNumber;
        entity.TagSerialOpt = dto.TagSerialOpt;
        entity.TagNumberOpt = dto.TagNumberOpt;
        entity.Token_ID = dto.Token_ID;
        entity.WORK_ORDER_ID = dto.WORK_ORDER_ID;
        entity.DepotCentreID = dto.DepotCentreID;
        entity.NUMBER_OF_ACTIVE_TAGS = dto.NUMBER_OF_ACTIVE_TAGS;
        entity.USER_ID = dto.USER_ID;

            dto.OnEntity(entity);

            return entity;
        }

       public static List<CTWorkOrderData> ToEntities(this IEnumerable<WorkOrderDataDTO> dtos)
        {
            return LinqExtension.ToEntity<CTWorkOrderData, WorkOrderDataDTO>(dtos, ToEntity);
        }
    }
}
