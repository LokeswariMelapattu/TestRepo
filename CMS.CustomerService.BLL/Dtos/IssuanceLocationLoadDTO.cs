using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class IssuanceLocationLoadDto
    {
        [DataMember]
        public int LoadCount { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
}
