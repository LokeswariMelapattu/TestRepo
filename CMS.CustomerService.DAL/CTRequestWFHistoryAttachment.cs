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
    
    public partial class CTRequestWFHistoryAttachment
    {
        public string FILE_EXTENSION { get; set; }
        public Nullable<int> Request_Attachment_Id { get; set; }
        public Nullable<int> REQUEST_DOCUMENT_ID { get; set; }
        public byte[] ATTACHMENT { get; set; }
        public Nullable<int> Last_Location_ID { get; set; }
        public Nullable<int> Last_Updated_User_ID { get; set; }
        public Nullable<int> WF_Instance_ID { get; set; }
        public System.DateTime LAST_UPDATED_DATE { get; set; }
    }
}
