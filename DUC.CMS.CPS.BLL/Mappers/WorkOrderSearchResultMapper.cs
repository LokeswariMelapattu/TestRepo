using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class WorkOrderSearchResultMapper
    {

        static partial void OnEntity(this WorkOrderSearchDTO dto, CTWorkOrderSearch entity);

        public static CTWorkOrderSearch ToEntity(this WorkOrderSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTWorkOrderSearch();
            entity.OrderTypeID = dto.OrderTypeID;
            entity.OrderStatusID = dto.OrderStatusID;
            entity.DepotCenterID = dto.DepotCenterID;
            entity.WorkOrderNumber = dto.WorkOrderNumber;
            entity.CustomerCode = dto.CustomerCode;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.TagSerial = dto.TagSerial;
            entity.TagNumber = dto.TagNumber;
            entity.AppointmentFrom = dto.AppointmentFrom;
            entity.AppointmentTo = dto.AppointmentTo;

            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTWorkOrderSearch> ToEntities(this IEnumerable<WorkOrderSearchDTO> dtos)
        {
            return LinqExtension.ToEntity<CTWorkOrderSearch, WorkOrderSearchDTO>(dtos, ToEntity);
        }


        static partial void OnDTO(this CTWorkOrderSearchResult entity, WorkOrderSearchResultDTO dto);

        public static WorkOrderSearchResultDTO ToDTO(this CTWorkOrderSearchResult entity)
        {
            if (entity == null) return null;

            var dto = new WorkOrderSearchResultDTO();
            dto.WORK_ORDER_NUMBER = entity.WORK_ORDER_NUMBER;
            dto.APPOINTMENT_DATE_TIME = entity.APPOINTMENT_DATE_TIME;
            dto.OrderStatusName = entity.OrderStatusName;
            dto.OrderStatusNameAR = entity.OrderStatusNameAR;
            dto.DepotCenterName = entity.DepotCenterName;
            dto.TagSerial = entity.TagSerial;
            dto.TagNumber = entity.TagNumber;
            dto.TagSerialOpt = entity.TagSerialOpt;
            dto.TagNumberOpt = entity.TagNumberOpt;
            dto.tokencode = entity.tokencode;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.BenefiicaryCode = entity.BenefiicaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.OrderTypeName = entity.OrderStatusName;
            dto.OrderTypeNameAR = entity.OrderStatusNameAR;
            dto.tokenname = entity.tokenname;
            dto.WORK_ORDER_TYPE_ID = entity.WORK_ORDER_TYPE_ID;
            dto.WORK_ORDER_STATUS_ID = entity.WORK_ORDER_STATUS_ID;
            dto.DepotCentreID = entity.DepotCentreID;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<WorkOrderSearchResultDTO> ToDTOs(this IEnumerable<CTWorkOrderSearchResult> entities)
        {
            return LinqExtension.ToDTO<CTWorkOrderSearchResult, WorkOrderSearchResultDTO>(entities, ToDTO);
        }
    }
}
