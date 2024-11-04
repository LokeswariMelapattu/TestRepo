using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTCustomerGroup"/> and <see cref="CustomerGroupDTO"/>.
    /// </summary>
    public static partial class CTCustomerGroupMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerGroupDTO"/> converted from <see cref="CTCustomerGroup"/>.</param>
        static partial void OnDTO(this CTCustomerGroup entity, CustomerGroupDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerGroup"/> converted from <see cref="CustomerGroupDTO"/>.</param>
        static partial void OnEntity(this CustomerGroupDTO dto, CTCustomerGroup entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerGroupDTO"/> to an instance of <see cref="CTCustomerGroup"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerGroupDTO"/> to convert.</param>
        public static CTCustomerGroup ToEntity(this CustomerGroupDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTCustomerGroup();

            entity.CUSTOMER_ID = dto.CustomerID;
            entity.GROUP_ID = dto.GroupID == null ? -1 : (int)dto.GroupID;
            entity.EN_GROUP_NAME = dto.ENGroupName;
            entity.AR_GROUP_NAME = dto.ARGroupName;
            entity.DESCRIPTION = dto.Description;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.CostCenterID = dto.CostCenterID;
            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTCustomerGroup"/> to an instance of <see cref="CustomerGroupDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerGroup"/> to convert.</param>
        public static CustomerGroupDTO ToDTO(this CTCustomerGroup entity)
        {
            if (entity == null) return null;

            var dto = new CustomerGroupDTO();

            dto.CustomerID = entity.CUSTOMER_ID;
            dto.GroupID = entity.GROUP_ID;
            dto.ENGroupName = entity.EN_GROUP_NAME;
            dto.ARGroupName = entity.AR_GROUP_NAME;
            dto.Description = entity.DESCRIPTION;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.CostCenterID = entity.CostCenterID; 

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerGroupDTO" /> to an instance of <see cref="CTCustomerGroup" />.
        /// </summary>
        /// <param name="dtos">The dtos.</param>
        /// <returns></returns>
        public static List<CTCustomerGroup> ToEntities(this IEnumerable<CustomerGroupDTO> dtos)
        {
            return LinqExtension.ToEntity<CTCustomerGroup, CustomerGroupDTO>(dtos, ToEntity);


        }

        /// <summary>
        /// Converts each instance of <see cref="CTCustomerGroup" /> to an instance of <see cref="CustomerGroupDTO" />.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public static List<CustomerGroupDTO> ToDTOs(this IEnumerable<CTCustomerGroup> entities)
        {
            return LinqExtension.ToDTO<CTCustomerGroup, CustomerGroupDTO>(entities, ToDTO);

        }

    }
}
