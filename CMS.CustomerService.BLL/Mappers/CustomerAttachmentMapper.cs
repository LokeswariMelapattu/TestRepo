using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CustomerAttachmentMapper 
    {


        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CUSTOMER_ATTACHMENT entity, CustomerAttachmentDTO dto);

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>

       public static CustomerAttachmentDTO ToDTO(this CUSTOMER_ATTACHMENT entity)
        {
            if (entity == null) return null;

            var dto = new CustomerAttachmentDTO();
           
            dto.REQUESTDOCUMENTID = entity.REQUESTDOCUMENTID;
            dto.ATTACHMENT = entity.ATTACHMENT;
            dto.ATTACHMENT_ID = entity.ATTACHMENT_ID;
            //dto.RequestID = entity.r
            dto.FILEEXTENSION = entity.FILEEXTENSION;
            dto.LastUpdatedUserId =Convert.ToInt32( entity.LAST_UPDATED_USER_ID);
            dto.LastUpdatedLocationID =Convert.ToInt32( entity.LAST_LOCATION_ID);
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            entity.OnDTO(dto);

            return dto;
        }

       static partial void OnDTOC(this CTCustomerAttachment entity, CustomerAttachmentDTO dto);
       public static CustomerAttachmentDTO ToDTOC(this CTCustomerAttachment entity)
       {
           if (entity == null) return null;

           var dto = new CustomerAttachmentDTO();

           dto.REQUESTDOCUMENTID = entity.REQUESTDOCUMENTID;
           dto.ATTACHMENT = entity.ATTACHMENT;
           dto.ATTACHMENT_ID = entity.ATTACHMENT_ID;
           //dto.RequestID = entity.r
           dto.FILEEXTENSION = entity.FILEEXTENSION;
           dto.LastUpdatedUserId = Convert.ToInt32(entity.LastUserID);
           dto.LastUpdatedLocationID = Convert.ToInt32(entity.LastLocationID);
           dto.LastUpdatedDate = entity.LastUpdatedDate;
           entity.OnDTOC(dto);

           return dto;
       }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
       public static List<CustomerAttachmentDTO> ToDTOs(this IEnumerable<CUSTOMER_ATTACHMENT> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_ATTACHMENT, CustomerAttachmentDTO>(entities, ToDTO);
        }

       public static List<CustomerAttachmentDTO> ToDTOCs(this IEnumerable<CTCustomerAttachment> entities)
       {
           return LinqExtension.ToDTO<CTCustomerAttachment, CustomerAttachmentDTO>(entities, ToDTOC);
       }


       static partial void OnEntity(this CustomerAttachmentDTO dto, CTCustomerAttachment entity);

       public static CTCustomerAttachment ToEntity(this CustomerAttachmentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerAttachment();
            entity.ATTACHMENT = dto.ATTACHMENT;
            entity.ATTACHMENT_ID = dto.ATTACHMENT_ID == null ? -1 : (int)dto.ATTACHMENT_ID; //(int)dto.ATTACHMENT_ID;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.FILEEXTENSION = dto.FILEEXTENSION;
            entity.REQUESTDOCUMENTID = dto.REQUESTDOCUMENTID;
            entity.LastLocationID = dto.LastUpdatedLocationID;
            //entity.LastUpdateDate = dto.LastUpdatedDate;
            entity.LastUserID = dto.LastUpdatedUserId;

            dto.OnEntity(entity);

            return entity;
        }

       public static List<CTCustomerAttachment> ToEntities(this IEnumerable<CustomerAttachmentDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTCustomerAttachment>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }


       static partial void OnRQSTEntity(this RQSTAttachmentDTO dto, CTRQSTAttachment entity);
       public static CTRQSTAttachment ToRQSTEntity(this RQSTAttachmentDTO dto)
       {
           if (dto == null) return null;

           var entity = new CTRQSTAttachment();
           entity.ATTACHMENT = dto.ATTACHMENT;
           entity.ATTACHMENT_ID = dto.ATTACHMENT_ID == null ? -1 : (int)dto.ATTACHMENT_ID; //(int)dto.ATTACHMENT_ID;
           entity.REQUEST_ID = dto.RequestID;
           entity.FILEEXTENSION = dto.FILEEXTENSION;
           entity.REQUESTDOCUMENTID = dto.REQUESTDOCUMENTID;
           entity.LastLocationID = dto.LastUpdatedLocationID;
           entity.LastUserID = dto.LastUpdatedUserId;

           dto.OnRQSTEntity(entity);

           return entity;
       }

       public static List<CTRQSTAttachment> ToRQSTEntities(this IEnumerable<RQSTAttachmentDTO> dtos)
       {
           if (dtos == null) return null;
           var entities = new List<CTRQSTAttachment>();
           foreach (var dto in dtos)
           {
               entities.Add(dto.ToRQSTEntity());
           }
           return entities;
       }
    }
}
