using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
   public static partial class RequestMapper
    {
        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static RequestDTO ToDTO(this CTRequest entity)
        {
            if (entity == null) return null;

            var dto = new RequestDTO();

            dto.BENEFICIARY_ID = entity.BENEFICIARY_ID;
            dto.CUSTOMER_ID= entity.CUSTOMER_ID;
            dto.DATE_TIME = entity.DATE_TIME;
            dto.EN_RequestType = entity.EN_RequestType;
            dto.AR_RequestType = entity.AR_RequestType;
            dto.REMARKS = entity.REMARKS;
            dto.REQUEST_ID = entity.REQUEST_ID;
            dto.REQUEST_STATUS_ID = entity.REQUEST_STATUS_ID;
            dto.REQUEST_TYPE_ID = entity.REQUEST_TYPE_ID;
            dto.REQUESTER_USER_ID = entity.REQUESTER_USER_ID;
            dto.TOKEN_ID = entity.TOKEN_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.IsActive =Convert.ToBoolean( entity.IS_ACTIVE);
            dto.Code = entity.Code;
            dto.LastUpdatedLocationID = entity.LAST_LOCATION_ID;

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestDTO> ToDTOs(this IEnumerable<CTRequest> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this RequestDTO dto, CTRequest entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CTRequest ToEntity(this RequestDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequest();

            entity.AR_RequestType = dto.AR_RequestType;
            entity.BENEFICIARY_ID = dto.BENEFICIARY_ID;
            entity.Code = dto.Code;
            entity.CUSTOMER_ID = dto.CUSTOMER_ID;
            entity.DATE_TIME = dto.DATE_TIME;
            entity.EN_RequestType = dto.EN_RequestType;
            entity.IS_ACTIVE = dto.IsActive ? 0 : 1;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;
            entity.REMARKS = dto.REMARKS;
            entity.REQUEST_ID = dto.REQUEST_ID == null ? -1 : (int)dto.REQUEST_ID;
            entity.REQUEST_STATUS_ID = dto.REQUEST_STATUS_ID;
            entity.REQUEST_TYPE_ID = dto.REQUEST_TYPE_ID;
            entity.REQUESTER_USER_ID = dto.REQUESTER_USER_ID;
            entity.TOKEN_ID = dto.TOKEN_ID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequest> ToEntities(this IEnumerable<RequestDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRequest, RequestDTO>(dtos, ToEntity);
        }

    }
}
