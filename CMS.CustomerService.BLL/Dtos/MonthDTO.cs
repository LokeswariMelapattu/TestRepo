using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class MonthDTO
    {
        [DataMember]
        public Nullable<int> MonthId { get; set; }
        [DataMember]
        public string EnName { get; set; }
    }
}
