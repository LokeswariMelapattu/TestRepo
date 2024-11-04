using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTRequestWFHistoryAttachment"/> and <see cref="RequestWFHistoryAttachmentDTO"/>.
    /// </summary>
    public static partial class RequestWFHistoryAttachmentMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryAttachmentDTO"/> converted from <see cref="CTRequestWFHistoryAttachment"/>.</param>
        static partial void OnDTO(this CTRequestWFHistoryAttachment entity, RequestWFHistoryAttachmentDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryAttachment"/> converted from <see cref="RequestWFHistoryAttachmentDTO"/>.</param>
        static partial void OnEntity(this RequestWFHistoryAttachmentDTO dto, CTRequestWFHistoryAttachment entity);

        /// <summary>
        /// Converts this instance of <see cref="RequestWFHistoryAttachmentDTO"/> to an instance of <see cref="CTRequestWFHistoryAttachment"/>.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryAttachmentDTO"/> to convert.</param>
        public static CTRequestWFHistoryAttachment ToEntity(this RequestWFHistoryAttachmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestWFHistoryAttachment();

            entity.ATTACHMENT = dto.ATTACHMENT;
            entity.FILE_EXTENSION = dto.FILEEXTENSION;
            entity.Last_Location_ID = dto.LastUpdatedLocationID;
            entity.Last_Updated_User_ID= dto.LastUpdatedUserId;
            entity.Request_Attachment_Id = dto.RequestAttachmentId == null ? -1 : dto.RequestAttachmentId;
            entity.REQUEST_DOCUMENT_ID = dto.RequestDocumentId;
            entity.WF_Instance_ID = dto.WFInstanceID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTRequestWFHistoryAttachment"/> to an instance of <see cref="RequestWFHistoryAttachmentDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryAttachment"/> to convert.</param>
        public static RequestWFHistoryAttachmentDTO ToDTO(this CTRequestWFHistoryAttachment entity)
        {
            if (entity == null) return null;

            var dto = new RequestWFHistoryAttachmentDTO();

            dto.ATTACHMENT = entity.ATTACHMENT;
            dto.FILEEXTENSION = entity.FILE_EXTENSION;
            dto.LastUpdatedLocationID = entity.Last_Location_ID;
            dto.LastUpdatedUserId = entity.Last_Updated_User_ID;
            dto.RequestAttachmentId = entity.Request_Attachment_Id;
            dto.RequestDocumentId = entity.REQUEST_DOCUMENT_ID;
            dto.WFInstanceID = entity.WF_Instance_ID;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="RequestWFHistoryAttachmentDTO"/> to an instance of <see cref="CTRequestWFHistoryAttachment"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestWFHistoryAttachment> ToEntities(this IEnumerable<RequestWFHistoryAttachmentDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTRequestWFHistoryAttachment>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="CTRequestWFHistoryAttachment"/> to an instance of <see cref="RequestWFHistoryAttachmentDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWFHistoryAttachmentDTO> ToDTOs(this IEnumerable<CTRequestWFHistoryAttachment> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestWFHistoryAttachmentDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
