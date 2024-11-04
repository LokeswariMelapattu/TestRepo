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
    
    public partial class TIME_FREQUENCY
    {
        public TIME_FREQUENCY()
        {
            this.CUSTOMER = new HashSet<CUSTOMER>();
            this.RESTRICTION_GROUP_QUANTITY = new HashSet<RESTRICTION_GROUP_QUANTITY>();
            this.RESTRICTION_GROUP_AMOUNT = new HashSet<RESTRICTION_GROUP_AMOUNT>();
            this.RESTRICTION_GROUP_TRANS_NO = new HashSet<RESTRICTION_GROUP_TRANS_NO>();
        }
    
        public int TIME_FREQUENCY_ID { get; set; }
        public string EN_NAME { get; set; }
        public short IS_ACTIVE { get; set; }
        public string AR_NAME { get; set; }
        public Nullable<decimal> DURATION { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual ICollection<CUSTOMER> CUSTOMER { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_QUANTITY> RESTRICTION_GROUP_QUANTITY { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_AMOUNT> RESTRICTION_GROUP_AMOUNT { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_TRANS_NO> RESTRICTION_GROUP_TRANS_NO { get; set; }
    }
}