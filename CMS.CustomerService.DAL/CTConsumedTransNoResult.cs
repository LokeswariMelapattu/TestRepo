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
    
    public partial class CTConsumedTransNoResult
    {
        public int RESTRICTION_GROUP_ID { get; set; }
        public Nullable<int> NUMBER_OF_DAYS { get; set; }
        public Nullable<int> NUMBER_OF_TRANSACTIONS { get; set; }
        public int TIME_FREQUENCY_ID { get; set; }
        public Nullable<int> IS_ACTIVE { get; set; }
        public Nullable<int> DAILY_USED_TRANS_COUNT { get; set; }
        public Nullable<int> MONTHLY_USED_TRANS_COUNT { get; set; }
        public Nullable<int> WEEKLY_USED_TRANS_COUNT { get; set; }
        public Nullable<int> YEARLY_USED_TRANS_COUNT { get; set; }
        public string FREQUENCY_EN_NAME { get; set; }
        public string FREQUENCY_AN_NAME { get; set; }
        public int PRODUCT_CATEGORY_ID { get; set; }
    }
}
