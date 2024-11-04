 
using System;
using System.Runtime.Serialization; 
namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract()]
    public class BatchTokenDTODetails :  BatchTokenDTO
    {
        [DataMember]
        public string CustomerCode { get; set; }
        public TokenDTO TokenDto { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int GridRowId { get; set; }
        [DataMember]
        public string TokenTypeIdName { get; set; }
        [DataMember]
        public string RestrictionGroupIdName { get; set; }
        [DataMember]
        public string CardCentreIdName { get; set; }
        [DataMember]
        public string BeneficiaryCodeVal { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public bool IsVipBeneficiary { get; set; }
        [DataMember]
        public int? CopyTokenId { get; set; }
        [DataMember]
        public string IdentificationTypeName { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string ChassisNumber { get; set; }
        [DataMember]
        public string EngineNumber { get; set; }
        [DataMember]
        public decimal? FuelCapacity { get; set; }
        [DataMember]
        public string Cc { get; set; }
        [DataMember]
        public string FuelInlet { get; set; }
        [DataMember]
        public TokenRestrictionDTO TokenRestriction { get; set; }
        [DataMember]
        public string AssignedVehicleRegister { get; set; }
        [DataMember]
        public VehicleInfoDTO VehicleInfoDto { get; set; }
        [DataMember]
        public bool IsVehicleRegisterOrPermitNumberError { get; set; }
        [DataMember]
        public string StatusCode { get; set; }

    }
}
