using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial  class RequestAttachmentMapper
    {

       static partial void OnDTO(this CTRequestAttachment entity, RequestAttachmentDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CITY"/> to an instance of <see cref="CityDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CITY"/> to convert.</param>
       public static RequestAttachmentDTO ToDTO(this CTRequestAttachment entity)
        {
            if (entity == null) return null;

            var dto = new RequestAttachmentDTO();
            dto.ATTACHMENT = entity.ATTACHMENT;
            dto.REQUEST_ATTACHMENT_ID = entity.REQUEST_ATTACHMENT_ID;
            dto.REQUEST_DOCUMENT_ID= entity.REQUEST_DOCUMENT_ID;
            dto.REQUEST_ID = entity.REQUEST_ID;
            dto.Request = entity.REQUEST_ID == null ? null : new CustomerAppService().GetRequestById((int)entity.REQUEST_ID);
            entity.OnDTO(dto);


            return dto;
        }


        /// <summary>
        /// Converts each instance of <see cref="CITY"/> to an instance of <see cref="CityDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
       public static List<RequestAttachmentDTO> ToDTOs(this IEnumerable<CTRequestAttachment> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestAttachmentDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
