using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_ACCOUNT_TYPE"/> and <see cref="CustomerAccountTypeDTO"/>.
    /// </summary>
    public static partial class CustomerAccountTypeMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CTCustomerAccounTypes entity, CustomerAccountTypeDTO dto);
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> converted from <see cref="CUSTOMER_ACCOUNT_TYPE"/>.</param>
        static partial void OnDTO(this CUSTOMER_ACCOUNT_TYPE entity, CustomerAccountTypeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> converted from <see cref="CustomerAccountTypeDTO"/>.</param>
        static partial void OnEntity(this CustomerAccountTypeDTO dto, CUSTOMER_ACCOUNT_TYPE entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerAccountTypeDTO"/> to an instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerAccountTypeDTO"/> to convert.</param>
        public static CUSTOMER_ACCOUNT_TYPE ToEntity(this CustomerAccountTypeDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_ACCOUNT_TYPE();

            entity.CUSTOMER_ACCOUNT_TYPE_ID = dto.CustomerAccountTypeID;
            entity.EN_CUSTOMER_ACCOUNT_TYPE = dto.ENCustomerAccountType;
            entity.AR_CUSTOMER_ACCOUNT_TYPE = dto.ARCustomerAccountType;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static CustomerAccountTypeDTO ToDTO(this CTCustomerAccounTypes entity)
        {
            if (entity == null) return null;

            var dto = new CustomerAccountTypeDTO();

            dto.CustomerAccountTypeID = entity.CustomerAccountTypeID;
            dto.ENCustomerAccountType = entity.EnCustomerAccountType;
            dto.ARCustomerAccountType = entity.ArCustomerAccountType;

            entity.OnDTO(dto);

            return dto;
        }
        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_ACCOUNT_TYPE"/> to convert.</param>
        public static CustomerAccountTypeDTO ToDTO(this CUSTOMER_ACCOUNT_TYPE entity)
        {
            if (entity == null) return null;

            var dto = new CustomerAccountTypeDTO();

            dto.CustomerAccountTypeID = entity.CUSTOMER_ACCOUNT_TYPE_ID;
            dto.ENCustomerAccountType = entity.EN_CUSTOMER_ACCOUNT_TYPE;
            dto.ARCustomerAccountType = entity.AR_CUSTOMER_ACCOUNT_TYPE;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerAccountTypeDTO"/> to an instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_ACCOUNT_TYPE> ToEntities(this IEnumerable<CustomerAccountTypeDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_ACCOUNT_TYPE, CustomerAccountTypeDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerAccountTypeDTO> ToDTOs(this IEnumerable<CTCustomerAccounTypes> entities)
        {
            return LinqExtension.ToDTO<CTCustomerAccounTypes, CustomerAccountTypeDTO>(entities, ToDTO);
        }
        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_ACCOUNT_TYPE"/> to an instance of <see cref="CustomerAccountTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerAccountTypeDTO> ToDTOs(this IEnumerable<CUSTOMER_ACCOUNT_TYPE> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_ACCOUNT_TYPE, CustomerAccountTypeDTO>(entities, ToDTO);
        }
    }
}
