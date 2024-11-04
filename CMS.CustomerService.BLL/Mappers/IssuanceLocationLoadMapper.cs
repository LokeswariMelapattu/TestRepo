using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class IssuanceLocationLoadMapper
    {
       static partial void OnDto(this CTIssuanceLocationLoad entity, IssuanceLocationLoadDto dto);
       public static IssuanceLocationLoadDto ToDto(this CTIssuanceLocationLoad entity)
       {
           if (entity == null) return null;

           var dto = new IssuanceLocationLoadDto
           {
               Date = entity.Date,
               LoadCount = entity.LoadCount
           };

           entity.OnDto(dto);

           return dto;
       }

       public static List<IssuanceLocationLoadDto> ToDtOs(this IEnumerable<CTIssuanceLocationLoad> entities)
       {
           return LinqExtension.ToDTO<CTIssuanceLocationLoad, IssuanceLocationLoadDto>(entities, ToDto);
       }
    }
}
