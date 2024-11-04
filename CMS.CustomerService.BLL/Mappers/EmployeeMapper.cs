using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="ERP_EMPLOYEE"/> and <see cref="EmployeeHRDTO"/>.
    /// </summary>
    public static partial class EmployeeMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="EmployeeHRDTO"/> converted from <see cref="ERP_EMPLOYEE"/>.</param>
        static partial void OnDTO(this CTERPEmployee entity, EmployeeHRDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ERP_EMPLOYEE"/> converted from <see cref="EmployeeHRDTO"/>.</param>
        static partial void OnEntity(this EmployeeHRDTO dto, CTERPEmployee entity);

        /// <summary>
        /// Converts this instance of <see cref="EmployeeHRDTO"/> to an instance of <see cref="ERP_EMPLOYEE"/>.
        /// </summary>
        /// <param name="dto"><see cref="EmployeeHRDTO"/> to convert.</param>
        public static CTERPEmployee ToEntity(this EmployeeHRDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTERPEmployee();

            entity.EmployeeNumber = dto.EmployeeNumber;
            entity.EmployeeName = dto.EmployeeName;
            entity.Nationality = dto.NationalityID;
            entity.TerminationDate = dto.TerminationDate;
            entity.NationalID = dto.NationalId;
            entity.Email = dto.Email;
            entity.Address = dto.Address;
            entity.EmployeePhone = dto.EmployeePhone;
            entity.EmployeeMobile = dto.EmployeeMobile;
            entity.LocationDepartment = dto.LocationDepartment;
            entity.EmployeeRole = dto.EmployeeRole;
            entity.IsActive = (short)(dto.IsActive ? 1 : 0);
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ERP_EMPLOYEE"/> to an instance of <see cref="EmployeeHRDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="ERP_EMPLOYEE"/> to convert.</param>
        public static EmployeeHRDTO ToDTO(this CTERPEmployee entity)
        {
            if (entity == null) return null;

            var dto = new EmployeeHRDTO();

            dto.EmployeeNumber = entity.EmployeeNumber;
            dto.EmployeeName = entity.EmployeeName;
            dto.NationalityID = entity.Nationality;
            dto.TerminationDate = entity.TerminationDate;
            dto.NationalId = entity.NationalID;
            dto.Email = entity.Email;
            dto.Address = entity.Address;
            dto.EmployeePhone = entity.EmployeePhone;
            dto.EmployeeMobile = entity.EmployeeMobile;
            dto.LocationDepartment = entity.LocationDepartment;
            dto.IsActive = entity.IsActive == 1;
            dto.EmployeeRole = entity.EmployeeRole;
            dto.LastUpdatedLocationID = entity.LOCATION_ID;
            dto.LastUpdatedUserId = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.Birthday = entity.DATE_OF_BIRTH;
            dto.Gender = entity.Gender;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="EmployeeHRDTO"/> to an instance of <see cref="ERP_EMPLOYEE"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTERPEmployee> ToEntities(this IEnumerable<EmployeeHRDTO> dtos)
        {
            return LinqExtension.ToEntity<CTERPEmployee, EmployeeHRDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="ERP_EMPLOYEE"/> to an instance of <see cref="EmployeeHRDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<EmployeeHRDTO> ToDTOs(this IEnumerable<CTERPEmployee> entities)
        {
            return LinqExtension.ToDTO<CTERPEmployee, EmployeeHRDTO>(entities, ToDTO);
        }

    }
}
