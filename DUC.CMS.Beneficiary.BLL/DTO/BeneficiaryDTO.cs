using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class BeneficiaryDTO : BaseDTO
    {
        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public Nullable<int> EmployeeID { get; set; }

        [DataMember]
        public Nullable<int> GroupID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PIN { get; set; }

        [DataMember]
        public int LanguageID { get; set; }

        [DataMember]
        public Nullable<int> IdentificationTypeID { get; set; }

        [DataMember]
        public string NationalID { get; set; }

        [DataMember]
        public Nullable<int> NationalityID { get; set; }

        [DataMember]
        public Nullable<int> BasicAddressID { get; set; }

        public Lazy<AddressDTO> _AddressDTO = null;

        private AddressDTO _Address = null;

        [DataMember]
        public AddressDTO BasicAddressDTO
        {
            get
            {
                if (_AddressDTO == null)
                {
                    if (_Address != null)
                    {
                        return this._Address;
                    }
                    return null;
                }
                else
                {
                    return _AddressDTO.Value;
                }
            }
            set
            {
                this._Address = value;
            }
        }

        [DataMember]
        public Nullable<int> NotificationChannelID { get; set; }

        [DataMember]
        public Nullable<int> NotificationLanguageID { get; set; }

        [DataMember]
        public Nullable<int> FamilyID { get; set; }

        [DataMember]
        public int CustomerUnitID { get; set; }

        [DataMember]
        public int BeneficiaryStatusID { get; set; }

        [DataMember]
        public Nullable<int> BeneficiaryStatusReasonID { get; set; }

        [DataMember]
        public bool IsStatusInherited { get; set; }

        [DataMember]
        public bool IsVIP { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool HasDisability { get; set; }

        public Lazy<BeneficiaryReceiptPreferenceDTO> _BeneficiaryReceiptPreferenceDTO = null;

        private BeneficiaryReceiptPreferenceDTO _BeneficiaryReceiptPreference = null;

        [DataMember]
        public BeneficiaryReceiptPreferenceDTO BeneficiaryReceiptPreferenceDTO
        {
            get
            {
                if (_BeneficiaryReceiptPreferenceDTO == null)
                {
                    if (_BeneficiaryReceiptPreference != null)
                    {
                        return this._BeneficiaryReceiptPreference;
                    }
                    return null;
                }
                else
                {
                    return _BeneficiaryReceiptPreferenceDTO.Value;
                }
            }
            set
            {
                this._BeneficiaryReceiptPreference = value;
            }
        }

        [DataMember]
        public DateTime? RegistrationDate { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public bool IsDefaultBeneficiary { get; set; }


        [DataMember]
        public DateTime? Birthday { get; set; }

        [DataMember]
        public int? RestrictionTimeFrequencyId { get; set; }

        [DataMember]
        public decimal? RestrictionAllowedAmount { get; set; }
    }
}
