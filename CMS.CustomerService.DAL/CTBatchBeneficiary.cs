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
    
    public partial class CTBatchBeneficiary
    {
        public string BeneficiaryCode { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string BeneficiaryName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public Nullable<int> IdentificationTypeID { get; set; }
        public string IdentificationID { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> BeneficiaryStatusID { get; set; }
        public Nullable<int> BeneficiaryStatusReasonID { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string StatusRemark { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
    }
}
