using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class BeneficiaryStatusHistoryDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public int? BeneficiaryID { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public string StatusName { get; set; }

        [DataMember]
        public string StatusNameAr { get; set; }

        [DataMember]
        public int? StatusReasonID { get; set; }

        [DataMember]
        public string StatusReasonName { get; set; }

        [DataMember]
        public string StatusReasonNameAr { get; set; }

        [DataMember]
        public DateTime? StatusChangeDate { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
