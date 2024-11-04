using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class RefundRequestDTO
    {
        public Nullable<int> PAYMENT_ID { get; set; }
        public Nullable<decimal> TRANSACTION_AMOUNT { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public Nullable<System.DateTime> DATE_TIME { get; set; }
        public string REMARKS { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public string CUSTOMER_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string BANK_NAME { get; set; }
        public string ACCOUNT_HOLDER_NAME { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
        public string IBAN_NUMBER { get; set; }
        public string PAYMENT_DOCUMENT_REF { get; set; }
        public string REQUEST_CODE { get; set; }
        public Nullable<int> REFUND_TYPE_ID { get; set; }
        public Nullable<int> COUNTRY_ID { get; set; }
    }
}
