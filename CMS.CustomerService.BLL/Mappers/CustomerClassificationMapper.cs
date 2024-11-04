using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_CLASSIFICATION"/> and <see cref="CustomerClassificationDTO"/>.
    /// </summary>
    public static partial class CustomerClassificationMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerClassificationDTO"/> converted from <see cref="CUSTOMER_CLASSIFICATION"/>.</param>
        static partial void OnDTO(this CUSTOMER_CLASSIFICATION entity, CustomerClassificationDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CLASSIFICATION"/> converted from <see cref="CustomerClassificationDTO"/>.</param>
        static partial void OnEntity(this CustomerClassificationDTO dto, CUSTOMER_CLASSIFICATION entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerClassificationDTO"/> to an instance of <see cref="CUSTOMER_CLASSIFICATION"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerClassificationDTO"/> to convert.</param>
        public static CUSTOMER_CLASSIFICATION ToEntity(this CustomerClassificationDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_CLASSIFICATION();

            entity.CUSTOMER_CLASSIFICATION_ID = dto.CustomerClassificationID;
            entity.EN_CLASSIFICATION = dto.Classification;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0);
            entity.AR_CLASSIFICATION = dto.ARClassification;
            entity.EN_CLASSIFICATION = dto.ENClassification;
            entity.LAST_UPDATED_USER_ID = dto.LastUpdatedUserId;
            entity.LAST_UPDATED_DATE = dto.LastUpdatedDate;
            entity.LAST_LOCATION_ID = dto.LastUpdatedLocationID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_CLASSIFICATION"/> to an instance of <see cref="CustomerClassificationDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_CLASSIFICATION"/> to convert.</param>
        public static CustomerClassificationDTO ToDTO(this CUSTOMER_CLASSIFICATION entity)
        {
            if (entity == null) return null;

            var dto = new CustomerClassificationDTO();

            dto.CustomerClassificationID = entity.CUSTOMER_CLASSIFICATION_ID;
            dto.Classification = entity.EN_CLASSIFICATION;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.ARClassification = entity.AR_CLASSIFICATION;
            dto.ENClassification = entity.EN_CLASSIFICATION;
            dto.LastUpdatedDate = entity.LAST_UPDATED_DATE;
            dto.LastUpdatedLocationID = (int?)entity.LAST_LOCATION_ID;
            dto.LastUpdatedUserId =(int?) entity.LAST_UPDATED_USER_ID;


            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerClassificationDTO"/> to an instance of <see cref="CUSTOMER_CLASSIFICATION"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_CLASSIFICATION> ToEntities(this IEnumerable<CustomerClassificationDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_CLASSIFICATION, CustomerClassificationDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_CLASSIFICATION"/> to an instance of <see cref="CustomerClassificationDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerClassificationDTO> ToDTOs(this IEnumerable<CUSTOMER_CLASSIFICATION> entities)
        {
            return LinqExtension.ToDTO<CUSTOMER_CLASSIFICATION, CustomerClassificationDTO>(entities, ToDTO);
        }

    }
}
