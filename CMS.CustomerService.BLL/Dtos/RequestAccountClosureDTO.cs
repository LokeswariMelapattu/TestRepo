using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RequestAccountClosureDTO : BaseDTO
    {
        [DataMember]
        public int? RequestCustomerId { get; set; }
        [DataMember]
        public int? RequestID { get; set; }
        [DataMember]
        public int? NationalityID { get; set; }
        [DataMember]
        public string CompanyID { get; set; }
        [DataMember]
        public int? BasicAddressId { get; set; }
        [DataMember]
        public int? BillingAddressId { get; set; }
        [DataMember]
        public int? ShippingAddressId { get; set; }
        [DataMember]
        public int? CustomerTypeID { get; set; }
        [DataMember]
        public int? AccountTypeID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string IdentificationType { get; set; }
        [DataMember]
        public int? ClassificationId { get; set; }
        [DataMember]
        public string Classification { get; set; }
        [DataMember]
        public DateTime? RegistrationDate { get; set; }
        [DataMember]
        public string AccountStatus { get; set; }
        [DataMember]
        public RequestCustomerAddressDTO BasicAddress { get; set; }
        [DataMember]
        public RequestCustomerAddressDTO BillingAddress { get; set; }
        [DataMember]
        public RequestCustomerAddressDTO ShippingAddress { get; set; }
        [DataMember]
        public RequestDTO Request { get; set; }
        [DataMember]
        public decimal AccountBalance { get; set; }
        [DataMember()]
        public List<CustomerContactDTO> CustomerContact { get; set; }
        [DataMember]
        public int? OperationalContactID { get; set; }
        [DataMember]
        public int? FinancialContactID { get; set; }
        [DataMember]
        public string NationalId { get; set; }

    }
}
