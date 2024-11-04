using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public  partial class RequestServiceFeeDTO : BaseDTO
    {
        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public RequestDTO Request { get; set; }
        [DataMember]
        public Nullable<int> ServiceFeeID { get; set; }
        [DataMember]
        public int ServiceID { get; set; }
        [DataMember]
        public int? CustomerStatusID { get; set; }
        [DataMember]
        public int? CustomerTypeID { get; set; }
        [DataMember]
        public int? AccountTypeID { get; set; }
        [DataMember]
        public int? ClassificationID { get; set; }
        [DataMember]
        public int? ISPremier { get; set; }
        [DataMember]
        public int? Location_ID { get; set; }
        [DataMember]
        public decimal Fee { get; set; }
        [DataMember]
        public string ServiceName_en { get; set; }
        [DataMember]
        public string CustomerStatus_en { get; set; }
        [DataMember]
        public string CustomerType_en { get; set; }
        [DataMember]
        public string AccountType_en { get; set; }
        [DataMember]
        public string ClassificationName_en { get; set; }
        [DataMember]
        public string LocationName_en { get; set; }
        [DataMember]
        public string AccountType_ar { get; set; }
        [DataMember]
        public string CustomerStatus_ar { get; set; }
        [DataMember]
        public string LocationName_ar { get; set; }
        [DataMember]
        public string ServiceName_ar { get; set; }
        [DataMember]
        public string CustomerType_ar { get; set; }
        [DataMember]
        public string ClassificationName_ar { get; set; }
    }
}
