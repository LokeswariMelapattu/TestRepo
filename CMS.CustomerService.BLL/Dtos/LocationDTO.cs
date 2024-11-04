using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class LocationDTO : BaseDTO
    {
        [DataMember()]
        public Int32? LocationID { get; set; }

        [DataMember]
        public int?  AddressID { get; set; }

        [DataMember()]
        public String LocationName { get; set; }
        
        [DataMember]
        public int?  LocationTypeID { get; set; }

        [DataMember()]
        public String Phone { get; set; }

        [DataMember()]
        public String Fax { get; set; }


    }
}
