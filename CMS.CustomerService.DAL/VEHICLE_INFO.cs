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
    
    public partial class VEHICLE_INFO
    {
        public VEHICLE_INFO()
        {
            this.TOKEN = new HashSet<TOKEN>();
            this.WORK_ORDER = new HashSet<WORK_ORDER>();
        }
    
        public int VEHICLE_INFO_ID { get; set; }
        public string PLATE_NUMBER { get; set; }
        public Nullable<int> COLOR_ID { get; set; }
        public string PLATE_COLOUR_ID { get; set; }
        public Nullable<int> STATE_ID { get; set; }
        public string CHASSIS_NUMBER { get; set; }
        public Nullable<int> VEHICLE_REGISTER_ID { get; set; }
        public Nullable<int> VEHICLE_TYPE_ID { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public string ENGINE_NUMBER { get; set; }
    
        public virtual ICollection<TOKEN> TOKEN { get; set; }
        public virtual VEHICLE_COLOR VEHICLE_COLOR { get; set; }
        public virtual VEHICLE_STATE VEHICLE_STATE { get; set; }
        public virtual VEHICLE_TYPE VEHICLE_TYPE { get; set; }
        public virtual VEHICLE_REGISTER VEHICLE_REGISTER { get; set; }
        public virtual ICollection<WORK_ORDER> WORK_ORDER { get; set; }
    }
}