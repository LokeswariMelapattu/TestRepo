using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class VoucherRequestDTO
    {
        public Nullable<int> VoucherID { get; set; }
        public string Products { get; set; }
        public Nullable<int> VoucherTypeID { get; set; }
        public Nullable<decimal> VoucherAmount { get; set; }
        public string ResponsibleUserName { get; set; }
        public string REMERKS { get; set; }
        public Nullable<System.DateTime> LAST_UPDATED_DATE { get; set; }
        public Nullable<System.DateTime> VALIDITY_START_DATE { get; set; }
        public Nullable<System.DateTime> VALIDITY_END_DATE { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CUSTOMER_Code { get; set; }
        public string CustomerName { get; set; }
    }
}
