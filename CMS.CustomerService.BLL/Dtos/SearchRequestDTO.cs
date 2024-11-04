using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class SearchRequestDTO : BaseDTO
    {
        [DataMember]
        public string TokenName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public Nullable<int> RequestTypeID { get; set; }
        [DataMember]
        public Nullable<int> RequestStatusId { get; set; }
        [DataMember]
        public System.DateTime? RequestDateFrom { get; set; }
        [DataMember]
        public System.DateTime? RequestDateTo { get; set; }
        [DataMember]
        public int UserID { get; set; }

    }
}
