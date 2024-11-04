using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class MapCustomerDTO : BaseDTO
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public int? CustomerStatusID { get; set; }

        [DataMember]
        public string CustomerStatus { get; set; }

        [DataMember]
        public string CustomerStatusAr { get; set; }

        [DataMember]
        public int? CustomerTypeID { get; set; }

        [DataMember]
        public string CustomerType { get; set; }

        [DataMember]
        public string CustomerTypeAr { get; set; }

        [DataMember]
        public List<MapBeneficiaryDTO> Beneficiary { get; set; }
    }
}
