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
    
    public partial class CTRestrictionGroupQuanity
    {
        public int RESTRICTION_GROUP_ID { get; set; }
        public int PRODUCT_ID { get; set; }
        public int FREQUENCY_ID { get; set; }
        public decimal ALLOWED_QUANTITY { get; set; }
        public Nullable<short> IS_ACTIVE { get; set; }
        public string PRODUCT_EN_NAME { get; set; }
        public Nullable<int> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public string PRODUCT_AR_NAME { get; set; }
    }
}
