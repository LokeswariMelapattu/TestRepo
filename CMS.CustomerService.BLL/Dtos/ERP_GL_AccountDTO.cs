using System.Runtime.Serialization;
namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class ERP_GL_AccountDTO
    {
        [DataMember]
        public decimal? CostCenterID { get; set; }
        [DataMember]
        public string AccountCode { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool isActive { get; set; }
    }
}
