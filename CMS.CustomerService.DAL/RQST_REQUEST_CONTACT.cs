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
    
    public partial class RQST_REQUEST_CONTACT
    {
        public RQST_REQUEST_CONTACT()
        {
            this.RQST_REQUEST_CUSTOMER_CONTACT = new HashSet<RQST_REQUEST_CUSTOMER_CONTACT>();
        }
    
        public int REQUEST_CONTACT_ID { get; set; }
        public string NAME { get; set; }
        public string MOBILE { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public Nullable<int> NOTIFICATION_LANGUAGE_ID { get; set; }
        public Nullable<int> NOTIFICATION_CHANNEL_ID { get; set; }
        public Nullable<short> IS_ACTIVE { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public string CODE { get; set; }
        public string PIN { get; set; }
    
        public virtual ICollection<RQST_REQUEST_CUSTOMER_CONTACT> RQST_REQUEST_CUSTOMER_CONTACT { get; set; }
        public virtual USERS USERS { get; set; }
    }
}
