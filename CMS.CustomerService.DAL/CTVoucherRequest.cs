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
    
    public partial class CTVoucherRequest
    {
        public Nullable<int> VoucherID { get; set; }
        public Nullable<int> VoucherTypeID { get; set; }
        public Nullable<decimal> VoucherAmount { get; set; }
        public string ResponsibleUserName { get; set; }
        public string REMERKS { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<System.DateTime> VALIDITY_START_DATE { get; set; }
        public Nullable<System.DateTime> VALIDITY_END_DATE { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CUSTOMER_Code { get; set; }
        public string CustomerName { get; set; }
        public string Products { get; set; }
    }
}
