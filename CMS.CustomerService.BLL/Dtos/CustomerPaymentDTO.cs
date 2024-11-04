using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class CustomerPaymentDTO:BaseDTO
    {
        [DataMember()]
        public Int32? PaymentID { get; set; }

        [DataMember()]
        public Int32? InvoiceID { get; set; }
        
        [DataMember()]
        public Int32 PaymentTypeID { get; set; }

        [DataMember()]
        public Int32 CustomerID { get; set; }

        [DataMember()]
        public Int32 BeneficiaryID { get; set; }

        [DataMember()]
        public Int32 TokenID { get; set; }

        [DataMember()]
        public Nullable<Int32> TransactionTypeID { get; set; }

        [DataMember()]
        public Nullable<Decimal> InitialBalance { get; set; }

        [DataMember()]
        public Nullable<Decimal> TransactionAmount { get; set; }

        [DataMember()]
        public decimal? FinalBalance { get; set; }

        [DataMember()]
        public String AuthorizationCode { get; set; }

        [DataMember()]
        public Nullable<DateTime> PaymentDate { get; set; }

        [DataMember()]
        public Nullable<Int32> PaymentMethodID { get; set; }

        [DataMember()]
        public String PaymentDocomentRef { get; set; }

        [DataMember()]
        public String Remarks { get; set; }

        [DataMember()]
        public String arPaymentName { get; set; }

        [DataMember()]
        public String enPaymentName { get; set; }

        [DataMember()]
        public String Location { get; set; }

        [DataMember()]
        public String UserName { get; set; }


        }
}
