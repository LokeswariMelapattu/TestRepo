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
    
    public partial class CTServiceFee
    {
        public int Service_ID { get; set; }
        public int Customer_Status_ID { get; set; }
        public int Customer_Type_ID { get; set; }
        public int Account_Type_ID { get; set; }
        public int Classification_ID { get; set; }
        public int ISPremier { get; set; }
        public Nullable<int> Location_ID { get; set; }
        public Nullable<int> Service_fee_ID { get; set; }
        public int IsActive { get; set; }
        public decimal Fee { get; set; }
        public int LastLocationID { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatesUserID { get; set; }
    }
}