using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    class LocationTypeDTO
    {
        [DataMember()]
        public Int32 LocationTypeID { get; set; }

        [DataMember()]
        public String Name { get; set; }
    }
}
