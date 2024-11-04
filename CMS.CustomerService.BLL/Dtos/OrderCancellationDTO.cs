using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class OrderCancellationDTO : BaseDTO
    {

        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int TokenStatusID { get; set; }
        [DataMember]
        public string TokenStatusENName { get; set; }
        [DataMember]
        public string TokenStatusARName { get; set; }
        [DataMember]
        public Double? FeeAmount { get; set; }
        [DataMember]
        public int ServiceTypeID { get; set; }
        [DataMember]
        public string ServcieTypeName { get; set; }
    }
}
