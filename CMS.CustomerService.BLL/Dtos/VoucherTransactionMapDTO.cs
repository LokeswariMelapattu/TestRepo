using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class VoucherTransactionMapDTO : BaseDTO
    {
        //    EXT_VOUCHER_NO --VARCHAR2
        //VOUCHER_SERIAL_NUMBER --VARCHAR2
        //VAT_INVOICE_NO --VARCHAR2
        //ACTION --VARCHAR2
        //OPERATION_DATE -- DATE
        //LOCATION_NAME --VARCHAR2
        //RESPONSIBLE_USER --VARCHAR2


        [DataMember]
        public string EXTVoucherNo { get; set; }

        [DataMember]
        public string VoucherSerialNo { get; set; }
        [DataMember]
        public string VATInvoiceNo { get; set; }
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public Nullable<DateTime> OperationDate { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public int RowNum { get; set; }

    }
}
