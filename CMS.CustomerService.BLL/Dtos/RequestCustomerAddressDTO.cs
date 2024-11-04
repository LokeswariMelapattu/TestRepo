using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
   public class RequestCustomerAddressDTO :BaseDTO
    {
       [DataMember]
        public string enAreaName { get; set; }
       [DataMember]
       public string arAreaName { get; set; }
       [DataMember]
       public Nullable<int> AreaID { get; set; }
       [DataMember]
       public string enCityName { get; set; }
       [DataMember]
       public string arCityName { get; set; }
       [DataMember]
       public Nullable<int> CityID { get; set; }
       [DataMember]
       public string enCountryName { get; set; }
       [DataMember]
       public string arCountryName { get; set; }
       [DataMember]
       public Nullable<int> CountryID { get; set; }
       [DataMember]
       public string POST_CODE { get; set; }
       [DataMember]
       public string DETAILED_ADDRESS { get; set; }
       [DataMember]
       public string FAX { get; set; }
       [DataMember]
       public string PHONE_NUMBER { get; set; }
       [DataMember]
       public Nullable<int> ADDRESS_ID { get; set; }

    }
}
