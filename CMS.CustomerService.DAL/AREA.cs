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
    
    public partial class AREA
    {
        public AREA()
        {
            this.ADDRESS = new HashSet<ADDRESS>();
        }
    
        public int AREA_ID { get; set; }
        public string AR_NAME { get; set; }
        public short IS_ACTIVE { get; set; }
        public string EN_NAME { get; set; }
        public int CITY_ID { get; set; }
        public Nullable<decimal> LAST_UPDATED_USER_ID { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<decimal> LAST_LOCATION_ID { get; set; }
        public string INTEGRATION_ID { get; set; }
    
        public virtual ICollection<ADDRESS> ADDRESS { get; set; }
        public virtual CITY CITY { get; set; }
    }
}