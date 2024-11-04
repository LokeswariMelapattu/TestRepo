using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract]
    public class AddressDTO : BaseDTO
    {
        [DataMember]
        public int? AddressID { get; set; }

        [DataMember]
        public Nullable<int> AreaID { get; set; }

        public Lazy<AreaDTO> _AreaDTO = null;

        [DataMember]
        public AreaDTO AreaDTO
        {
            get
            {
                return _AreaDTO == null ? null : _AreaDTO.Value;
            }
            set { ;}
        }

        [DataMember]
        public Nullable<int> CityID { get; set; }

        public Lazy<CityDTO> _CityDTO = null;

        [DataMember]
        public CityDTO CityDTO
        {
            get
            {
                return _CityDTO == null ? null : _CityDTO.Value;
            }
            set { ;}
        }

        [DataMember]
        public Nullable<int> CountryID { get; set; }

        public Lazy<CountryDTO> _CountryDTO = null;

        [DataMember]
        public CountryDTO CountryDTO
        {
            get
            {
                return _CountryDTO == null ? null : _CountryDTO.Value;
            }
            set { ;}
        }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public string DetailedAddress { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Fax { get; set; }

    }
}
