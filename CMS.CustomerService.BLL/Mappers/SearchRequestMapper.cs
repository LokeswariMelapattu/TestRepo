using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class SearchRequestMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTSearchRequestResult entity, SearchRequestResultDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static SearchRequestResultDTO ToDTO(this CTSearchRequestResult entity)
        {
            if (entity == null) return null;

            var dto = new SearchRequestResultDTO();

            dto.RequestId = entity.RequestId;
            dto.RequestTypeID = entity.RequestTypeID;
            dto.RequestStatusId = entity.RequestStatusId;
            dto.RequesterUserId = entity.RequesterUserId;
            dto.RequestDate = entity.RequestDate ;
            dto.RequestType = entity.RequestType;
            dto.RequestStatus = entity.RequestStatus;
            dto.CustomerName = entity.CustomerName;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.TokenName = entity.TokenName;
            dto.Remarks = entity.Remarks;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SearchRequestResultDTO> ToDTOs(this IEnumerable<CTSearchRequestResult> entities)
        {
            return LinqExtension.ToDTO<CTSearchRequestResult, SearchRequestResultDTO>(entities, ToDTO);
        }

        //
        static partial void OnEntity(this SearchRequestDTO dto, CTSearchRequest entity);

        public static CTSearchRequest ToEntity(this SearchRequestDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchRequest();


            entity.TokenName = dto.TokenName;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerName = dto.CustomerName;
            entity.RequestTypeID = dto.RequestTypeID;
            entity.RequestStatusId = dto.RequestStatusId;
            entity.RequestDateFrom = dto.RequestDateFrom == System.DateTime.MinValue ? null : dto.RequestDateFrom;
            entity.RequestDateTo = dto.RequestDateTo == System.DateTime.MinValue ? null : dto.RequestDateTo;
            entity.AssignedToUserID = dto.UserID;

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTSearchRequest> ToEntities(this IEnumerable<SearchRequestDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTSearchRequest>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }
    }
}
