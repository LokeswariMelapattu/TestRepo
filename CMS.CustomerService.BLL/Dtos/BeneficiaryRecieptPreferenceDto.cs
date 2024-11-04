using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class BeneficiaryRecieptPreferenceDto : BaseDTO
    {
        [DataMember()]
        public Int32 BeneficiaryID { get; set; }

        [DataMember()]
        public Int32 RecieptTypeID { get; set; }
    }
}
