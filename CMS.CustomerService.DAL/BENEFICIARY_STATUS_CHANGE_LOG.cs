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
    
    public partial class BENEFICIARY_STATUS_CHANGE_LOG
    {
        public int STATUS_CHANGE_LOG_ID { get; set; }
        public int BENEFICIARY_ID { get; set; }
        public int BENEFICIARY_STATUS_ID { get; set; }
        public Nullable<int> BENEFICIARY_STATUS_REASON_ID { get; set; }
        public System.DateTime STATUS_CHANGE_DATE_TIME { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual BENEFICIARY_STATUS BENEFICIARY_STATUS { get; set; }
        public virtual BENEFICIARY_STATUS_REASON BENEFICIARY_STATUS_REASON { get; set; }
        public virtual USERS USERS { get; set; }
    }
}