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
    
    public partial class CTSearchVoucherTRX
    {
        public Nullable<int> RECEIPT_ID { get; set; }
        public string TRANSACTIONTYPE { get; set; }
        public Nullable<decimal> TRANSACTION_AMOUNT { get; set; }
        public Nullable<decimal> TOTAL_AMOUNT { get; set; }
        public Nullable<int> IS_OFFLINE_TRANSACTION { get; set; }
        public Nullable<int> IS_DISABLE_BENEFICIARY { get; set; }
        public string EN_PAYMENT_METHOD { get; set; }
        public string CUSTOMER_NUMBER { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string AR_NUMBER { get; set; }
        public string BENEFICIARY_NUMBER { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string VOUCHER_SERIAL { get; set; }
        public string STATION_NAME { get; set; }
        public string PRODUCT_NAME { get; set; }
        public Nullable<decimal> PAID_AMOUNT { get; set; }
        public string TRANSACTION_DATE { get; set; }
        public Nullable<decimal> PRODUCT_QUANTITY { get; set; }
        public Nullable<decimal> PRODUCT_PRICE { get; set; }
        public string VAT_INVOICE_NO { get; set; }
        public string EXT_VOUCHER_NO { get; set; }
        public string FinancialAccountName { get; set; }
        public string SiteName { get; set; }
    }
}