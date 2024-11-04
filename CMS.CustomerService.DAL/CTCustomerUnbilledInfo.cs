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
    
    public partial class CTCustomerUnbilledInfo
    {
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<int> BENEFICIARY_ID { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public Nullable<int> TRANSACTION_ID { get; set; }
        public Nullable<int> TOKEN_TYPE_ID { get; set; }
        public string Token_Type { get; set; }
        public Nullable<int> STATION_ID { get; set; }
        public string STATION_NAME { get; set; }
        public Nullable<int> PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string SERIAL { get; set; }
        public Nullable<int> GROUP_ID { get; set; }
        public Nullable<System.DateTime> TRANSACTION_DATE_TIME { get; set; }
        public Nullable<decimal> TRANSACTION_AMOUNT { get; set; }
        public Nullable<decimal> Adjustment { get; set; }
        public Nullable<decimal> PAID_AMOUNT { get; set; }
        public Nullable<System.DateTime> LastBilledDate { get; set; }
        public string PRODUCT_NAME_AR { get; set; }
        public string Token_Type_AR { get; set; }
        public string STATION_NAME_AR { get; set; }
        public string EOM_DP_RILE_NAME { get; set; }
        public Nullable<int> EOM_DP_RULE_ID { get; set; }
        public Nullable<int> ONLINE_DP_RULE_ID { get; set; }
        public string ONLINE_DP_RULE_NAME { get; set; }
        public string VAT_INV_NUM { get; set; }
        public string VAT_Code { get; set; }
        public Nullable<double> VAT_Rate { get; set; }
        public Nullable<double> VAT_Amount { get; set; }
    }
}
