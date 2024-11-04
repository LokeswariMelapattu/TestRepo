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
        internal static DebitCreditRequestDTO MapToDto(this CTDebitCreditRequest ctDebitCreditRequest)
        {
            if (ctDebitCreditRequest == null) return null;
            return new DebitCreditRequestDTO
            {
                CUSTOMER_ID = ctDebitCreditRequest.CUSTOMER_ID,
                CUSTOMER_NAME = ctDebitCreditRequest.CUSTOMER_NAME,
                CUSTOMER_NO = ctDebitCreditRequest.CUSTOMER_NO,
                DATE_TIME = ctDebitCreditRequest.DATE_TIME,
                PAYMENT_ID = ctDebitCreditRequest.PAYMENT_ID,
                PAYMENT_TYPE = ctDebitCreditRequest.PAYMENT_TYPE,
                REMARKS = ctDebitCreditRequest.REMARKS,
                TRANSACTION_AMOUNT = ctDebitCreditRequest.TRANSACTION_AMOUNT,
                PAYMENT_TYPE_ID = ctDebitCreditRequest.PAYMENT_TYPE_ID
            };
        }
        internal static CTDebitCreditRequest MapToEntity(this DebitCreditRequestDTO debitCreditRequestDTO)
        {
            if (debitCreditRequestDTO == null) return null;
            return new CTDebitCreditRequest
            {
               CUSTOMER_ID = debitCreditRequestDTO.CUSTOMER_ID,
               CUSTOMER_NAME = debitCreditRequestDTO.CUSTOMER_NAME,
               CUSTOMER_NO = debitCreditRequestDTO.CUSTOMER_NO,
               TRANSACTION_AMOUNT = debitCreditRequestDTO.TRANSACTION_AMOUNT,
               REMARKS = debitCreditRequestDTO.REMARKS,
               PAYMENT_TYPE = debitCreditRequestDTO.PAYMENT_TYPE,
               PAYMENT_ID = debitCreditRequestDTO.PAYMENT_ID,
               DATE_TIME = debitCreditRequestDTO.DATE_TIME,
               PAYMENT_TYPE_ID = debitCreditRequestDTO.PAYMENT_TYPE_ID
            };
        }
        internal static List<DebitCreditRequestDTO> MapToListDto(this List<CTDebitCreditRequest> ctDebitCreditRequest)
        {
            if (ctDebitCreditRequest == null) return null;
            var debitCreditRequestDTO = new List<DebitCreditRequestDTO>();
            foreach (CTDebitCreditRequest item in ctDebitCreditRequest)
            {
                debitCreditRequestDTO.Add(MapToDto(item));
            }
            return debitCreditRequestDTO;
        }
        internal static List<CTDebitCreditRequest> MapToListEntity(this List<DebitCreditRequestDTO> debitCreditRequestDTO)
        {
            if (debitCreditRequestDTO == null) return null;
            var ctDebitCreditRequest = new List<CTDebitCreditRequest>();
            foreach (DebitCreditRequestDTO item in debitCreditRequestDTO)
            {
                ctDebitCreditRequest.Add(MapToEntity(item));
            }
            return ctDebitCreditRequest;
        }
    }
}
