using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class VoucherRequestMapper
    {
        internal static VoucherRequestDTO MapToDto(this CTVoucherRequest ctVoucherRequest)
        {
            if (ctVoucherRequest == null) return null;
            return new VoucherRequestDTO
            {
                LAST_UPDATED_DATE = ctVoucherRequest.LAST_UPDATED_DATE,
                Products = ctVoucherRequest.Products,
                REMERKS = ctVoucherRequest.REMERKS,
                ResponsibleUserName = ctVoucherRequest.ResponsibleUserName,
                CustomerID = ctVoucherRequest.CustomerID,
                CustomerName = ctVoucherRequest.CustomerName,
                VoucherAmount = ctVoucherRequest.VoucherAmount,
                CUSTOMER_Code = ctVoucherRequest.CUSTOMER_Code,
                VoucherID = ctVoucherRequest.VoucherID,
                VoucherTypeID = ctVoucherRequest.VoucherTypeID,
                QUANTITY = ctVoucherRequest.QUANTITY,
                VALIDITY_END_DATE = ctVoucherRequest.VALIDITY_END_DATE,
                VALIDITY_START_DATE = ctVoucherRequest.VALIDITY_START_DATE
            };
        }
        internal static CTVoucherRequest MapToEntity(this VoucherRequestDTO VoucherRequestDTO)
        {
            if (VoucherRequestDTO == null) return null;
            return new CTVoucherRequest
            {
                LAST_UPDATED_DATE = VoucherRequestDTO.LAST_UPDATED_DATE,
                Products = VoucherRequestDTO.Products,
                REMERKS = VoucherRequestDTO.REMERKS,
                ResponsibleUserName = VoucherRequestDTO.ResponsibleUserName,
                CustomerID = VoucherRequestDTO.CustomerID,
                VALIDITY_START_DATE = VoucherRequestDTO.VALIDITY_START_DATE,
                VoucherAmount = VoucherRequestDTO.VoucherAmount,
                VALIDITY_END_DATE = VoucherRequestDTO.VALIDITY_END_DATE,
                VoucherID = VoucherRequestDTO.VoucherID,
                VoucherTypeID = VoucherRequestDTO.VoucherTypeID,
                QUANTITY = VoucherRequestDTO.QUANTITY,
                CUSTOMER_Code = VoucherRequestDTO.CUSTOMER_Code,
                CustomerName = VoucherRequestDTO.CustomerName
            };
        }
        internal static List<VoucherRequestDTO> MapToListDto(this List<CTVoucherRequest> ctVoucherRequest)
        {
            if (ctVoucherRequest == null) return null;
            var VoucherRequestDTO = new List<VoucherRequestDTO>();
            foreach (CTVoucherRequest item in ctVoucherRequest)
            {
                VoucherRequestDTO.Add(MapToDto(item));
            }
            return VoucherRequestDTO;
        }
        internal static List<CTVoucherRequest> MapToListEntity(this List<VoucherRequestDTO> VoucherRequestDTO)
        {
            if (VoucherRequestDTO == null) return null;
            var ctVoucherRequest = new List<CTVoucherRequest>();
            foreach (VoucherRequestDTO item in VoucherRequestDTO)
            {
                ctVoucherRequest.Add(MapToEntity(item));
            }
            return ctVoucherRequest;
        }
    }
}
