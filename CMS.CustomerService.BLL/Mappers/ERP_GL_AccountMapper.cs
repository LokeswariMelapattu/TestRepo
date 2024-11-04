using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
  public static partial  class ERP_GL_AccountMapper
    {
              /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="ADDRESS"/>.</param>
        static partial void OnDTO(this ERP_GL_ACCOUNT entity, ERP_GL_AccountDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> converted from <see cref="AddressDTO"/>.</param>
        static partial void OnEntity(this ERP_GL_AccountDTO dto, ERP_GL_ACCOUNT entity);

        /// <summary>
        /// Converts this instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> to convert.</param>
        public static ERP_GL_ACCOUNT ToEntity(this ERP_GL_AccountDTO dto)
        {
            if (dto == null) return null;

            var entity = new ERP_GL_ACCOUNT();

            entity.ACCOUNT_CODE = dto.AccountCode;
            entity.ACCOUNT_DESCRIPTION = dto.Description;
            entity.CODE_COMBINATION_ID = dto.CostCenterID;
            entity.IS_ACTIVE = Convert.ToInt16(dto.isActive);


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ADDRESS"/> to an instance of <see cref="AddressDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ADDRESS"/> to convert.</param>
        public static ERP_GL_AccountDTO ToDTO(this ERP_GL_ACCOUNT entity)
        {
            if (entity == null) return null;

            var dto = new ERP_GL_AccountDTO();
            dto.isActive = Convert.ToBoolean(entity.IS_ACTIVE);
            dto.Description = entity.ACCOUNT_DESCRIPTION;
            dto.CostCenterID = entity.CODE_COMBINATION_ID ;
            dto.AccountCode= entity.ACCOUNT_CODE; 

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="AddressDTO"/> to an instance of <see cref="ADDRESS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ERP_GL_ACCOUNT> ToEntities(this IEnumerable<ERP_GL_AccountDTO> dtos)
        {
            if (dtos == null) return null;
            var entities = new List<ERP_GL_ACCOUNT>();
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
        public static List<ERP_GL_AccountDTO> ToDTOs(this IEnumerable<ERP_GL_ACCOUNT> entities)
        {
            if (entities == null) return null;
            var dtos = new List<ERP_GL_AccountDTO>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.ToDTO());
            }
            return dtos;
        }
    }
}
