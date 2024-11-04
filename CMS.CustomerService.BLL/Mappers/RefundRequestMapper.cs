using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class DebitCreditRequestMapper
    {
        internal static RefundRequestDTO MapToDto(this CTRefundRequest ctRefundRequest)
        {
            if (ctRefundRequest == null) return null;
            return new RefundRequestDTO
            {
                CUSTOMER_ID = ctRefundRequest.CUSTOMER_ID,
                CUSTOMER_NAME = ctRefundRequest.CUSTOMER_NAME,
                CUSTOMER_NO = ctRefundRequest.CUSTOMER_NO,
                DATE_TIME = ctRefundRequest.DATE_TIME,
                PAYMENT_ID = ctRefundRequest.PAYMENT_ID,
                PAYMENT_TYPE = ctRefundRequest.PAYMENT_TYPE,
                REMARKS = ctRefundRequest.REMARKS,
                TRANSACTION_AMOUNT = ctRefundRequest.TRANSACTION_AMOUNT,
                BANK_NAME=ctRefundRequest.BANK_NAME,
                ACCOUNT_HOLDER_NAME=ctRefundRequest.ACCOUNT_HOLDER_NAME,
                ACCOUNT_NUMBER= ctRefundRequest.ACCOUNT_NUMBER,
                IBAN_NUMBER= ctRefundRequest.IBAN_NUMBER,
                REFUND_TYPE_ID = ctRefundRequest.REFUND_TYPE_ID,
                REQUEST_CODE = ctRefundRequest.REQUEST_CODE,
                PAYMENT_DOCUMENT_REF = ctRefundRequest.PAYMENT_DOCUMENT_REF,
                COUNTRY_ID = ctRefundRequest.COUNTRY_ID
            };
        }
        internal static CTRefundRequest MapToEntity(this RefundRequestDTO refundRequestDTO)
        {
            if (refundRequestDTO == null) return null;
            return new CTRefundRequest
            {
               CUSTOMER_ID = refundRequestDTO.CUSTOMER_ID,
               CUSTOMER_NAME = refundRequestDTO.CUSTOMER_NAME,
               CUSTOMER_NO = refundRequestDTO.CUSTOMER_NO,
               TRANSACTION_AMOUNT = refundRequestDTO.TRANSACTION_AMOUNT,
               REMARKS = refundRequestDTO.REMARKS,
               PAYMENT_TYPE = refundRequestDTO.PAYMENT_TYPE,
               PAYMENT_ID = refundRequestDTO.PAYMENT_ID,
               DATE_TIME = refundRequestDTO.DATE_TIME,
                BANK_NAME = refundRequestDTO.BANK_NAME,
                ACCOUNT_HOLDER_NAME = refundRequestDTO.ACCOUNT_HOLDER_NAME,
                ACCOUNT_NUMBER = refundRequestDTO.ACCOUNT_NUMBER,
                IBAN_NUMBER = refundRequestDTO.IBAN_NUMBER,
                REFUND_TYPE_ID=refundRequestDTO.REFUND_TYPE_ID,
                REQUEST_CODE=refundRequestDTO.REQUEST_CODE,
                PAYMENT_DOCUMENT_REF=refundRequestDTO.PAYMENT_DOCUMENT_REF,
                COUNTRY_ID = refundRequestDTO.COUNTRY_ID
            };
        }
        internal static List<RefundRequestDTO> MapToListDto(this List<CTRefundRequest> ctRefundRequest)
        {
            if (ctRefundRequest == null) return null;
            var refundRequestDTO = new List<RefundRequestDTO>();
            foreach (CTRefundRequest item in ctRefundRequest)
            {
                refundRequestDTO.Add(MapToDto(item));
            }
            return refundRequestDTO;
        }
        internal static List<CTRefundRequest> MapToListEntity(this List<RefundRequestDTO> refundRequestDTO)
        {
            if (refundRequestDTO == null) return null;
            var ctRefundRequest = new List<CTRefundRequest>();
            foreach (RefundRequestDTO item in refundRequestDTO)
            {
                ctRefundRequest.Add(MapToEntity(item));
            }
            return ctRefundRequest;
        }
    }
}
