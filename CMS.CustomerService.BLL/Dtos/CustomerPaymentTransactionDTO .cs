using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public partial class CustomerPaymentTransactionDTO:BaseDTO
    {
        [DataMember]
        public int? PaymentID { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public int PaymentMethodID { get; set; }
        [DataMember]
        public string PaymentDocRefNo { get; set; }
        [DataMember]
        public DateTime TransactionDate { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int PaymentInterfaceID { get; set; }

    }
}
