using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class WorkOrderMapper
    {
        static partial void OnDTO(this WORK_ORDER entity, WorkOrderDTO dto);

        static partial void OnCDTO(this CTWorkOrder entity, WorkOrderDTO dto);

        static partial void OnEntity(this WorkOrderDTO dto, CTWorkOrder entity);

        public static CTWorkOrder ToEntity(this WorkOrderDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTWorkOrder();

            entity.TOKEN_ID = dto.TokenID;
            entity.WORK_ORDER_ID = dto.WorkOrderID == null ? -1 : dto.WorkOrderID;
            entity.WORK_ORDER_NUMBER = dto.WorkOrderNumber;
            entity.WORK_ORDER_STATUS_ID = dto.WorkOrderStatusID;
            entity.WORK_ORDER_STATUS_REASON_ID = dto.WorkOrderStatusReasonID;
            entity.VEHICLE_INFO_ID = dto.VehicleInfoID;
            entity.VEHICLE_DEPOT_ID = dto.VehicleDepotID;
            entity.APPOINTMENT_DATETIME = dto.AppointDateTime;
            entity.APPOINTMENT_TILL_DATETIME = dto.AppointTillDateTime; 
            entity.SERVICE_DATETIME = dto.ServiceDateTime;
            entity.WORK_ORDER_TYPE_ID = dto.WorkOrderTypeID;
            entity.RECIPIENT_ID_NUMBER = dto.RecipientIDNumber;
            entity.RECIPIENT_TYPE_ID = dto.RecipientTypeID;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LastLocationID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        public static WorkOrderDTO ToDTO(this WORK_ORDER entity)
        {
            if (entity == null) return null;

            var dto = new WorkOrderDTO();

            dto.WorkOrderID = entity.WORK_ORDER_ID;
            dto.WorkOrderNumber = entity.WORK_ORDER_NUMBER;
            dto.WorkOrderStatusID = entity.WORK_ORDER_STATUS_ID;
            dto.WorkOrderStatusReasonID = entity.WORK_ORDER_REASON_ID;
            dto.VehicleInfoID = entity.VEHICLE_INFO_ID;
            dto.VehicleDepotID = entity.VEHICLE_DEPOT_ID;
            dto.AppointDateTime = entity.APPOINTMENT_DATE_TIME;
            dto.AppointTillDateTime = entity.APPOINT_TILL_DATE_TIME; 
            dto.ServiceDateTime = entity.ACTUAL_SERVICE_DATE_TIME;
            dto.WorkOrderTypeID = entity.WORK_ORDER_TYPE_ID;
            dto.RecipientIDNumber = entity.RECIPIENT_ID_NUMBER;
            dto.RecipientTypeID = entity.RECIPIENT_ID_TYPE;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            dto.AppointmentDTO = new AppointmentDTO();
            
           
            entity.OnDTO(dto);

            return dto;
        }

        public static WorkOrderDTO ToCDTO(this CTWorkOrder entity)
        {
            if (entity == null) return null;

            var dto = new WorkOrderDTO();

            dto.TokenID = entity.TOKEN_ID;
            dto.WorkOrderID = entity.WORK_ORDER_ID;
            dto.WorkOrderNumber = entity.WORK_ORDER_NUMBER;
            dto.WorkOrderStatusID = entity.WORK_ORDER_STATUS_ID;
            dto.WorkOrderStatusReasonID = entity.WORK_ORDER_STATUS_REASON_ID;
            dto.VehicleInfoID = entity.VEHICLE_INFO_ID;
            dto.VehicleDepotID = entity.VEHICLE_DEPOT_ID;
            dto.AppointDateTime = entity.APPOINTMENT_DATETIME;
            dto.AppointTillDateTime = entity.APPOINTMENT_TILL_DATETIME; 
            dto.ServiceDateTime = entity.SERVICE_DATETIME;
            dto.WorkOrderTypeID = entity.WORK_ORDER_TYPE_ID;

            entity.OnCDTO(dto);

            return dto;
        }

        public static List<CTWorkOrder> ToEntities(this IEnumerable<WorkOrderDTO> dtos)
        {
            return LinqExtension.ToEntity<CTWorkOrder, WorkOrderDTO>(dtos, ToEntity);
        }

        public static List<WorkOrderDTO> ToDTOs(this IEnumerable<WORK_ORDER> entities)
        {
            return LinqExtension.ToDTO<WORK_ORDER, WorkOrderDTO>(entities, ToDTO);
        }

        public static List<WorkOrderDTO> ToCDTOs(this IEnumerable<CTWorkOrder> entities)
        {
            return LinqExtension.ToDTO<CTWorkOrder, WorkOrderDTO>(entities, ToCDTO);
        }
    }
}













