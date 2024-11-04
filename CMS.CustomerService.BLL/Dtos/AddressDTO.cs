using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract(Name = "AddressDTO1")]
    public partial class AddressDTO : BaseDTO
    {
        [DataMember()]
        public Int32? AddressId { get; set; }

        [DataMember()]
        public Int32? AreaId { get; set; }

        [DataMember]
        public AreaDTO Area { get; set; }

        [DataMember()]
        public Int32? CityId { get; set; }

        [DataMember]
        public CityDTO City { get; set; }

        [DataMember()]
        public Int32? CountryId { get; set; }

        [DataMember]
        public CountryDTO Country { get; set; }

        [DataMember()]
        public String PostCode { get; set; }

        [DataMember()]
        public String DetailedAddress { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Fax { get; set; }
    }
}
