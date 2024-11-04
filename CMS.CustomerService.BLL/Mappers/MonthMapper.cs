using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    internal static class MonthMapper
    {
        internal static MonthDTO ToDTO (this CTMonth ct)
        {
            return new MonthDTO() 
            {
                EnName = ct.EN_NAME,
                MonthId = ct.MONTH_ID
            };
        }

        internal static List<MonthDTO> ToDTOs(this List<CTMonth> cts)
        {
            var dtos = new List<MonthDTO>();
            foreach (var ct in cts)
                dtos.Add(ct.ToDTO());
            return dtos;
        }
    }
}
