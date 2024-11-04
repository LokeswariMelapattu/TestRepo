using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokensToDeliverResultDTO
    {
        [DataMember]
        public List<TokenToDeliverDTO> Dtos { get; set; }

        [DataMember]
        public int TotalCount { get; set; }
    }
}
