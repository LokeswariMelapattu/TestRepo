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
    
    public partial class CTRequestWorkOrder
    {
        public Nullable<int> RequestId { get; set; }
        public Nullable<int> TokenTypeID { get; set; }
        public Nullable<int> AuthPersonIDType { get; set; }
        public Nullable<int> VehicleInfoID { get; set; }
        public Nullable<int> PreferredLocationId { get; set; }
        public string BeneficiaryCode { get; set; }
        public string BeneficiaryName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string TokenCode { get; set; }
        public string TokenName { get; set; }
        public string AuthPersonIDNumber { get; set; }
        public Nullable<System.DateTime> PreferredDateFrom { get; set; }
        public Nullable<System.DateTime> PreferredDateTo { get; set; }
        public Nullable<int> RequestWorkOrderID { get; set; }
        public string TokenType { get; set; }
        public string TokenSerial { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        public Nullable<int> ScheduledLocationID { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> LastUserID { get; set; }
        public Nullable<int> ReasonID { get; set; }
        public Nullable<int> TokenStatusID { get; set; }
        public Nullable<int> LastLocationID { get; set; }
        public string SecondSerial { get; set; }
    }
}
