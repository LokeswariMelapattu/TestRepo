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
    
    public partial class RESTRICTION_GROUP_AMOUNT
    {
        public int RESTRICTION_GROUP_ID { get; set; }
        public int TIME_FREQUENCY_ID { get; set; }
        public Nullable<decimal> ALLOWED_AMOUNT { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public Nullable<short> IS_DRY_RESTRICTION { get; set; }
        public decimal PRODUCT_CATEGORY_ID { get; set; }
    
        public virtual RESTRICTION_GROUP RESTRICTION_GROUP { get; set; }
        public virtual TIME_FREQUENCY TIME_FREQUENCY { get; set; }
    }
}
