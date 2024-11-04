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
    
    public partial class RESTRICTION_GROUP
    {
        public RESTRICTION_GROUP()
        {
            this.RESTRICTION_GROUP_DATE = new HashSet<RESTRICTION_GROUP_DATE>();
            this.RESTRICTION_GROUP_PRODUCT = new HashSet<RESTRICTION_GROUP_PRODUCT>();
            this.RESTRICTION_GROUP_WEEKDAY = new HashSet<RESTRICTION_GROUP_WEEKDAY>();
            this.RESTRICTION_GROUP_STATIONS = new HashSet<RESTRICTION_GROUP_STATIONS>();
            this.RESTRICTION_GROUP_TOKEN = new HashSet<RESTRICTION_GROUP_TOKEN>();
            this.RESTRICTION_GROUP_QUANTITY = new HashSet<RESTRICTION_GROUP_QUANTITY>();
            this.RESTRICTION_GROUP_AMOUNT = new HashSet<RESTRICTION_GROUP_AMOUNT>();
            this.RESTRICTION_GROUP_TRANS_NO = new HashSet<RESTRICTION_GROUP_TRANS_NO>();
            this.RESTRICTION_GROUP_TRANSACTION = new HashSet<RESTRICTION_GROUP_TRANSACTION>();
        }
    
        public int RESTRICTION_GROUP_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> CONSECUTIVE_USAGE_RESTRICTION { get; set; }
        public Nullable<short> IS_RESTRICTED_IN_HOLIDAY { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<short> IS_SYSTEM_DEFINED_GROUP { get; set; }
        public Nullable<short> IS_REQUIRE_ODOMETER_INPUT { get; set; }
        public Nullable<short> IS_REQUIRE_DRIVER_CARD { get; set; }
        public Nullable<short> CAN_BUY_DRY_STOCK { get; set; }
        public Nullable<short> IS_OTHER_RESTRICTIONS_ACTIVE { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public Nullable<short> CAN_USE_SERVICE { get; set; }
    
        public virtual ICollection<RESTRICTION_GROUP_DATE> RESTRICTION_GROUP_DATE { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_PRODUCT> RESTRICTION_GROUP_PRODUCT { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_WEEKDAY> RESTRICTION_GROUP_WEEKDAY { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_STATIONS> RESTRICTION_GROUP_STATIONS { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_TOKEN> RESTRICTION_GROUP_TOKEN { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_QUANTITY> RESTRICTION_GROUP_QUANTITY { get; set; }
        public virtual RESTRICTION_GROUP_TIME RESTRICTION_GROUP_TIME { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_AMOUNT> RESTRICTION_GROUP_AMOUNT { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_TRANS_NO> RESTRICTION_GROUP_TRANS_NO { get; set; }
        public virtual ICollection<RESTRICTION_GROUP_TRANSACTION> RESTRICTION_GROUP_TRANSACTION { get; set; }
    }
}
