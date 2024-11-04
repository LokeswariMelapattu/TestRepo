using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="ACCOUNT_MANAGER"/> and <see cref="AccountManagerDTO"/>.
    /// </summary>
    public static partial class OrderCancellationMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AccountManagerDTO"/> converted from <see cref="ACCOUNT_MANAGER"/>.</param>
        static partial void OnDTO(this CTOrderCancellation entity, OrderCancellationDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ACCOUNT_MANAGER"/> converted from <see cref="AccountManagerDTO"/>.</param>
        static partial void OnEntity(this OrderCancellationDTO dto, CTOrderCancellation entity);

        /// <summary>
        /// Converts this instance of <see cref="AccountManagerDTO"/> to an instance of <see cref="ACCOUNT_MANAGER"/>.
        /// </summary>
        /// <param name="dto"><see cref="AccountManagerDTO"/> to convert.</param>
        public static CTOrderCancellation ToEntity(this OrderCancellationDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTOrderCancellation();

            entity.FeeAmount = dto.FeeAmount;
            entity.OrderID = dto.OrderID;
            entity.ServcieTypeName = dto.ServcieTypeName;
            entity.ServiceTypeID = dto.ServiceTypeID;
            entity.TokenStatusARName = dto.TokenStatusARName;
            entity.TokenStatusENName = dto.TokenStatusENName;
            entity.TokenStatusID = dto.TokenStatusID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ACCOUNT_MANAGER"/> to an instance of <see cref="AccountManagerDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ACCOUNT_MANAGER"/> to convert.</param>
        public static OrderCancellationDTO ToDTO(this CTOrderCancellation entity)
        {
            if (entity == null) return null;

            var dto = new OrderCancellationDTO();

            dto.FeeAmount = entity.FeeAmount;
            dto.OrderID = entity.OrderID;
            dto.ServcieTypeName = entity.ServcieTypeName;
            dto.ServiceTypeID = entity.ServiceTypeID;
            dto.TokenStatusARName = entity.TokenStatusARName;
            dto.TokenStatusENName = entity.TokenStatusENName;
            dto.TokenStatusID = entity.TokenStatusID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AccountManagerDTO"/> to an instance of <see cref="ACCOUNT_MANAGER"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTOrderCancellation> ToEntities(this IEnumerable<OrderCancellationDTO> dtos)
        {
            return LinqExtension.ToEntity<CTOrderCancellation, OrderCancellationDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="ACCOUNT_MANAGER"/> to an instance of <see cref="AccountManagerDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<OrderCancellationDTO> ToDTOs(this IEnumerable<CTOrderCancellation> entities)
        {
            return LinqExtension.ToDTO<CTOrderCancellation, OrderCancellationDTO>(entities, ToDTO);
        }

    }
}
