using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class BatchTokenVehicleMapMapper
    {
        static partial void OnEntity(this BatchTokenVehicleMapDTO dto, CTBatchTokenVehicleMap entity);

        public static CTBatchTokenVehicleMap ToEntity(this BatchTokenVehicleMapDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBatchTokenVehicleMap();

            entity.TokenID = dto.TokenID;
            if (dto.VehicleInfo != null)
            {
                entity.PlateNumber = dto.VehicleInfo.PlateNumber;
                entity.ColorID = dto.VehicleInfo.ColorID;
                entity.StateID = dto.VehicleInfo.StateID;
                entity.ChassisNumber = dto.VehicleInfo.ChassisNumber;
                entity.RegisterID = dto.VehicleInfo.VehicleRegisterID;
                entity.TypeID = dto.VehicleInfo.VehicleTypeID;
                entity.LastUpdatedUser = dto.LastUpdatedUserId;
                entity.LastUpdateDate = dto.LastUpdatedDate;
                entity.LastLocationID = dto.LastUpdatedLocationID;
                entity.PlateColorID = dto.VehicleInfo.PlateColorID;
            }
            //if (dto.WorkOrder != null)
            //{
            //    //entity.WorkOrderNumber = dto.WorkOrder.WorkOrderNumber;
            //    //entity.WorkOrderStatusID = dto.WorkOrder.WorkOrderStatusID;
            //    //entity.WorkOrderStatusReasonID = dto.WorkOrder.WorkOrderStatusReasonID;
            //    //entity.VehicleDepotID = dto.WorkOrder.VehicleDepotID;
            //    //entity.AppointDateTime = dto.WorkOrder.AppointDateTime;
            //    //entity.ServiceDateTime = dto.WorkOrder.ServiceDateTime;
            //    //entity.WorkOrderTypeID = dto.WorkOrder.WorkOrderTypeID;
            //    //entity.RecipientIdNumber = dto.WorkOrder.RecipientIDNumber;
            //    //entity.RecipientTypeID = dto.WorkOrder.RecipientTypeID;
            //    entity.LastUpdatedUser = dto.LastUpdatedUserId;
            //    entity.LastUpdateDate = dto.LastUpdatedDate;
            //    entity.LastLocationID = dto.LastUpdatedLocationID;
            //}
            dto.OnEntity(entity);

            return entity;
        }

        public static List<CTBatchTokenVehicleMap> ToEntities(this IEnumerable<BatchTokenVehicleMapDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBatchTokenVehicleMap, BatchTokenVehicleMapDTO>(dtos, ToEntity);
        }     
    }
}
