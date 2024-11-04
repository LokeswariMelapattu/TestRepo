using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.Beneficiary.BLL.DTO;
using DUC.CMS.CustomerService.DAL.DataExtensions;

namespace DUC.CMS.Beneficiary.BLL.Mappers
{
    public static partial class BeneficiaryMapper
    {

        #region BeneficiaryMapper

        public static BENEFICIARY ToEntity(this BeneficiaryDTO dto)
        {
            if (dto == null) return null;

            var entity = new BENEFICIARY();

            entity.BENEFICIARY_ID = dto.BeneficiaryID == null ? -4 : (int)dto.BeneficiaryID;
            entity.CODE = dto.Code;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.EMPLOYEE_ID = dto.EmployeeID;
            entity.NAME = dto.Name;
            entity.MOBILE = dto.Mobile;
            entity.EMAIL = dto.Email;
            entity.PIN = dto.PIN;
            entity.LANGUAGE_ID = dto.LanguageID;
            entity.IDENTIFICATION_TYPE_ID = dto.IdentificationTypeID;
            entity.NATIONAL_ID = dto.NationalID;
            entity.NATIONALILTY_ID = dto.NationalityID;
            entity.NOTIFICATION_CHANNEL_ID = dto.NotificationChannelID;
            entity.NOTIFICATION_LANGUAGE_ID = dto.NotificationLanguageID;
            entity.FAMILY_ID = dto.FamilyID;
            entity.GROUP_ID = dto.GroupID;
            entity.BENEFICIARY_STATUS_ID = dto.BeneficiaryStatusID;
            entity.BENEFICIARY_STATUS_REASON_ID = dto.BeneficiaryStatusReasonID;
            entity.IS_STATUS_INHERITED = Convert.ToInt16(dto.IsStatusInherited);
            entity.LAST_UPDATED_USER_ID = dto.LastUpdateUser;
            entity.LAST_UPDATED_DATE = dto.LastUpdateDate;
            entity.LAST_LOCATION_ID = dto.LocationID;
            entity.IS_VIP = Convert.ToInt16(dto.IsVIP);
            entity.IS_ACTIVE = Convert.ToInt16(dto.IsActive);
            entity.ADDRESS_ID = dto.BasicAddressID;
            entity.ADDRESS = dto.BasicAddressDTO.ToEntity();
            entity.IS_DISABILITY = Convert.ToInt16(dto.HasDisability);
            entity.REGISTRATION_DATE = dto.RegistrationDate;
            entity.GENDER = dto.Gender;
            entity.IS_CUSTOMER_DEFAULT = Convert.ToInt16(dto.IsDefaultBeneficiary);
            entity.DATEOFBIRTH = dto.Birthday;

            return entity;
        }

        public static BeneficiaryDTO ToDTO(this BENEFICIARY entity)
        {
            if (entity == null) return null;

            var dto = new BeneficiaryDTO();

            dto.BeneficiaryID = entity.BENEFICIARY_ID;
            dto.Code = entity.CODE;
            dto.CustomerID = entity.CUSTOMER_ID;
            dto.EmployeeID = entity.EMPLOYEE_ID;
            dto.Name = entity.NAME;
            dto.Mobile = entity.MOBILE;
            dto.Email = entity.EMAIL;
            dto.PIN = entity.PIN;
            dto.LanguageID = entity.LANGUAGE_ID;
            dto.IdentificationTypeID = entity.IDENTIFICATION_TYPE_ID;
            dto.NationalID = entity.NATIONAL_ID;
            dto.NationalityID = entity.NATIONALILTY_ID;
            dto.NotificationChannelID = entity.NOTIFICATION_CHANNEL_ID;
            dto.NotificationLanguageID = entity.NOTIFICATION_LANGUAGE_ID;
            dto.FamilyID = entity.FAMILY_ID;
            dto.GroupID = entity.GROUP_ID;
            dto.BeneficiaryStatusID = entity.BENEFICIARY_STATUS_ID;
            dto.BeneficiaryStatusReasonID = entity.BENEFICIARY_STATUS_REASON_ID;
            dto.IsStatusInherited = Convert.ToBoolean(entity.IS_STATUS_INHERITED);
            dto.LastUpdateUser = entity.LAST_UPDATED_USER_ID;
            dto.LastUpdateDate = entity.LAST_UPDATED_DATE;
            dto.LocationID =(int?) entity.LAST_LOCATION_ID;
            dto.IsVIP = Convert.ToBoolean(entity.IS_VIP);
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.BasicAddressID = entity.ADDRESS_ID;
            dto.BasicAddressDTO = entity.ADDRESS == null ? null : entity.ADDRESS.ToDTO();
            var bReceiptPref = new BeneficiaryAppService().GetBeneficiaryReceiptPreference(entity.BENEFICIARY_ID);
            if (bReceiptPref == null)
                dto._BeneficiaryReceiptPreferenceDTO = new Lazy<BeneficiaryReceiptPreferenceDTO>(() => new BeneficiaryReceiptPreferenceDTO { BeneficiaryId = entity.BENEFICIARY_ID, ReceiptTypeId = 3 });
            else
                dto._BeneficiaryReceiptPreferenceDTO = new Lazy<BeneficiaryReceiptPreferenceDTO>(() => bReceiptPref);

            dto.HasDisability = Convert.ToBoolean(entity.IS_DISABILITY);
            dto.RegistrationDate = entity.REGISTRATION_DATE;
            dto.Gender = entity.GENDER;
            dto.IsDefaultBeneficiary = Convert.ToBoolean(entity.IS_CUSTOMER_DEFAULT);
            dto.Birthday = entity.DATEOFBIRTH;

            return dto;
        }

        public static List<BENEFICIARY> ToEntities(this IEnumerable<BeneficiaryDTO> dtos)
        {
            return LinqExtension.ToEntity<BENEFICIARY, BeneficiaryDTO>(dtos, ToEntity);
        }

        public static List<BeneficiaryDTO> ToDTOs(this IEnumerable<BENEFICIARY> entities)
        {
            return LinqExtension.ToDTO<BENEFICIARY, BeneficiaryDTO>(entities, ToDTO);
        }
        #endregion

        #region CTBeneficiaryMapper
        public static BeneficiaryDTO ToDTO(this CTBeneficiaryInfo entity)
        {
            if (entity == null) return null;
            if (entity.BeneficiaryEntity == null) return null;

            var dto = new BeneficiaryDTO();

            dto.BeneficiaryID = entity.BeneficiaryEntity.BENEFICIARY_ID;
            dto.Code = entity.BeneficiaryEntity.CODE;
            dto.CustomerID = entity.BeneficiaryEntity.CUSTOMER_ID;
            dto.EmployeeID = entity.BeneficiaryEntity.EMPLOYEE_ID;
            dto.Name = entity.BeneficiaryEntity.NAME;
            dto.Mobile = entity.BeneficiaryEntity.MOBILE;
            dto.Email = entity.BeneficiaryEntity.EMAIL;
            dto.PIN = entity.BeneficiaryEntity.PIN;
            dto.LanguageID = entity.BeneficiaryEntity.LANGUAGE_ID;
            dto.IdentificationTypeID = entity.BeneficiaryEntity.IDENTIFICATION_TYPE_ID;
            dto.NationalID = entity.BeneficiaryEntity.NATIONAL_ID;
            dto.NationalityID = entity.BeneficiaryEntity.NATIONALILTY_ID;
            dto.NotificationChannelID = entity.BeneficiaryEntity.NOTIFICATION_CHANNEL_ID;
            dto.NotificationLanguageID = entity.BeneficiaryEntity.NOTIFICATION_LANGUAGE_ID;
            dto.FamilyID = entity.BeneficiaryEntity.FAMILY_ID;
            dto.GroupID = entity.BeneficiaryEntity.GROUP_ID;
            dto.BeneficiaryStatusID = entity.BeneficiaryEntity.BENEFICIARY_STATUS_ID;
            dto.BeneficiaryStatusReasonID = entity.BeneficiaryEntity.BENEFICIARY_STATUS_REASON_ID;
            dto.IsStatusInherited = Convert.ToBoolean(entity.BeneficiaryEntity.IS_STATUS_INHERITED);
            dto.LastUpdateUser = entity.BeneficiaryEntity.LAST_UPDATED_USER_ID;
            dto.LastUpdateDate = entity.BeneficiaryEntity.LAST_UPDATED_DATE;
            dto.LocationID = (int?)entity.BeneficiaryEntity.LAST_LOCATION_ID;
            dto.IsVIP = Convert.ToBoolean(entity.BeneficiaryEntity.IS_VIP);
            dto.IsActive = entity.BeneficiaryEntity.IS_ACTIVE == 1;
            dto.BasicAddressID = entity.BeneficiaryEntity.ADDRESS_ID;
            dto.BasicAddressDTO = entity.BeneficiaryEntity.ADDRESS == null ? null : entity.BeneficiaryEntity.ADDRESS.ToDTO();
            var bReceiptPref = new BeneficiaryAppService().GetBeneficiaryReceiptPreference(entity.BeneficiaryEntity.BENEFICIARY_ID);
            if (bReceiptPref == null)
                dto._BeneficiaryReceiptPreferenceDTO = new Lazy<BeneficiaryReceiptPreferenceDTO>(() => new BeneficiaryReceiptPreferenceDTO { BeneficiaryId = entity.BeneficiaryEntity.BENEFICIARY_ID, ReceiptTypeId = 3 });
            else
                dto._BeneficiaryReceiptPreferenceDTO = new Lazy<BeneficiaryReceiptPreferenceDTO>(() => bReceiptPref);

            dto.HasDisability = Convert.ToBoolean(entity.BeneficiaryEntity.IS_DISABILITY);
            dto.RegistrationDate = entity.BeneficiaryEntity.REGISTRATION_DATE;
            dto.Gender = entity.BeneficiaryEntity.GENDER;
            dto.IsDefaultBeneficiary = Convert.ToBoolean(entity.BeneficiaryEntity.IS_CUSTOMER_DEFAULT);
            dto.Birthday = entity.BeneficiaryEntity.DATEOFBIRTH;
            dto.RestrictionAllowedAmount = entity.RestrictionAllowedAmount;
            dto.RestrictionTimeFrequencyId = entity.RestrictionTimeFrequencyId;

            return dto;
        }

        public static CTBeneficiaryInfo ToCTEntity(this BeneficiaryDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBeneficiaryInfo();

            entity.BeneficiaryEntity = dto.ToEntity();
            entity.RestrictionTimeFrequencyId = dto.RestrictionTimeFrequencyId;
            entity.RestrictionAllowedAmount = dto.RestrictionAllowedAmount;

            return entity;
        }

        #endregion
    }
}