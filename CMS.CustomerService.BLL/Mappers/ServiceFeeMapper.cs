using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class ServiceFeeMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
        static partial void OnDTO(this CTRequestServiceFee entity, RequestServiceFeeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> converted from <see cref="AddressDTO"/>.</param>
        static partial void OnEntity(this ServiceFeeDTO dto, CTServiceFee entity);

        /// <summary>
        /// Converts this instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> to convert.</param>
        public static CTServiceFee ToEntity(this ServiceFeeDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTServiceFee();
            entity.Account_Type_ID = dto.AccountTypeID;
            entity.Classification_ID = dto.ClassificationID;
            entity.Customer_Status_ID = dto.CustomerStatusID;
            entity.Customer_Type_ID = dto.CustomerTypeID;
            entity.Fee = dto.Fee;
            entity.IsActive = Convert.ToInt32(dto.IsActive);
            entity.ISPremier = dto.ISPremier;
            entity.LastLocationID = dto.LastLocationID;
            entity.LastUpdatedDate = dto.LastUpdatedDate == null ? DateTime.Now : Convert.ToDateTime( dto.LastUpdatedDate);
            entity.LastUpdatesUserID = dto.LastUpdatedUserId;
            entity.Location_ID = dto.LastUpdatedLocationID;
            entity.Service_fee_ID = dto.ServicefeeID;
            entity.Service_ID = dto.ServiceID;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static RequestServiceFeeDTO ToDTO(this CTRequestServiceFee entity)
        {
            if (entity == null) return null;

            var dto = new RequestServiceFeeDTO();

            dto.AccountTypeID = entity.Account_Type_ID;
            dto.AccountType_en = entity.AccountType_en;
            dto.AccountType_ar = entity.AccountType_ar;

            dto.ClassificationID = entity.Classification_ID;
            dto.ClassificationName_ar = entity.ClassificationName_ar;
            dto.ClassificationName_en = entity.ClassificationName_en;
            
            dto.CustomerStatusID = entity.Customer_Status_ID;
            dto.CustomerStatus_en = entity.CustomerStatus_en;
            dto.CustomerStatus_ar = entity.CustomerStatus_ar;

            dto.CustomerTypeID = entity.Customer_Type_ID;
            dto.CustomerType_en = entity.CustomerType_en;
            dto.CustomerType_ar = entity.CustomerType_ar;

            dto.Fee = entity.Fee;
            dto.IsActive =Convert.ToBoolean( entity.IsActive);
            dto.ISPremier = entity.ISPremier;

            dto.Location_ID = entity.Location_ID;
            dto.LocationName_ar = entity.LocationName_ar;
            dto.LocationName_en = entity.LocationName_en;

            dto.ServiceID = entity.ServiceID;
            dto.ServiceName_en = entity.ServiceName_en;
            dto.ServiceName_ar = entity.ServiceName_ar;

            dto.RequestID = entity.RequestID;
            dto.ServiceFeeID = entity.Service_Fee_ID;
            dto.Request = new DUC.CMS.CustomerService.BLL.CustomerAppService().GetRequestById(entity.RequestID);

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTServiceFee> ToEntities(this IEnumerable<ServiceFeeDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTServiceFee>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestServiceFeeDTO> ToDTOs(this IEnumerable<CTRequestServiceFee> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestServiceFeeDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
