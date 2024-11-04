using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract]
    public class RefundTypeDTO : BaseDTO
    {
        [DataMember]
        public int? RefundTypeID { get; set; }

        [DataMember]
        public string EnName { get; set; }

        [DataMember]
        public string ArName { get; set; }
    }

    internal static class RefundTypeDTOMapper
    {
        internal static RefundTypeDTO ToDTO(this CTRefundTypes ct)
        {
            if (ct == null)
                return null;
            return new RefundTypeDTO
            {
                RefundTypeID = ct.REFUND_TYPE_ID,
                ArName = ct.AR_NAME,
                EnName = ct.EN_NAME
            };
        }

        internal static List<RefundTypeDTO> ToDTOs(this List<CTRefundTypes> cts)
        {
            var res = new List<RefundTypeDTO>();
            foreach (var ct in cts)
                res.Add(ct.ToDTO());
            return res;
        }
    }
}
