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
    
    public partial class SHIFT
    {
        public int SHIFT_ID { get; set; }
        public Nullable<int> SHIFT_TYPE_ID { get; set; }
        public Nullable<int> SHIFT_STATUS_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public Nullable<int> LOCATION_ID { get; set; }
        public Nullable<System.DateTime> START_DATETIME { get; set; }
        public Nullable<System.DateTime> END_DATETIME { get; set; }
        public Nullable<int> SHIFTENDED_BY { get; set; }
        public decimal IS_ACTIVE { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual LOCATION LOCATION { get; set; }
        public virtual SHIFT_STATUS SHIFT_STATUS { get; set; }
        public virtual SHIFT_TYPE SHIFT_TYPE { get; set; }
        public virtual USERS USERS { get; set; }
        public virtual USERS USERS1 { get; set; }
    }
}