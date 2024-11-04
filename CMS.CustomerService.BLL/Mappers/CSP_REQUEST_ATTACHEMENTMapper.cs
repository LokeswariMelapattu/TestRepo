using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class CSP_REQUEST_ATTACHEMENTMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
       static partial void OnDTO(this CSP_REQUEST_ATTACHEMENT entity, CSP_REQUEST_ATTACHEMENTDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
       public static CSP_REQUEST_ATTACHEMENTDTO ToDTO(this CSP_REQUEST_ATTACHEMENT entity)
        {
            if (entity == null) return null;

            var dto = new CSP_REQUEST_ATTACHEMENTDTO();
            dto.ATTACHMENT = entity.ATTACHMENT;
            dto.FILE_EXTENSION = entity.FILE_EXTENSION;
            dto.REQUEST_ATTACHMENT_ID = entity.REQUEST_ATTACHMENT_ID;
            dto.REQUEST_DOCUMENT_ID = entity.REQUEST_DOCUMENT_ID;
            dto.REQUEST_ID = entity.REQUEST_ID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
       public static List<CSP_REQUEST_ATTACHEMENTDTO> ToDTOs(this IEnumerable<CSP_REQUEST_ATTACHEMENT> entities)
        {
            return LinqExtension.ToDTO<CSP_REQUEST_ATTACHEMENT, CSP_REQUEST_ATTACHEMENTDTO>(entities, ToDTO);
        }
    }
}
