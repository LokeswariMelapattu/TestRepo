using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
   public partial class FeeCustomerPaymentTransactionDTO
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public string PaymentDocRefNo { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public System.DateTime TransactionDate { get; set; }
    }
}
