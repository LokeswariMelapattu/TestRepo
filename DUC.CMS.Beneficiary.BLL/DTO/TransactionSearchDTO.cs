using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class TransactionSearchDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public Nullable<DateTime> FromDate { get; set; }

        [DataMember]
        public Nullable<DateTime> ToDate { get; set; }

        [DataMember]
        public int? TokenTypeID { get; set; }

        [DataMember]
        public string TokenType { get; set; }

        [DataMember]
        public string TokenTypeAr { get; set; }

        [DataMember]
        public int? StationID { get; set; }

        [DataMember]
        public string StationNameEn { get; set; }

        [DataMember]
        public string StationNameAr { get; set; }


        [DataMember]
        public int? ProductID { get; set; }

        [DataMember]
        public string ProductNameEn { get; set; }

        [DataMember]
        public string ProductNameAr { get; set; }

        [DataMember]
        public string Serial { get; set; }

        [DataMember]
        public int? GroupID { get; set; }

        [DataMember]
        public Nullable<DateTime> TransactionDate { get; set; }

        [DataMember]
        public decimal? TransactionAmount { get; set; }

        [DataMember]
        public decimal? Adjustment { get; set; }

        [DataMember]
        public decimal? PaidAmount { get; set; }

    }
}
