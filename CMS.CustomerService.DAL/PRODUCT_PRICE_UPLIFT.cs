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
    
    public partial class PRODUCT_PRICE_UPLIFT
    {
        public PRODUCT_PRICE_UPLIFT()
        {
            this.CUSTOMER_PRODUCT_UPLIFT = new HashSet<CUSTOMER_PRODUCT_UPLIFT>();
        }
    
        public int UPLIFT_ID { get; set; }
        public Nullable<decimal> MONTHLY_QUANTITY { get; set; }
        public Nullable<decimal> UPLIFT_DISCOUNT_PERCENTAGE { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<short> IS_SYSTEM_DEFINED { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual ICollection<CUSTOMER_PRODUCT_UPLIFT> CUSTOMER_PRODUCT_UPLIFT { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
