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
    
    public partial class CTWorkOrder
    {
        public Nullable<int> TOKEN_ID { get; set; }
        public Nullable<int> WORK_ORDER_ID { get; set; }
        public string WORK_ORDER_NUMBER { get; set; }
        public Nullable<int> WORK_ORDER_STATUS_ID { get; set; }
        public Nullable<int> WORK_ORDER_STATUS_REASON_ID { get; set; }
        public Nullable<int> VEHICLE_INFO_ID { get; set; }
        public Nullable<int> VEHICLE_DEPOT_ID { get; set; }
        public Nullable<System.DateTime> APPOINTMENT_DATETIME { get; set; }
        public Nullable<System.DateTime> SERVICE_DATETIME { get; set; }
        public Nullable<int> WORK_ORDER_TYPE_ID { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public string RECIPIENT_ID_NUMBER { get; set; }
        public Nullable<int> RECIPIENT_TYPE_ID { get; set; }
        public Nullable<int> LastLocationID { get; set; }
        public Nullable<System.DateTime> APPOINTMENT_TILL_DATETIME { get; set; }
    }
}