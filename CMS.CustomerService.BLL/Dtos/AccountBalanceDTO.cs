using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class AccountBalanceDTO:BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public decimal? InitialBalance { get; set; }
        [DataMember]
        public decimal? FinalBalance { get; set; }
        [DataMember]
        public DateTime TransactionDate { get; set; }
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public string TransactionTypeAR { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
    }
}
