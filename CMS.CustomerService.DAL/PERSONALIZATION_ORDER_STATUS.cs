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
    
    public partial class PERSONALIZATION_ORDER_STATUS
    {
        public PERSONALIZATION_ORDER_STATUS()
        {
            this.PERSONALIZATION_ORDER_REASON = new HashSet<PERSONALIZATION_ORDER_REASON>();
            this.PERSONALIZATION_ORDER = new HashSet<PERSONALIZATION_ORDER>();
        }
    
        public int PERSONALIZATION_STATUS_ID { get; set; }
        public string EN_NAME { get; set; }
        public short IS_ACTIVE { get; set; }
        public string AR_NAME { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual ICollection<PERSONALIZATION_ORDER_REASON> PERSONALIZATION_ORDER_REASON { get; set; }
        public virtual ICollection<PERSONALIZATION_ORDER> PERSONALIZATION_ORDER { get; set; }
    }
}
