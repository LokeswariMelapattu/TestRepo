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
    
    public partial class PERSONALIZATION_ORDER
    {
        public int PERSONALIZATION_ORDER_ID { get; set; }
        public string PERSONALIZATION_NUMBER { get; set; }
        public Nullable<System.DateTime> APPOINTMENT_DATE_TIME { get; set; }
        public Nullable<System.DateTime> ACTUAL_SERVICE_DATE_TIME { get; set; }
        public int PASSED_QUALITY_TEST { get; set; }
        public Nullable<int> PERSONALIZATION_REASON_ID { get; set; }
        public short IS_ACTIVE { get; set; }
        public string IDENTITY_NUMBER { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
    
        public virtual CARD_CENTER CARD_CENTER { get; set; }
        public virtual IDENTIFICATION_TYPE IDENTIFICATION_TYPE { get; set; }
        public virtual PERSONALIZATION_ORDER_STATUS PERSONALIZATION_ORDER_STATUS { get; set; }
        public virtual PERSONALIZATION_ORDER_TYPE PERSONALIZATION_ORDER_TYPE { get; set; }
        public virtual PRINTER PRINTER { get; set; }
    }
}