using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTWorkFlowHistory"/> and <see cref="WorkFlowHistoryDTO"/>.
    /// </summary>
    public static partial class WorkFlowHistoryMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="WorkFlowHistoryDTO"/> converted from <see cref="CTWorkFlowHistory"/>.</param>
        static partial void OnDTO(this CTWorkFlowHistory entity, WorkFlowHistoryDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTWorkFlowHistory"/> converted from <see cref="WorkFlowHistoryDTO"/>.</param>
        static partial void OnEntity(this WorkFlowHistoryDTO dto, CTWorkFlowHistory entity);

        /// <summary>
        /// Converts this instance of <see cref="WorkFlowHistoryDTO"/> to an instance of <see cref="CTWorkFlowHistory"/>.
        /// </summary>
        /// <param name="dto"><see cref="WorkFlowHistoryDTO"/> to convert.</param>
        public static CTWorkFlowHistory ToEntity(this WorkFlowHistoryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTWorkFlowHistory();

            entity.Action = dto.Action;
            entity.AssignedTo = dto.AssignedTo;
            entity.Remarks = dto.Remarks;
            entity.RequestDate = dto.RequestDate;
            entity.Status = dto.Status;
            entity.User = dto.User;
            entity.WFInstanceID = dto.WFInstanceID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTWorkFlowHistory"/> to an instance of <see cref="WorkFlowHistoryDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTWorkFlowHistory"/> to convert.</param>
        public static WorkFlowHistoryDTO ToDTO(this CTWorkFlowHistory entity)
        {
            if (entity == null) return null;

            var dto = new WorkFlowHistoryDTO();

            dto.Action = entity.Action;
            dto.AssignedTo = entity.AssignedTo;
            dto.Remarks = entity.Remarks;
            dto.RequestDate = entity.RequestDate;
            dto.Status = entity.Status;
            dto.User = entity.User;
            dto.WFInstanceID = entity.WFInstanceID;
            dto.HasHistoryData = entity.HasHistoryData==null?false : true;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="WorkFlowHistoryDTO"/> to an instance of <see cref="CTWorkFlowHistory"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTWorkFlowHistory> ToEntities(this IEnumerable<WorkFlowHistoryDTO> dtos)
        {
            return LinqExtension.ToEntity<CTWorkFlowHistory, WorkFlowHistoryDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTWorkFlowHistory"/> to an instance of <see cref="WorkFlowHistoryDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<WorkFlowHistoryDTO> ToDTOs(this IEnumerable<CTWorkFlowHistory> entities)
        {
            return LinqExtension.ToDTO<CTWorkFlowHistory, WorkFlowHistoryDTO>(entities, ToDTO);
        }

    }
}
