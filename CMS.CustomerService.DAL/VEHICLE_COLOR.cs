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
    
    public partial class VEHICLE_COLOR
    {
        public VEHICLE_COLOR()
        {
            this.VEHICLE_INFO = new HashSet<VEHICLE_INFO>();
        }
    
        public int VEHICLE_COLOR_ID { get; set; }
        public string EN_VEHICLE_COLOR { get; set; }
        public short IS_ACTIVE { get; set; }
        public string AR_VEHICLE_COLOR { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual ICollection<VEHICLE_INFO> VEHICLE_INFO { get; set; }
    }
}