using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static class AccountTrnsTypesMapper
    {
        public static TransactionTypeDTO ToDTO(this CTAccountTrnsTypes entity)
        {
            if (entity == null) return null;

            var dto = new TransactionTypeDTO();
            dto.TransTypeId = entity.ID;
            dto.EnTransName = entity.EN_PAYMENT_TYPE;

            return dto;
        }

        public static List<TransactionTypeDTO> ToDTOs(this List<CTAccountTrnsTypes> entities)
        {
            var dtos = new List<TransactionTypeDTO>();
            foreach (var entity in entities)
                dtos.Add(entity.ToDTO());
            return dtos;
        }
    }
}
