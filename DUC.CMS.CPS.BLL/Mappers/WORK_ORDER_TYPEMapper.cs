using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class WORK_ORDER_TYPEMapper
    {
        static partial void OnDTO(this WORK_ORDER_TYPE entity, WORK_ORDER_TYPEDTO dto);

        public static WORK_ORDER_TYPEDTO ToDTO(this WORK_ORDER_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new WORK_ORDER_TYPEDTO();
            dto.WORK_ORDER_TYPE_ID = entity.WORK_ORDER_TYPE_ID;
            dto.EN_NAME = entity.EN_NAME;
            dto.IS_ACTIVE = entity.IS_ACTIVE;
            dto.AR_NAME = entity.AR_NAME;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<WORK_ORDER_TYPEDTO> ToDTOs(this IEnumerable<WORK_ORDER_TYPE> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER_TYPE, WORK_ORDER_TYPEDTO>(entities, ToDTO);
        }
    }
}
