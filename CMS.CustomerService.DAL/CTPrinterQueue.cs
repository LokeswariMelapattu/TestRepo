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
    
    public partial class CTPrinterQueue
    {
        public Nullable<int> PRINTER_QUEUE_ID { get; set; }
        public Nullable<int> PERSONALIZATION_ORDER_ID { get; set; }
        public Nullable<System.DateTime> ADD_DATE { get; set; }
        public Nullable<int> PRINTER_ID { get; set; }
        public string PrinterName { get; set; }
        public string PERSONALIZATION_ORDER_TYPE { get; set; }
        public string REMARK { get; set; }
        public Nullable<int> PRINT_STATUS_ID { get; set; }
        public string PrintingStatusAr { get; set; }
        public string PrintingStatus { get; set; }
        public string PersonalizationRequestNumber { get; set; }
        public string ENCODER_NAME { get; set; }
        public int ROW_NUM { get; set; }
    }
}