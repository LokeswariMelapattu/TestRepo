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
    
    public partial class CTRequestCustomerContacts
    {
        public Nullable<int> ContactID { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> LastUpdatedUserID { get; set; }
        public Nullable<int> ContactTypeID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public Nullable<int> NotificationLanguageID { get; set; }
        public Nullable<int> NotificationChannelID { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string Code { get; set; }
        public string PIN { get; set; }
    }
}