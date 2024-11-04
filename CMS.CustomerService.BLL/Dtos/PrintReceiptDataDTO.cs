using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class PrintReceiptDataDTO
    {
        [DataMember]
        public string AdnocTransNo { get; set; }
        [DataMember]
        public string CustomerNo { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> TransDateTime { get; set; }
        [DataMember]
        public List<ReceiptDetailsDTO> ReceiptDetailsDTOs { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string CustomerTRN { get; set; }
    }
}
