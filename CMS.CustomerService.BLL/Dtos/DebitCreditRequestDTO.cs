using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class DebitCreditRequestDTO
    {
        public Nullable<int> PAYMENT_ID { get; set; }
        public Nullable<decimal> TRANSACTION_AMOUNT { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public Nullable<System.DateTime> DATE_TIME { get; set; }
        public string REMARKS { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public string CUSTOMER_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public Nullable<int> PAYMENT_TYPE_ID { get; set; }
    }
}
