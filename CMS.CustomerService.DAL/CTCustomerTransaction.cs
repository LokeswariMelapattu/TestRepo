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
    
    public partial class CTCustomerTransaction
    {
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> BeneficiaryID { get; set; }
        public string BeneficiaryName { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> TokenTypeID { get; set; }
        public string TokenType { get; set; }
        public Nullable<int> StationID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Serial { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<decimal> TransactionAmount { get; set; }
        public Nullable<decimal> Adjustment { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
    }
}
