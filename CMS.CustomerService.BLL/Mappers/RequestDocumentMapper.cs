using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
  public static partial  class RequestDocumentMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
      static partial void OnDTO(this CTRequestDocument entity, RequestDocumentDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
      public static RequestDocumentDTO ToDTO(this CTRequestDocument entity)
        {
            if (entity == null) return null;
            var dto = new RequestDocumentDTO();
            dto.ArName = entity.ArName;
            dto.EnName = entity.EnName;
            dto.IsActive = Convert.ToBoolean(entity.IsActive);
            dto.IsRequired = entity.IsRequired;
            dto.LastUpdatedDate = entity.LastUpdatedDate;
            dto.LastUpdatedUserId =entity.LastUpdatedUserId;
            dto.RequestDocumentId = entity.RequestDocumentId;
            dto.RequestTypeId = entity.RequestTypeId;
            dto.ArDescription = entity.AR_DESCRIPTION;
            dto.EnDescription = entity.EN_DESCRIPTION;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
      public static List<RequestDocumentDTO> ToDTOs(this IEnumerable<CTRequestDocument> entities)
        {
            return LinqExtension.ToDTO<CTRequestDocument, RequestDocumentDTO>(entities, ToDTO);
        }
    }
}
