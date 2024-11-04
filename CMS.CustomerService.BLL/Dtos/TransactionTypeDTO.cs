using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class TransactionTypeDTO
    {
        [DataMember]
        public int? TransTypeId { get; set; }
        [DataMember]
        public string EnTransName { get; set; }
    }
}
