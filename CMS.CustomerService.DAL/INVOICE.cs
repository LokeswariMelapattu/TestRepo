//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DUC.CMS.CustomerService.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVOICE
    {
        public INVOICE()
        {
            this.INVOICE_STATUS_HISTORY = new HashSet<INVOICE_STATUS_HISTORY>();
            this.CUSTOMER_PAYMENT = new HashSet<CUSTOMER_PAYMENT>();
        }
    
        public int INVOICE_ID { get; set; }
        public string INVOICE_NUMBER { get; set; }
        public int CUSTOMER_ID { get; set; }
        public decimal INVOICE_VALUE { get; set; }
        public Nullable<System.DateTime> DUE_DATE { get; set; }
        public System.DateTime ISSUANCE_DATE { get; set; }
        public System.DateTime PAYMENT_DATE { get; set; }
        public int STATUS_ID { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<System.DateTime> DATE_FROM { get; set; }
        public Nullable<System.DateTime> DATE_TO { get; set; }
        public Nullable<short> IS_SETTLED { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public Nullable<decimal> PAID_AMOUNT { get; set; }
        public Nullable<decimal> ONLINE_ADJUSTMENT { get; set; }
        public Nullable<decimal> EOM_ADJUSTMENT { get; set; }
        public Nullable<decimal> INVOICE_TRANSACTIONS_VALUE { get; set; }
        public Nullable<decimal> INVOICE_SERVICES_VALUE { get; set; }
        public string SOURCE_REFERENCE_NUMBER { get; set; }
        public Nullable<short> IS_INVOICE_SENT { get; set; }
        public Nullable<decimal> CREDIT_AMOUNT { get; set; }
        public Nullable<decimal> VAT_AMOUNT { get; set; }
        public Nullable<decimal> TRANSACTIONS_VAT_AMOUNT { get; set; }
        public Nullable<decimal> SERVICES_VAT_AMOUNT { get; set; }
        public Nullable<decimal> CREDIT_VAT_AMOUNT { get; set; }
        public Nullable<short> BILLING_TYPE_ID { get; set; }
    
        public virtual ICollection<INVOICE_STATUS_HISTORY> INVOICE_STATUS_HISTORY { get; set; }
        public virtual INVOICE_STATUS INVOICE_STATUS { get; set; }
        public virtual ICollection<CUSTOMER_PAYMENT> CUSTOMER_PAYMENT { get; set; }
    }
}
