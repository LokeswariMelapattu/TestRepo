using System;
using DUC.CMS.Token.BLL.DTO;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{
    public static partial class BatchBeneficiaryMapper
    {      
        static partial void OnEntity(this BatchBeneficiaryDTO dto, CTBatchBeneficiary entity);

        public static CTBatchBeneficiary ToEntity(this BatchBeneficiaryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBatchBeneficiary();

            entity.BeneficiaryCode = dto.BeneficiaryCode;
            entity.CustomerID = dto.CustomerID;
            entity.BeneficiaryName = dto.BeneficiaryName;
            entity.Mobile = dto.Mobile;
            entity.Email = dto.Email;
            entity.PIN = dto.PIN;
            entity.IdentificationTypeID = dto.IdentificationTypeID;
            entity.IdentificationID = dto.IdentificationID;
            entity.IsActive = Convert.ToInt16(dto.IsActive);
            entity.NationalityID = dto.NationalityID;
            entity.BeneficiaryStatusID = dto.BeneficiaryStatusID;
            entity.BeneficiaryStatusReasonID = dto.BeneficiaryStatusReasonID;
            entity.StatusRemark = dto.StatusRemark;
            entity.Gender = dto.Gender;
            entity.DateOfBirth = dto.Birthday;

            dto.OnEntity(entity);

            return entity;
        }
        
    }
}
