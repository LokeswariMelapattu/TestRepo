using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="RequestWFHistoryPersonalizationNput"/> and <see cref="RequestWFHistoryPersonalizationDTO"/>.
    /// </summary>
    public static partial class RequestWFHistoryPersonalizationMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryPersonalizationDTO"/> converted from <see cref="RequestWFHistoryPersonalizationNput"/>.</param>
        static partial void OnDTO(this RequestWFHistoryPersonalizationNput entity, RequestWFHistoryPersonalizationDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="RequestWFHistoryPersonalizationNput"/> converted from <see cref="RequestWFHistoryPersonalizationDTO"/>.</param>
        static partial void OnEntity(this RequestWFHistoryPersonalizationDTO dto, RequestWFHistoryPersonalizationNput entity);

        /// <summary>
        /// Converts this instance of <see cref="RequestWFHistoryPersonalizationDTO"/> to an instance of <see cref="RequestWFHistoryPersonalizationNput"/>.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryPersonalizationDTO"/> to convert.</param>
        public static RequestWFHistoryPersonalizationNput ToEntity(this RequestWFHistoryPersonalizationDTO dto)
        {
            if (dto == null) return null;

            var entity = new RequestWFHistoryPersonalizationNput();

            entity.AuthPersonIDNumber = dto.AuthPersonIDNumber;
            entity.AuthPersonIDType = dto.AuthPersonIDType;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CurrentRequestStatus = dto.CurrentRequestStatus;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.ExpiryDate = dto.ExpiryDate;
            entity.PreferredDateFrom = dto.PreferredDateFrom;
            entity.PreferredDateTo = dto.PreferredDateTo;
            entity.PreferredLocationId = dto.PreferredLocationId;
            entity.WFInstanceID = dto.RequestId;
            entity.RequestPersonalizationOrderID = dto.RequestPersonalizationOrderID;
            entity.ScheduledDate = dto.ScheduledDate;
            entity.ScheduledLocationID = dto.ScheduledLocationID;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.ReasonID = dto.ReasonID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastLocationID = dto.LastUpdatedLocationID;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="RequestWFHistoryPersonalizationNput"/> to an instance of <see cref="RequestWFHistoryPersonalizationDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="RequestWFHistoryPersonalizationNput"/> to convert.</param>
        public static RequestWFHistoryPersonalizationDTO ToDTO(this RequestWFHistoryPersonalizationNput entity)
        {
            if (entity == null) return null;

            var dto = new RequestWFHistoryPersonalizationDTO();

            dto.TokenStatusID = entity.TokenStatusID;
            dto.AuthPersonIDNumber = entity.AuthPersonIDNumber;
            dto.AuthPersonIDType = entity.AuthPersonIDType;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.CurrentRequestStatus = entity.CurrentRequestStatus;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.ExpiryDate = entity.ExpiryDate;
            dto.PreferredDateFrom = entity.PreferredDateFrom;
            dto.PreferredDateTo = entity.PreferredDateTo;
            dto.PreferredLocationId = entity.PreferredLocationId;
            dto.RequestId = entity.WFInstanceID;
            dto.RequestPersonalizationOrderID = entity.RequestPersonalizationOrderID;
            dto.ScheduledDate = entity.ScheduledDate;
            dto.ScheduledLocationID = entity.ScheduledLocationID;
            dto.TokenCode = entity.TokenCode;
            dto.TokenName = entity.TokenName;
            dto.TokenSerial = entity.TokenSerial;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.ReasonID = entity.ReasonID;
            dto.TokenTypeName = entity.TokenTypeName;
            dto.TokenStatusID = entity.TokenStatusID;
            dto.LastUpdatedLocationID = entity.LastLocationID;
            dto.LastUpdatedUserId = entity.LastUserID;
           
            dto.Request = entity.WFInstanceID == null ? null : new CustomerAppService().GetRequestById((int)entity.WFInstanceID);
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="RequestWFHistoryPersonalizationDTO"/> to an instance of <see cref="RequestWFHistoryPersonalizationNput"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<RequestWFHistoryPersonalizationNput> ToEntities(this IEnumerable<RequestWFHistoryPersonalizationDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<RequestWFHistoryPersonalizationNput>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="RequestWFHistoryPersonalizationNput"/> to an instance of <see cref="RequestWFHistoryPersonalizationDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWFHistoryPersonalizationDTO> ToDTOs(this IEnumerable<RequestWFHistoryPersonalizationNput> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestWFHistoryPersonalizationDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
