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
    
    public partial class CTConsumedAmountResult
    {
        public int RESTRICTION_GROUP_ID { get; set; }
        public int TIME_FREQUENCY_ID { get; set; }
        public string EN_NAME { get; set; }
        public string AR_NAME { get; set; }
        public Nullable<decimal> DAILY_USED_AMOUNT { get; set; }
        public Nullable<decimal> WEEKLY_USED_AMOUNT { get; set; }
        public Nullable<decimal> MONTHLY_USED_AMOUNT { get; set; }
        public Nullable<decimal> YEARLY_USED_AMOUNT { get; set; }
        public bool IS_ACTIVE { get; set; }
        public int PRODUCT_CATEGORY_ID { get; set; }
    }
}
