
using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerARDTO : BaseDTO
    {
        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public String CustomerName { get; set; }


        [DataMember()]
        public Nullable<decimal> BillingAddressID { get; set; }

        [DataMember()]
        public String BillingAddress { get; set; }

        [DataMember()]
        public Nullable<Int32> AccountStatus { get; set; }

        [DataMember()]
        public Nullable<Decimal> Customer_Class { get; set; }

        [DataMember()]
        public Nullable<DateTime> RegistrationDate { get; set; }

        [DataMember()]
        public String AccPrimaryContactName { get; set; }

        [DataMember()]
        public Nullable<Int64> AccNationalID { get; set; }

        [DataMember()]
        public Nullable<decimal> AccountManagerID { get; set; }

        [DataMember()]
        public String AccountManager { get; set; }

        [DataMember()]
        public String AccManagerEmail { get; set; }

        [DataMember()]
        public string AccManagerPhone { get; set; }

        [DataMember()]
        public String AccManagerJobTitle { get; set; }

        [DataMember()]
        public string FinancialAccountNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> CustomerAccountTypeID { get; set; }

        [DataMember()]
        public String CustomerAccountType { get; set; }

        [DataMember()]
        public String CustomerAccountTypeAR { get; set; }

        [DataMember()]
        public String AccManagerMobile { get; set; }

        [DataMember()]
        public String AccManagerFax { get; set; }

        [DataMember()]
        public Nullable<Int32> CorporateAddressID { get; set; }

        [DataMember()]
        public String CorporateAddress { get; set; }

        [DataMember()]
        public Nullable<Int32> CorporateAddressEmirateID { get; set; }

        [DataMember()]
        public String CorporateAddressEmirate { get; set; }

        [DataMember()]
        public Nullable<Int32> CorporateAddressAreaID { get; set; }

        [DataMember()]
        public String CorporateAddressArea { get; set; }

        [DataMember()]
        public String CorporateAddressPhone { get; set; }

        [DataMember()]
        public String CorporateAddressFax { get; set; }

        [DataMember()]
        public Nullable<Decimal> SuspensionThreshold { get; set; }

        [DataMember()]
        public Nullable<Int32> BillingAddressEmirateID { get; set; }

        [DataMember()]
        public String BillingAddressEmirate { get; set; }

        [DataMember()]
        public Nullable<Int32> BillingAddressAreaID { get; set; }

        [DataMember()]
        public String BillingAddressArea { get; set; }

        [DataMember()]
        public String BillingAddressPhone { get; set; }

        [DataMember()]
        public String BillingAddressFax { get; set; }

        [DataMember()]
        public Nullable<Int32> ShippingAddressID { get; set; }

        [DataMember()]
        public String ShippingAddress { get; set; }

        [DataMember()]
        public Nullable<Int32> ShippingAddressEmirateID { get; set; }

        [DataMember()]
        public String ShippingAddressEmirate { get; set; }

        [DataMember()]
        public Nullable<Int32> ShippingAddressAreaID { get; set; }

        [DataMember()]
        public String ShippingAddressArea { get; set; }

        [DataMember()]
        public String ShippingAddressPhone { get; set; }

        [DataMember()]
        public String ShippingAddressFax { get; set; }

        [DataMember()]
        public int? PaymentTerms { get; set; }

        [DataMember()]
        public int? ISMULTIPLEBILLTODETAILS { get; set; }
        [DataMember()]
        public int? MAXCREDITLIMIT { get; set; }
        [DataMember()]
        public String CorporateAddressEmirate_Ar { get; set; }
        [DataMember()]
        public String CorporateAddressArea_Ar { get; set; }
        [DataMember()]
        public String BillingAddressEmirate_Ar { get; set; }
        [DataMember()]
        public String BillingAddressArea_Ar { get; set; }
        [DataMember()]
        public String ShippingAddressEmirate_Ar { get; set; }
        [DataMember()]
        public String ShippingAddressArea_Ar { get; set; }
        [DataMember()]
        public string CompanyRegistrationNo { get; set; }
        
    }
}
