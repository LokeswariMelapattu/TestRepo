using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
   public  partial class ServiceFeeDTO:BaseDTO
    {
        [DataMember]
        public int ServiceID { get; set; }
        [DataMember]
        public int CustomerStatusID { get; set; }
        [DataMember]
        public int CustomerTypeID { get; set; }
        [DataMember]
        public int AccountTypeID { get; set; }
        [DataMember]
        public int ClassificationID { get; set; }
        [DataMember]
        public int ISPremier { get; set; }
        [DataMember]
        public int LastLocationID { get; set; }
        [DataMember]
        public Nullable<int> ServicefeeID { get; set; }
        [DataMember]
        public decimal Fee { get; set; }

    }
}
