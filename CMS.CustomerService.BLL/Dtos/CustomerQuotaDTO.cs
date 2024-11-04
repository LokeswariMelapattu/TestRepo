using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class CustomerQuotaDTO
    {
        [DataMember]
        public Int64 CustomerId { get; set; }
        [DataMember]
        public Int64 ProductId { get; set; }
        [DataMember]
        public string ProductNameAr { get; set; }
        [DataMember]
        public string ProductNameEn { get; set; }
        [DataMember]
        public decimal? Quota { get; set; }
        [DataMember]
        public Int64 QuotaId { get; set; }
    }
}
