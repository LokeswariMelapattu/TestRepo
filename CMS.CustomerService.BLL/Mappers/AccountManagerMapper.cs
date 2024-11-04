using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="ACCOUNT_MANAGER"/> and <see cref="AccountManagerDTO"/>.
    /// </summary>
    public static partial class AccountManagerMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AccountManagerDTO"/> converted from <see cref="ACCOUNT_MANAGER"/>.</param>
        static partial void OnDTO(this ACCOUNT_MANAGER entity, AccountManagerDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ACCOUNT_MANAGER"/> converted from <see cref="AccountManagerDTO"/>.</param>
        static partial void OnEntity(this AccountManagerDTO dto, ACCOUNT_MANAGER entity);

        /// <summary>
        /// Converts this instance of <see cref="AccountManagerDTO"/> to an instance of <see cref="ACCOUNT_MANAGER"/>.
        /// </summary>
        /// <param name="dto"><see cref="AccountManagerDTO"/> to convert.</param>
        public static ACCOUNT_MANAGER ToEntity(this AccountManagerDTO dto)
        {
            if (dto == null) return null;

            var entity = new ACCOUNT_MANAGER();

            entity.ACCOUNT_MANAGER_ID = dto.AccountManagerID == null ? -1 : (int)dto.AccountManagerID;
            entity.USER_ID = dto.UserID;
            entity.NAME = dto.Name;
            entity.MOBILE = dto.Mobile;
            entity.PHONE = dto.Phone;
            entity.EMAIL = dto.Email;
            entity.FAX = dto.Fax;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ACCOUNT_MANAGER"/> to an instance of <see cref="AccountManagerDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ACCOUNT_MANAGER"/> to convert.</param>
        public static AccountManagerDTO ToDTO(this ACCOUNT_MANAGER entity)
        {
            if (entity == null) return null;

            var dto = new AccountManagerDTO();

            dto.AccountManagerID = entity.ACCOUNT_MANAGER_ID;
            dto.UserID = entity.USER_ID;
            dto.Name = entity.NAME;
            dto.Mobile = entity.MOBILE;
            dto.Phone = entity.PHONE;
            dto.Email = entity.EMAIL;
            dto.Fax = entity.FAX;
            dto.IsActive = entity.IS_ACTIVE == 1;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AccountManagerDTO"/> to an instance of <see cref="ACCOUNT_MANAGER"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ACCOUNT_MANAGER> ToEntities(this IEnumerable<AccountManagerDTO> dtos)
        {
            return LinqExtension.ToEntity<ACCOUNT_MANAGER, AccountManagerDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="ACCOUNT_MANAGER"/> to an instance of <see cref="AccountManagerDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<AccountManagerDTO> ToDTOs(this IEnumerable<ACCOUNT_MANAGER> entities)
        {
            return LinqExtension.ToDTO<ACCOUNT_MANAGER, AccountManagerDTO>(entities, ToDTO);
        }

    }
}
