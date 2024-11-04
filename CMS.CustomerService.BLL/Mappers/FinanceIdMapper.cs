using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    public static partial class FinanceIdMapper
    {
        internal static FinanceIdDTO MapToDto(this CTFinanceId FinanceId)
        {
            if (FinanceId == null) return null;
            return new FinanceIdDTO
            {
                DataID = FinanceId.DATAID,
                ERPNumber = FinanceId.ERPNumber
                
            };
        }
        internal static CTFinanceId MapToEntity(this FinanceIdDTO FinanceIdDTO)
        {
            if (FinanceIdDTO == null) return null;
            return new CTFinanceId
            {
                DATAID = FinanceIdDTO.DataID,

               

            };
        }
        internal static List<FinanceIdDTO> MapToListDto(this List<CTFinanceId> ctFinanceId)
        {
            if (ctFinanceId == null) return null;
            var FinanceIdDto = new List<FinanceIdDTO>();
            foreach (CTFinanceId item in ctFinanceId)
            {
                FinanceIdDto.Add(MapToDto(item));
            }
            return FinanceIdDto;
        }
        internal static List<CTFinanceId> MapToListEntity(this List<FinanceIdDTO> FinanceIdDto)
        {
            if (FinanceIdDto == null) return null;
            var ctFinanceId = new List<CTFinanceId>();
            foreach (FinanceIdDTO item in FinanceIdDto)
            {
                ctFinanceId.Add(MapToEntity(item));
            }
            return ctFinanceId;
        }
    }
}
