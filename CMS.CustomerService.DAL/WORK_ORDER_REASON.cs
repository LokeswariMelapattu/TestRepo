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
    
    public partial class WORK_ORDER_REASON
    {
        public WORK_ORDER_REASON()
        {
            this.WORK_ORDER = new HashSet<WORK_ORDER>();
        }
    
        public int WORK_ORDER_REASON_ID { get; set; }
        public string EN_NAME { get; set; }
        public string AR_NAME { get; set; }
        public short IS_ACTIVE { get; set; }
        public int WORK_ORDER_TYPE_ID { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual WORK_ORDER_TYPE WORK_ORDER_TYPE { get; set; }
        public virtual ICollection<WORK_ORDER> WORK_ORDER { get; set; }
    }
}
