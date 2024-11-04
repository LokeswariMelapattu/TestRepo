using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class WORK_ORDER_STATUSMapper
    {
        static partial void OnDTO(this WORK_ORDER_STATUS entity, WORK_ORDER_STATUSDTO dto);

        public static WORK_ORDER_STATUSDTO ToDTO(this WORK_ORDER_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new WORK_ORDER_STATUSDTO();
            dto.WORK_ORDER_STATUS_ID = entity.WORK_ORDER_STATUS_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.AR_NAME = entity.AR_NAME;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<WORK_ORDER_STATUSDTO> ToDTOs(this IEnumerable<WORK_ORDER_STATUS> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER_STATUS, WORK_ORDER_STATUSDTO>(entities, ToDTO);
        }
    }
}
