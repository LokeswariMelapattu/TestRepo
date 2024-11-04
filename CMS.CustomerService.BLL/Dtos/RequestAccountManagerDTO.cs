using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class RequestAccountManagerDTO : BaseDTO
    { 
        [DataMember]
        public Nullable<int> AccountManagerID { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember] 

        public string Name { get; set; }
    }
}
