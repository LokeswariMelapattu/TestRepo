using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class CSP_REQUEST_STATUSMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
       static partial void OnDTO(this CSP_REQUEST_STATUS entity, CSP_REQUEST_STATUSDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
       public static CSP_REQUEST_STATUSDTO ToDTO(this CSP_REQUEST_STATUS entity)
        {
            if (entity == null) return null;

            var dto = new CSP_REQUEST_STATUSDTO();

            dto.EN_NAME = entity.EN_NAME;
            dto.AR_NAME = entity.AR_NAME;
            dto.REQUEST_STATUS_ID = entity.REQUEST_STATUS_ID;
            dto.IsActive =Convert.ToBoolean( entity.IS_ACTIVE);

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
       public static List<CSP_REQUEST_STATUSDTO> ToDTOs(this IEnumerable<CSP_REQUEST_STATUS> entities)
        {
            return LinqExtension.ToDTO<CSP_REQUEST_STATUS, CSP_REQUEST_STATUSDTO>(entities, ToDTO);
        }
    }
}
