
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTAccountBalance"/> and <see cref="AccountBalanceDTO"/>.
    /// </summary>
    public static partial class CTAccountBalanceMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AccountBalanceDTO"/> converted from <see cref="CTAccountBalance"/>.</param>
        static partial void OnDTO(this CTAccountBalance entity, AccountBalanceDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTAccountBalance"/> converted from <see cref="AccountBalanceDTO"/>.</param>
        static partial void OnEntity(this AccountBalanceDTO dto, CTAccountBalance entity);

        /// <summary>
        /// Converts this instance of <see cref="AccountBalanceDTO"/> to an instance of <see cref="CTAccountBalance"/>.
        /// </summary>
        /// <param name="dto"><see cref="AccountBalanceDTO"/> to convert.</param>
        public static CTAccountBalance ToEntity(this AccountBalanceDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTAccountBalance();

            entity.CustomerID = dto.CustomerID;
            entity.InitialBalance = dto.InitialBalance;
            entity.FinalBalance = dto.FinalBalance;
            entity.TransactionDate = dto.TransactionDate;
            entity.Amount = dto.Amount;
            entity.PaymentTypeID = dto.PaymentTypeID;
            entity.TransactionType = dto.TransactionType;
            entity.TransactionTypeAR = dto.TransactionTypeAR;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTAccountBalance"/> to an instance of <see cref="AccountBalanceDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTAccountBalance"/> to convert.</param>
        public static AccountBalanceDTO ToDTO(this CTAccountBalance entity)
        {
            if (entity == null) return null;

            var dto = new AccountBalanceDTO();

            dto.CustomerID = entity.CustomerID.HasValue?entity.CustomerID.Value:0;
            dto.InitialBalance = entity.InitialBalance.HasValue ? (int)entity.InitialBalance.Value : 0;
            dto.FinalBalance = entity.FinalBalance;
            dto.TransactionDate = entity.TransactionDate.HasValue ? entity.TransactionDate.Value : DateTime.Now;
            dto.Amount = entity.Amount.HasValue ? entity.Amount.Value : 0;
            dto.PaymentTypeID = entity.PaymentTypeID.HasValue ? (int)entity.PaymentTypeID.Value : 0;
            dto.TransactionType = entity.TransactionType;
            dto.TransactionTypeAR = entity.TransactionTypeAR;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AccountBalanceDTO"/> to an instance of <see cref="CTAccountBalance"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTAccountBalance> ToEntities(this IEnumerable<AccountBalanceDTO> dtos)
        {
            return LinqExtension.ToEntity<CTAccountBalance, AccountBalanceDTO>(dtos, ToEntity);

        }

        /// <summary>
        /// Converts each instance of <see cref="CTAccountBalance"/> to an instance of <see cref="AccountBalanceDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<AccountBalanceDTO> ToDTOs(this IEnumerable<CTAccountBalance> entities)
        {
            return LinqExtension.ToDTO<CTAccountBalance, AccountBalanceDTO>(entities, ToDTO);

        }

    }
}
