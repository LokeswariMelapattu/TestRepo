using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTRequestWFHistoryWorkOrderINput"/> and <see cref="RequestWFHistoryWorkOrderDTO"/>.
    /// </summary>
    public static partial class RequestWFHistoryWorkOrderMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryWorkOrderDTO"/> converted from <see cref="CTRequestWFHistoryWorkOrderINput"/>.</param>
        static partial void OnDTO(this CTRequestWFHistoryWorkOrderINput entity, RequestWFHistoryWorkOrderDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryWorkOrderINput"/> converted from <see cref="RequestWFHistoryWorkOrderDTO"/>.</param>
        static partial void OnEntity(this RequestWFHistoryWorkOrderDTO dto, CTRequestWFHistoryWorkOrderINput entity);

        /// <summary>
        /// Converts this instance of <see cref="RequestWFHistoryWorkOrderDTO"/> to an instance of <see cref="CTRequestWFHistoryWorkOrderINput"/>.
        /// </summary>
        /// <param name="dto"><see cref="RequestWFHistoryWorkOrderDTO"/> to convert.</param>
        public static CTRequestWFHistoryWorkOrderINput ToEntity(this RequestWFHistoryWorkOrderDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestWFHistoryWorkOrderINput();

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
            entity.RequestID = dto.RequestId;
            entity.RequestWorkOrderID = dto.RequestWorkOrderID;
            entity.ScheduledDate = dto.ScheduledDate;
            entity.ScheduledLocationID = dto.ScheduledLocationID;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.SecondSerial = dto.SecondSerial;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.VehicleInfoID = dto.VehicleInfoID;
            entity.ReasonID = dto.ReasonID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastLocationID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTRequestWFHistoryWorkOrderINput"/> to an instance of <see cref="RequestWFHistoryWorkOrderDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestWFHistoryWorkOrderINput"/> to convert.</param>
        public static RequestWFHistoryWorkOrderDTO ToDTO(this CTRequestWFHistoryWorkOrderINput entity)
        {
            if (entity == null) return null;

            var dto = new RequestWFHistoryWorkOrderDTO();

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
            dto.RequestId = entity.RequestID;
            dto.RequestWorkOrderID = entity.RequestWorkOrderID;
            dto.ScheduledDate = entity.ScheduledDate;
            dto.ScheduledLocationID = entity.ScheduledLocationID;
            dto.TokenCode = entity.TokenCode;
            dto.TokenName = entity.TokenName;
            dto.TokenSerial = entity.TokenSerial;
            dto.SecondSerial = entity.SecondSerial;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.VehicleInfoID = entity.VehicleInfoID;
            dto.ReasonID = entity.ReasonID;
            dto.TokenTypeName = entity.TokenTypeName;
            dto.TokenStatusID = entity.TokenStatusID;
            dto.LastUpdatedLocationID = entity.LastLocationID;
            dto.LastUpdatedUserId = dto.LastUpdatedUserId;
            dto.Request = entity.RequestID == null ? null : new CustomerAppService().GetRequestById((int)entity.RequestID);
            dto.VehicleInfo = entity.VehicleInfoID == null ? null : new DUC.CMS.Token.BLL.TokenAppService().GetVehicleInfoByID((int)entity.VehicleInfoID);
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="RequestWFHistoryWorkOrderDTO"/> to an instance of <see cref="CTRequestWFHistoryWorkOrderINput"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestWFHistoryWorkOrderINput> ToEntities(this IEnumerable<RequestWFHistoryWorkOrderDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTRequestWFHistoryWorkOrderINput>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="CTRequestWFHistoryWorkOrderINput"/> to an instance of <see cref="RequestWFHistoryWorkOrderDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWFHistoryWorkOrderDTO> ToDTOs(this IEnumerable<CTRequestWFHistoryWorkOrderINput> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestWFHistoryWorkOrderDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }


        
    }
}
