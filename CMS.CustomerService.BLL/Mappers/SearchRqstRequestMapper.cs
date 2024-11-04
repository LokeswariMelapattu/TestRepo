using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CONTACT"/> and <see cref="ContactDTO"/>.
    /// </summary>
    public static partial class SearchRqstRequestMapper
    {
        //SearchRQSTRequestResultDTO SearchAgentRequest(SearchRqstRequestDTO
        //CTSearchRQSTRequestResult SearchAgentRequest(CTSearchRequest
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> converted from <see cref="CONTACT"/>.</param>
        static partial void OnDTO(this CTSearchRQSTRequestResult entity, SearchRQSTRequestResultDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this SearchRqstRequestDTO dto, CTSearchRequest entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CTSearchRequest ToEntity(this SearchRqstRequestDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchRequest();

            entity.TokenName = dto.TokenName;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerName = dto.CustomerName;
            entity.RequestTypeID = dto.RequestTypeID;
            entity.RequestStatusId = dto.RequestStatusId;
            entity.RequestDateFrom = dto.RequestDateFrom;
            entity.RequestDateTo = dto.RequestDateTo;
            entity.AssignedToUserID = dto.AssignedToUserID;
            entity.RequestID = dto.RequestID;
            entity.RequestCode = dto.RequestCode;
            entity.CustomerCode = dto.CustomerCode;
            entity.TokenCode = dto.TokenCode;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> to convert.</param>
        public static SearchRQSTRequestResultDTO ToDTO(this CTSearchRQSTRequestResult entity)
        {
            if (entity == null) return null;

            var dto = new SearchRQSTRequestResultDTO
            {
                RequestId = entity.RequestId,
                RequestTypeID = entity.RequestTypeID,
                RequestStatusId = entity.RequestStatusId,
                RequesterUserId = entity.RequesterUserId,
                IsActive = Convert.ToBoolean(entity.IsActive),
                LastUpdatedUserId = entity.LastUpdatedUserId,
                RequestDate = entity.RequestDate,
                LastUpdatedDate = entity.LastUpdatedDate,
                RequestType = entity.RequestType,
                RequestStatus = entity.RequestStatus,
                CustomerName = entity.CustomerName,
                BeneficiaryName = entity.BeneficiaryName,
                TokenName = entity.TokenName,
                Remarks = entity.Remarks,
                RequestCode = entity.RequestCode,
                RequestActionID = entity.RequestActionID,
                RequestAction = entity.RequestAction,
                RequestOriginatorUserName = entity.RequestOriginatorUserName,
                LastUpdatedUserName = entity.LastUpdatedUserName,
                ApproverLevel = entity.ApproverLevel
            };


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTSearchRequest> ToEntities(this IEnumerable<SearchRqstRequestDTO> dtos)
        {
            return LinqExtension.ToEntity<CTSearchRequest, SearchRqstRequestDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SearchRQSTRequestResultDTO> ToDTOs(this IEnumerable<CTSearchRQSTRequestResult> entities)
        {
            return LinqExtension.ToDTO<CTSearchRQSTRequestResult, SearchRQSTRequestResultDTO>(entities, ToDTO);
        }

    }
}
