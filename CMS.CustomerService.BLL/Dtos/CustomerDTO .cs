
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerDTO : BaseDTO
    {
        [DataMember()]
        public Int32? CustomerID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public Int32 CustomerTypeID { get; set; }

        [DataMember()]
        public string CompanyID { get; set; }

        [DataMember()]
        public Nullable<Int32> ClassificationID { get; set; }

        [DataMember()]
        public Int32 AccountTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> NationalityID { get; set; }

        [DataMember()]
        public String NationalID { get; set; }

        [DataMember()]
        public Nullable<Int32> BasicAddressID { get; set; }

        [DataMember()]
        public Nullable<Int32> BillingAddressID { get; set; }

        [DataMember()]
        public Nullable<Int32> ShippingAddressID { get; set; }

        [DataMember()]
        public Nullable<Int32> FamilyID { get; set; }

        [DataMember()]
        public Nullable<Int32> FinancialAccountTypeID { get; set; }

        [DataMember()]
        public String FinancialAccountNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> AccountManagerID { get; set; }

        [DataMember()]
        public Nullable<Int32> BillingFrequencyID { get; set; }

        [DataMember()]
        public Nullable<Int32> FinancialContactID { get; set; }

        [DataMember()]
        public Nullable<Int32> OperationalContactID { get; set; }

        [DataMember()]
        public Nullable<Decimal> NotificationThreshold { get; set; }

        [DataMember()]
        public Nullable<Decimal> SuspensionThreshold { get; set; }

        [DataMember()]
        public bool IsVIP { get; set; }

        [DataMember()]
        public DateTime RegistrationDate { get; set; }

        [DataMember()]
        public Int32 StatusID { get; set; }

        [DataMember()]
        public Int32? StatusReasonID { get; set; }

        [DataMember()]
        public String PIN { get; set; }

        [DataMember()]
        public Int32 NotificationLanguageID { get; set; }

        [DataMember()]
        public Int32 NotificatonChannelID { get; set; }

        [DataMember()]
        public Int32? RequestSourceTypeID { get; set; }

        [DataMember()]
        public String CardCenterID { get; set; }

        [DataMember()]
        public Nullable<Int32> UnitID { get; set; }

        [DataMember()]
        public Nullable<Int32> BillingFrequencyDayOrder { get; set; }

        [DataMember()]
        public Nullable<Int32> PaymentTerms { get; set; }

        [DataMember()]
        public Nullable<Int32> IdentificationTypeID { get; set; }

        [DataMember()]
        public List<CustomerContactDTO> CustomerContact { get; set; }

        [DataMember()]
        public List<UpliftDiscountDTO> ProductPriceUplift { get; set; }

        [DataMember()]
        public CustomerReceiptPreferenceDTO CustomerReceiptPreference { get; set; }

        [DataMember()]
        public List<CustomerPINLogDTO> CustomerPinLog { get; set; }

        [DataMember]
        public AccountManagerDTO AccountManager { get; set; }

        [DataMember]
        public AddressDTO BaseAddress { get; set; }

        [DataMember]
        public AddressDTO BillingAddress { get; set; }

        [DataMember]
        public AddressDTO ShippingAddress { get; set; }

        [DataMember()]
        public String FinancialAccountType { get; set; }

        [DataMember()]
        public bool isPrimier { get; set; }

        [DataMember()]
        public int? FinancialStartYear { get; set; }

        [DataMember()]
        public String Trn { get; set; }

        [DataMember()]
        public bool IsVatExempted { get; set; }

        [DataMember()]
        public String ExemptionReason { get; set; }

        [DataMember()]
        public String CompanyRegistrationNo { get; set; }
        [DataMember()]
        public bool IsBeneficiaryIdNonUnique { get; set; }
        [DataMember()]
        public Nullable<Int32> CustomBillFrequency { get; set; }
        [DataMember()]
        public bool IsEmployer { get; set; }
        [DataMember()]
        public string ContractNumber { get; set; }
    }
}
