using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CONTACT"/> and <see cref="ContactDTO"/>.
    /// </summary>
    public static partial class SearchPendingRequestMapper
    {
        //SearchPendingRequestResultDTO SearchAgentRequest(SearchRqstRequestDTO
        //CTSearchPendingRequestResult SearchAgentRequest(CTSearchRequest
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> converted from <see cref="CONTACT"/>.</param>
        static partial void OnDTO(this CTSearchPendingRequestResult entity, SearchPendingRequestResultDTO dto);

        

        /// <summary>
        /// Converts this instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> to convert.</param>
        public static SearchPendingRequestResultDTO ToDTO(this CTSearchPendingRequestResult entity)
        {
            if (entity == null) return null;

            var dto = new SearchPendingRequestResultDTO
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
                WFInstanceId=entity.WF_Instance_Id,
                AssignedTo=entity.AssignedTo ,
                EscalationStatus=entity.EscalationStatus
            };


            entity.OnDTO(dto);

            return dto;
        }

       
        /// <summary>
        /// Converts each instance of <see cref="CONTACT"/> to an instance of <see cref="ContactDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SearchPendingRequestResultDTO> ToDTOs(this IEnumerable<CTSearchPendingRequestResult> entities)
        {
            return LinqExtension.ToDTO<CTSearchPendingRequestResult, SearchPendingRequestResultDTO>(entities, ToDTO);
        }

    }
}
