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
    
    public partial class CTSearchRequest
    {
        public string TokenName { get; set; }
        public string BeneficiaryName { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
        public Nullable<System.DateTime> RequestDateFrom { get; set; }
        public Nullable<int> AssignedToUserID { get; set; }
        public Nullable<int> RequestID { get; set; }
        public string RequestCode { get; set; }
        public Nullable<System.DateTime> RequestDateTo { get; set; }
        public string CustomerCode { get; set; }
        public string TokenCode { get; set; }
    }
}
