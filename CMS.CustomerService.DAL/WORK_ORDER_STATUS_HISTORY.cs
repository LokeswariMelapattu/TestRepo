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
    
    public partial class WORK_ORDER_STATUS_HISTORY
    {
        public int WORK_ORDER_ID { get; set; }
        public int WORK_ORDER_STATUS_ID { get; set; }
        public System.DateTime STATUS_CHANGE_DATE_TIME { get; set; }
    
        public virtual WORK_ORDER_STATUS WORK_ORDER_STATUS { get; set; }
        public virtual WORK_ORDER WORK_ORDER { get; set; }
    }
}