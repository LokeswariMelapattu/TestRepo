using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;


namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CTRequestAccountManager"/> and <see cref="CTRequestAccountManagerDTO"/>.
    /// </summary>
    public static partial class RequestAccountManagerMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CTRequestAccountManagerDTO"/> converted from <see cref="CTRequestAccountManager"/>.</param>
        static partial void OnDTO(this CTRequestAccountManager entity, RequestAccountManagerDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestAccountManager"/> converted from <see cref="CTRequestAccountManagerDTO"/>.</param>
        static partial void OnEntity(this RequestAccountManagerDTO dto, CTRequestAccountManager entity);

        /// <summary>
        /// Converts this instance of <see cref="CTRequestAccountManagerDTO"/> to an instance of <see cref="CTRequestAccountManager"/>.
        /// </summary>
        /// <param name="dto"><see cref="CTRequestAccountManagerDTO"/> to convert.</param>
        public static CTRequestAccountManager ToEntity(this RequestAccountManagerDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTRequestAccountManager();

            entity.AccountManagerID = dto.AccountManagerID == null ? -1 : dto.AccountManagerID;
            entity.Email = dto.Email;
            entity.Fax = dto.Fax;
            entity.isActive = (short)(!dto.IsActive ? 1 : 0);
            entity.LastLocationID = dto.LastUpdatedLocationID;
            entity.LastUpdatedDate = dto.LastUpdatedDate;
            entity.LastUserID = dto.LastUpdatedUserId;
            entity.Mobile = dto.Mobile;
            entity.Name = dto.Name;
            entity.Phone = dto.Phone;
            entity.user_id = dto.LastUpdatedUserId;


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTRequestAccountManager"/> to an instance of <see cref="CTRequestAccountManagerDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTRequestAccountManager"/> to convert.</param>
        public static RequestAccountManagerDTO ToDTO(this CTRequestAccountManager entity)
        {
            if (entity == null) return null;

            var dto = new RequestAccountManagerDTO();

            dto.AccountManagerID = entity.AccountManagerID;
            dto.Email = entity.Email;
            dto.Fax = entity.Fax;
            dto.IsActive = entity.isActive == null ? false : true;
            dto.LastUpdatedLocationID = entity.LastLocationID;
            dto.LastUpdatedDate = entity.LastUpdatedDate;
            dto.LastUpdatedUserId = entity.LastUserID;
            dto.Mobile = entity.Mobile;
            dto.Name = entity.Name;
            dto.Phone = entity.Phone;
            dto.LastUpdatedUserId = entity.user_id;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CTRequestAccountManagerDTO"/> to an instance of <see cref="CTRequestAccountManager"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTRequestAccountManager> ToEntities(this IEnumerable<RequestAccountManagerDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<CTRequestAccountManager>();
            foreach (var dto in dtos)
            {
                entities.Add(dto.ToEntity());
            }
            return entities;
        }

        /// <summary>
        /// Converts each instance of <see cref="CTRequestAccountManager"/> to an instance of <see cref="CTRequestAccountManagerDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<RequestAccountManagerDTO> ToDTOs(this IEnumerable<CTRequestAccountManager> entities)
        {
            if (entities == null) return null;
            var dtos = new List<RequestAccountManagerDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }

    }
}
