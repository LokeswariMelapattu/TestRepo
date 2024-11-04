using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class RequestWorkOrderMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTRequestWorkOrder entity, RequestWorkOrderDTO dto);


        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static RequestWorkOrderDTO ToDTO(this CTRequestWorkOrder entity)
        {
            if (entity == null) return null;

            var dto = new RequestWorkOrderDTO();

            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.AuthPersonIDNumber = entity.AuthPersonIDNumber;
            dto.AuthPersonIDType = entity.AuthPersonIDType;
            dto.BeneficiaryCode = entity.BeneficiaryCode;
            dto.BeneficiaryName = entity.BeneficiaryName;
            dto.TokenTypeName = entity.TokenType;
            dto.PreferredDateFrom = entity.PreferredDateFrom;
            dto.PreferredLocationId = entity.PreferredLocationId;
            dto.RequestId = entity.RequestId;
            dto.TokenCode = entity.TokenCode;
            dto.TokenName = entity.TokenName;
            dto.TokenTypeID = entity.TokenTypeID;
            dto.VehicleInfoID = entity.VehicleInfoID;
            dto.Request = entity.RequestId == null ? null : new CustomerAppService().GetRequestById((int)entity.RequestId);
            dto.VehicleInfo = entity.VehicleInfoID == null ? null : new DUC.CMS.Token.BLL.TokenAppService().GetVehicleInfoByID((int)entity.VehicleInfoID);
            dto.PreferredDateTo = entity.PreferredDateTo;
            dto.RequestWorkOrderID = entity.RequestWorkOrderID;
            dto.TokenSerial = entity.TokenSerial;
            dto.SecondSerial = entity.SecondSerial;
            dto.ExpiryDate = entity.ExpiryDate;
            dto.ScheduledDate = entity.ScheduledDate;
            dto.ScheduledLocationID = entity.ScheduledLocationID;
            dto.ReasonID = entity.ReasonID;
            dto.TokenStatusID = entity.TokenStatusID;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestWorkOrderDTO> ToDTOs(this IEnumerable<CTRequestWorkOrder> entities)
        {
            return LinqExtension.ToDTO<CTRequestWorkOrder, RequestWorkOrderDTO>(entities, ToDTO);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CONTACT"/> converted from <see cref="ContactDTO"/>.</param>
        static partial void OnEntity(this RequestWorkOrderDTO dto, CTRequestWorkOrder entity);

        /// <summary>
        /// Converts this instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dto"><see cref="ContactDTO"/> to convert.</param>
        public static CTRequestWorkOrder ToEntity(this RequestWorkOrderDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestWorkOrder();
            entity.AuthPersonIDNumber = dto.AuthPersonIDNumber;
            entity.AuthPersonIDType = dto.AuthPersonIDType;
            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.CustomerCode = dto.CustomerCode;
            entity.CustomerName = dto.CustomerName;
            entity.ExpiryDate = dto.ExpiryDate;
            entity.IsActive = dto.IsActive ? 0 : 1;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.PreferredDateFrom = dto.PreferredDateFrom;
            entity.PreferredDateTo = dto.PreferredDateTo;
            entity.PreferredLocationId = dto.PreferredLocationId;
            entity.RequestId = dto.RequestId;
            entity.RequestWorkOrderID = dto.RequestWorkOrderID == null ? -1 : (int)dto.RequestWorkOrderID; 
            entity.ScheduledDate = dto.ScheduledDate;
            entity.ScheduledLocationID = dto.ScheduledLocationID;
            entity.TokenCode = dto.TokenCode;
            entity.TokenName = dto.TokenName;
            entity.TokenSerial = dto.TokenSerial;
            entity.SecondSerial = dto.SecondSerial;
            entity.TokenType = dto.TokenTypeName;
            entity.TokenTypeID = dto.TokenTypeID;
            entity.ReasonID = dto.ReasonID;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.LastLocationID = dto.LastUpdatedLocationID;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts each instance of <see cref="ContactDTO"/> to an instance of <see cref="CONTACT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestWorkOrder> ToEntities(this IEnumerable<RequestWorkOrderDTO> dtos)
        {
            return LinqExtension.ToEntity<CTRequestWorkOrder, RequestWorkOrderDTO>(dtos, ToEntity);
        }

    }
}
