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
    
    public partial class CTTransactionSearch
    {
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<int> BENEFICIARY_ID { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public Nullable<System.DateTime> TRANS_FROM_DATE { get; set; }
        public Nullable<System.DateTime> TRANS_TO_DATE { get; set; }
        public Nullable<int> TOKEN_TYPE_ID { get; set; }
        public string TOKEN_TYPE { get; set; }
        public Nullable<int> STATION_ID { get; set; }
        public Nullable<int> PRODUCT_ID { get; set; }
        public string SERIAL { get; set; }
        public Nullable<int> GROUP_ID { get; set; }
        public Nullable<System.DateTime> TRANSACTION_DATE { get; set; }
        public Nullable<decimal> TRANSACTION_AMOUNT { get; set; }
        public Nullable<decimal> TRANSACTION_ADJUSTMENT { get; set; }
        public Nullable<decimal> TRANSACTION_PAID_AMOUNT { get; set; }
        public string StationNameEn { get; set; }
        public string ProductNameEn { get; set; }
        public string TOKEN_TYPE_AR { get; set; }
        public string StationNameAr { get; set; }
        public string ProductNameAr { get; set; }
        public string BENEFICIARY_CODE { get; set; }
        public string UnitPrice { get; set; }
        public string BeneficiaryGroup { get; set; }
        public Nullable<int> ONLINE_DP_RULE_ID { get; set; }
        public Nullable<int> EOM_DP_RULE_ID { get; set; }
        public string ONLINE_DP_RULE_NAME { get; set; }
        public string EOM_DP_RILE_NAME { get; set; }
        public string VAT_INV_NUM { get; set; }
        public string VAT_Code { get; set; }
        public Nullable<double> VAT_Amount { get; set; }
        public Nullable<decimal> TRANSACTION_ID { get; set; }
        public string SERVICE_OR_PROD_NAME { get; set; }
        public string VAT_Rate { get; set; }
    }
}
