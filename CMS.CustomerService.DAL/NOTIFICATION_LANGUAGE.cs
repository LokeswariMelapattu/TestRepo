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
    
    public partial class NOTIFICATION_LANGUAGE
    {
        public NOTIFICATION_LANGUAGE()
        {
            this.CONTACT = new HashSet<CONTACT>();
            this.CUSTOMER = new HashSet<CUSTOMER>();
            this.BENEFICIARies = new HashSet<BENEFICIARY>();
        }
    
        public int NOTIFICATION_LANGUAGE_ID { get; set; }
        public string EN_NAME { get; set; }
        public short IS_ACTIVE { get; set; }
        public string AR_NAME { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual ICollection<CONTACT> CONTACT { get; set; }
        public virtual ICollection<CUSTOMER> CUSTOMER { get; set; }
        public virtual ICollection<BENEFICIARY> BENEFICIARies { get; set; }
    }
}
