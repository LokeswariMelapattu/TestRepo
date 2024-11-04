﻿using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class CustomerBeneficiarySearchDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public int BeneficiaryID { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string BeneficiaryCode { get; set; }
    }
}
