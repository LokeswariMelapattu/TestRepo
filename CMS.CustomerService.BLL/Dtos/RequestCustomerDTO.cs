﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestCustomerDTO : BaseDTO
    {
        [DataMember]
        public int? RequestCustomerId { get; set; }
        [DataMember]
        public int? RequestID { get; set; }
        [DataMember]
        public int? NationalityID { get; set; }
        [DataMember]
        public string CompanyID { get; set; }
        [DataMember]
        public int? BasicAddressId { get; set; }
        [DataMember]
        public int? BillingAddressId { get; set; }
        [DataMember]
        public int? ShippingAddressId { get; set; }
        [DataMember]
        public string IdentificationType { get; set; }
        [DataMember]
        public int? IdentificationTypeID { get; set; }
        [DataMember]
        public int? CustomerTypeID { get; set; }
        [DataMember]
        public int? AccountTypeID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NationalID { get; set; }
        [DataMember]
        public int? ClassificationId { get; set; }
        [DataMember]
        public int? OperationalContactID { get; set; }
        [DataMember]
        public int? FinancialContactID { get; set; }
        [DataMember]
        public string ReceiptPreference { get; set; }
        [DataMember]
        public int? InvoiceTypeID { get; set; }
        [DataMember]
        public int? FamilyID { get; set; }
        [DataMember]
        public int? FinancialAccountTypeID { get; set; }
        [DataMember]
        public string FinancialAccountType { get; set; }
        [DataMember]
        public string FinancialAccountNo { get; set; }
        [DataMember]
        public int? AccountManagerID { get; set; }
        [DataMember]
        public int? BillingFrequencyID { get; set; }
        [DataMember]
        public int? NotificationThreshold { get; set; }
        [DataMember]
        public int? SuspensionThreshold { get; set; }
        [DataMember]
        public int? IsVIP { get; set; }
        [DataMember]
        public int? IsPremier { get; set; }
        [DataMember]
        public int? NotificationLanguageID { get; set; }
        [DataMember]
        public int? NotificationChannelID { get; set; }
        [DataMember]
        public int? RequestSourceTypeID { get; set; }
        [DataMember]
        public int? CardCentreID { get; set; }
        [DataMember]
        public int? UnitID { get; set; }
        [DataMember]
        public int? PaymentTerms { get; set; }
        [DataMember]
        public int? BillingFrequencyDayOrder { get; set; }
        [DataMember]
        public bool EnableDefaultBeneficiary { get; set; }
        [DataMember]
        public int? MonthlyVolumeID { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }


        [DataMember]
        public RequestCustomerAddressDTO BasicAddress { get; set; }
        [DataMember]
        public RequestCustomerAddressDTO BillingAddress { get; set; }
        [DataMember]
        public RequestCustomerAddressDTO ShippingAddress { get; set; }
        [DataMember]
        public RequestAccountManagerDTO AccountManager { get; set; }
        [DataMember]
        public RequestDTO Request { get; set; }
        [DataMember]
        public List<RequestCustomerContactsDTO> customerContact { get; set; }
        [DataMember]
        public CustomerReceiptPreferenceDTO CustomerReceiptPreference { get; set; }
        [DataMember]
        public bool IsEmployer { get; set; }
        [DataMember()]
        public Nullable<Int32> CustomBillFrequency { get; set; }
        [DataMember()]
        public string ContractNumber { get; set; }
    }
}