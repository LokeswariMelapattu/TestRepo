using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="BENEFICIARY_GROUP"/> and <see cref="BeneficiaryGroupDTO"/>.
    /// </summary>
    public static partial class BeneficiaryGroupMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BeneficiaryGroupDTO"/> converted from <see cref="BENEFICIARY_GROUP"/>.</param>
        static partial void OnDTO(this BENEFICIARY_GROUP entity, BeneficiaryGroupDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="BENEFICIARY_GROUP"/> converted from <see cref="BeneficiaryGroupDTO"/>.</param>
        static partial void OnEntity(this BeneficiaryGroupDTO dto, BENEFICIARY_GROUP entity);

        /// <summary>
        /// Converts this instance of <see cref="BeneficiaryGroupDTO"/> to an instance of <see cref="BENEFICIARY_GROUP"/>.
        /// </summary>
        /// <param name="dto"><see cref="BeneficiaryGroupDTO"/> to convert.</param>
        public static BENEFICIARY_GROUP ToEntity(this BeneficiaryGroupDTO dto)
        {
            if (dto == null) return null;

            var entity = new BENEFICIARY_GROUP();

            entity.GROUP_ID = dto.GroupId == null ? -1 : (int)dto.GroupId;
            entity.CUSTOMER_ID = dto.CustomerId;
            entity.EN_GROUP_NAME = dto.ENGroupName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = entity.LAST_LOCATION_ID;
            entity.DESCRIPTION = dto.Description;
            entity.AR_GROUP_NAME = dto.ARGroupName;

            dto.OnEntity(entity);

            return entity;
        }

        public static BENEFICIARY_GROUP ToBGEntity(this CustomerGroupDTO dto)
        {
            if (dto == null) return null;

            var entity = new BENEFICIARY_GROUP();

            entity.GROUP_ID = dto.GroupID == null ? -1 : (int)dto.GroupID;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.EN_GROUP_NAME = dto.ENGroupName;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = entity.LAST_LOCATION_ID;
            entity.DESCRIPTION = dto.Description;
            entity.CODE_COMBINATION_ID = dto.CostCenterID;

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="BENEFICIARY_GROUP"/> to an instance of <see cref="BeneficiaryGroupDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="BENEFICIARY_GROUP"/> to convert.</param>
        public static BeneficiaryGroupDTO ToDTO(this BENEFICIARY_GROUP entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiaryGroupDTO();

            dto.GroupId = entity.GROUP_ID;
            dto.CustomerId = entity.CUSTOMER_ID;
            dto.ENGroupName = entity.EN_GROUP_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.LastUpdatedUserId =(int?) entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.Description = entity.DESCRIPTION;
            dto.ARGroupName = entity.AR_GROUP_NAME;
            dto.LastUpdatedLocationID =Convert.ToInt32(entity.LAST_LOCATION_ID);

            entity.OnDTO(dto);

            return dto;
        }

        public static CustomerGroupDTO ToCGDTO(this BENEFICIARY_GROUP entity)
        {
            if (entity == null) return null;

            var dto = new CustomerGroupDTO();

            dto.GroupID = entity.GROUP_ID;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.ENGroupName = entity.EN_GROUP_NAME;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.LastUpdatedUserId = (int?)entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.Description = entity.DESCRIPTION;
            dto.CostCenterID = (long?)entity.CODE_COMBINATION_ID;

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="BeneficiaryGroupDTO"/> to an instance of <see cref="BENEFICIARY_GROUP"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<BENEFICIARY_GROUP> ToEntities(this IEnumerable<BeneficiaryGroupDTO> dtos)
        {
            return LinqExtension.ToEntity<BENEFICIARY_GROUP, BeneficiaryGroupDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="BENEFICIARY_GROUP"/> to an instance of <see cref="BeneficiaryGroupDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<BeneficiaryGroupDTO> ToDTOs(this IEnumerable<BENEFICIARY_GROUP> entities)
        {
            return LinqExtension.ToDTO<BENEFICIARY_GROUP, BeneficiaryGroupDTO>(entities, ToDTO);
        }

        /// <summary>
        /// Converts each instance of <see cref="BeneficiaryGroupDTO"/> to an instance of <see cref="BENEFICIARY_GROUP"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<BENEFICIARY_GROUP> ToBGEntities(this IEnumerable<CustomerGroupDTO> dtos)
        {
            return LinqExtension.ToEntity<BENEFICIARY_GROUP, CustomerGroupDTO>(dtos, ToBGEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="BENEFICIARY_GROUP"/> to an instance of <see cref="BeneficiaryGroupDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerGroupDTO> ToCGDTOs(this IEnumerable<BENEFICIARY_GROUP> entities)
        {
            return LinqExtension.ToDTO<BENEFICIARY_GROUP, CustomerGroupDTO>(entities, ToCGDTO);
        }

    }
}
