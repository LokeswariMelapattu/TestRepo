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
    
    public partial class CTWorkOrderSearch
    {
        public Nullable<long> OrderTypeID { get; set; }
        public Nullable<long> OrderStatusID { get; set; }
        public Nullable<long> DepotCenterID { get; set; }
        public string WorkOrderNumber { get; set; }
        public string CustomerCode { get; set; }
        public string BeneficiaryCode { get; set; }
        public string TagSerial { get; set; }
        public string TagNumber { get; set; }
        public Nullable<System.DateTime> AppointmentFrom { get; set; }
        public Nullable<System.DateTime> AppointmentTo { get; set; }
    }
}