using System;
using DUC.CMS.CPS.BLL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.DTO;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class QualityAssuranceMapper
    {
        static partial void OnDTO(this CTQualityAssurance entity, QualityAssuranceDTO dto);

        static partial void OnEntity(this QualityAssuranceDTO dto, CTQualityAssurance entity);

        public static CTQualityAssurance ToEntity(this QualityAssuranceDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTQualityAssurance();

            entity.UserID = dto.UserID;
            entity.CardSerial = dto.CardSerial;
            entity.QualityPassed = Convert.ToInt16(dto.QualityPassed);
            entity.TokenCode = dto.TokenCode;
            entity.FailureReason = dto.FailureReason;

            dto.OnEntity(entity);

            return entity;
        }

        public static QualityAssuranceDTO ToDTO(this CTQualityAssurance entity)
        {
            if (entity == null) return null;

            var dto = new QualityAssuranceDTO();

            dto.UserID = entity.UserID;
            dto.CardSerial = entity.CardSerial;
            dto.QualityPassed = Convert.ToBoolean(entity.QualityPassed);
            dto.TokenCode = entity.TokenCode;
            dto.FailureReason = entity.FailureReason;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<CTQualityAssurance> ToEntities(this IEnumerable<QualityAssuranceDTO> dtos)
        {
            return LinqExtension.ToEntity<CTQualityAssurance, QualityAssuranceDTO>(dtos, ToEntity);
        }

        public static List<QualityAssuranceDTO> ToDTOs(this IEnumerable<CTQualityAssurance> entities)
        {
            return LinqExtension.ToDTO<CTQualityAssurance, QualityAssuranceDTO>(entities, ToDTO);
        }
    }
}

