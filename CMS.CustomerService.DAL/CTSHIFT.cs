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
    
    public partial class CTSHIFT
    {
        public Nullable<int> SHIFT_ID { get; set; }
        public Nullable<int> SHIFT_TYPE_ID { get; set; }
        public string SHIFT_TYPE { get; set; }
        public Nullable<int> SHIFT_STATUS_ID { get; set; }
        public string SHIFT_STATUS { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public Nullable<int> LOCATION_ID { get; set; }
        public string LOCATION_NAME { get; set; }
        public Nullable<System.DateTime> START_DATETIME { get; set; }
        public Nullable<System.DateTime> END_DATETIME { get; set; }
    }
}
