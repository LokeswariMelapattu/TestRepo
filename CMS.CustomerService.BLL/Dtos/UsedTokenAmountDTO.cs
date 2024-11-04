
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class UsedTokenAmountDTO : BaseDTO
    {
        [DataMember()]
        public int tokenId { get; set; }
        [DataMember()]
        public decimal usedAmount { get; set; }
    }
}
