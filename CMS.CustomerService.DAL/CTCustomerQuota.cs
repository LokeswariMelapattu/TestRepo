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
    
    public partial class CTCustomerQuota
    {
        public long CUSTOMER_ID { get; set; }
        public long PRODUCT_ID { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public Nullable<decimal> Quota { get; set; }
        public long QuotaId { get; set; }
    }
}