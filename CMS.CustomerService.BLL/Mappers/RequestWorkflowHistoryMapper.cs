using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using System.ComponentModel;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="ADDRESS"/> and <see cref="AddressDTO"/>.
    /// </summary>
    public static partial class RequestWorkflowHistoryMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
        static partial void OnDTO(this CTRequestWorkflowHistoryDTO entity, RequestWorkflowHistoryDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static RequestWorkflowHistoryDTO ToDTO(this CTRequestWorkflowHistoryDTO entity)
        {
            if (entity == null) return null;

            var dto = new RequestWorkflowHistoryDTO();

        dto.TokenName=entity.TokenName;
        dto.BeneficiaryName =entity.BeneficiaryName;
        dto.CustomerName =entity.CustomerName;
        dto.RequestNumber = entity.RequestNumber;
        dto.RequestType =entity.RequestType;
        dto.RequestSource =entity.RequestSource;
        dto.CurrentRequestStatus = entity.CurrentRequestStatus;        
        dto.RequestType =entity.RequestType;
        dto.RequestSource =entity.RequestSource;
        dto.WorkFlowHistory = new CustomerAppService().GetWorkFlowHistory(entity.REQUEST_ID);
            if (dto.WorkFlowHistory.Count > 0)
                dto.CurrentRequestStatus = dto.WorkFlowHistory[0].Status+" (" +dto.CurrentRequestStatus+")";

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWorkflowHistoryDTO> ToDTOs(this IEnumerable<CTRequestWorkflowHistoryDTO> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestWorkflowHistoryDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
