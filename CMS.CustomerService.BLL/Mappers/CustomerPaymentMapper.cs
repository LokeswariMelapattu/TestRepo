using System;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    /// <summary>
    /// Assembler for <see cref="CUSTOMER_PAYMENT"/> and <see cref="CustomerPaymentDTO"/>.
    /// </summary>
    public static partial class CustomerPaymentMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerPaymentDTO"/> converted from <see cref="CUSTOMER_PAYMENT"/>.</param>
        static partial void OnDTO(this CTCustomerPayment entity, CustomerPaymentDTO dto);
        /// <summary>
        /// Invoked when <see cref="ToCDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CustomerPaymentDTO"/> converted from <see cref="CUSTOMER_PAYMENT"/>.</param>
        static partial void OnCDTO(this CUSTOMER_PAYMENT entity, CustomerPaymentDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_PAYMENT"/> converted from <see cref="CustomerPaymentDTO"/>.</param>
        static partial void OnEntity(this CustomerPaymentDTO dto, CUSTOMER_PAYMENT entity);

        /// <summary>
        /// Converts this instance of <see cref="CustomerPaymentDTO"/> to an instance of <see cref="CUSTOMER_PAYMENT"/>.
        /// </summary>
        /// <param name="dto"><see cref="CustomerPaymentDTO"/> to convert.</param>
        public static CUSTOMER_PAYMENT ToEntity(this CustomerPaymentDTO dto)
        {
            if (dto == null) return null;

            var entity = new CUSTOMER_PAYMENT();

            entity.PAYMENT_ID = dto.PaymentID == null ? -1 : (int)dto.PaymentID;
            entity.CUSTOMER_ID = dto.CustomerID;
            entity.PAYMENT_TYPE_ID = dto.PaymentTypeID;
            entity.INITIAL_BALANCE = dto.InitialBalance;
            entity.TRANSACTION_AMOUNT = dto.TransactionAmount;
            entity.FINAL_BALANCE = dto.FinalBalance;
            entity.AUTHORIZATION_CODE = dto.AuthorizationCode;
            entity.DATE_TIME = dto.PaymentDate;
            entity.PAYMENT_METHOD_ID = dto.PaymentMethodID;
            entity.PAYMENT_DOCUMENT_REF = dto.PaymentDocomentRef;
            entity.REMARKS = dto.Remarks;
            entity.IS_ACTIVE = (short)(dto.IsActive ? 1 : 0); ;

            dto.OnEntity(entity);

            return entity;
        }

        public static CUSTOMER_PAYMENT ToEntity(this CustomerPaymentTransactionDTO dto)
        {
            if (dto == null) return null;
            return new CUSTOMER_PAYMENT
            {
                CUSTOMER_ID = dto.CustomerID,
                TRANSACTION_AMOUNT = dto.Amount,
                PAYMENT_METHOD_ID = dto.PaymentMethodID,
                PAYMENT_DOCUMENT_REF = dto.PaymentDocRefNo,
                PAYMENT_TYPE_ID=dto.PaymentTypeID,
                DATE_TIME = dto.TransactionDate,
                REMARKS = dto.Remarks,
                PAYMENT_ID = dto.PaymentID == null ? -1 : (int)dto.PaymentID,
                IS_ACTIVE = Convert.ToInt16(dto.IsActive),
                PAYMENT_INTERFACE_ID = dto.PaymentInterfaceID
            };
        }

        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_PAYMENT"/> to an instance of <see cref="CustomerPaymentDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_PAYMENT"/> to convert.</param>
        public static CustomerPaymentDTO ToDTO(this CTCustomerPayment entity)
        {
            if (entity == null) return null;

            var dto = new CustomerPaymentDTO();

            dto.PaymentID = entity.PAYMENT_ID;
            dto.CustomerID = entity.CUSTOMER_ID;
            //dto.BeneficiaryID = entity.BENEFICIARY_ID;
            //dto.TokenID = entity.TOKEN_ID;
            dto.PaymentTypeID = entity.PAYMENT_TYPE_ID.HasValue ? entity.PAYMENT_TYPE_ID.Value : 0;
            dto.InitialBalance = entity.INITIAL_BALANCE;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.FinalBalance = entity.FINAL_BALANCE;
            dto.AuthorizationCode = entity.AUTHORIZATION_CODE;
            dto.InvoiceID = entity.INVOICE_ID.HasValue ? entity.INVOICE_ID.Value : 0;
            dto.PaymentDate = entity.DATE_TIME;
            dto.PaymentMethodID = entity.PAYMENT_METHOD_ID;
            dto.PaymentDocomentRef = entity.PAYMENT_DOCUMENT_REF;
            dto.Remarks = entity.REMARKS;
            dto.IsActive = entity.IS_ACTIVE == 1;
            dto.arPaymentName = entity.AR_PAYMENT_TYPE;
            dto.enPaymentName = entity.EN_PAYMENT_TYPE;
            dto.UserName = entity.RESPONSIBLE_USER;
            dto.Location = entity.LOCATION_NAME;
            entity.OnDTO(dto);

            return dto;
        }
        /// <summary>
        /// Converts this instance of <see cref="CUSTOMER_PAYMENT"/> to an instance of <see cref="CustomerPaymentDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CUSTOMER_PAYMENT"/> to convert.</param>
        public static CustomerPaymentDTO MapToDTO(this CUSTOMER_PAYMENT entity)
        {
            if (entity == null) return null;

            var dto = new CustomerPaymentDTO();

            dto.PaymentID = entity.PAYMENT_ID;
            dto.CustomerID = entity.CUSTOMER_ID;
            //dto.BeneficiaryID = entity.BENEFICIARY_ID;
            //dto.TokenID = entity.TOKEN_ID;
            dto.PaymentTypeID = entity.PAYMENT_TYPE_ID.HasValue ? entity.PAYMENT_TYPE_ID.Value : 0;
            dto.InitialBalance = entity.INITIAL_BALANCE;
            dto.TransactionAmount = entity.TRANSACTION_AMOUNT;
            dto.FinalBalance = entity.FINAL_BALANCE;
            dto.AuthorizationCode = entity.AUTHORIZATION_CODE;
            dto.InvoiceID = entity.INVOICE_ID.HasValue ? entity.INVOICE_ID.Value : 0;
            dto.PaymentDate = entity.DATE_TIME;
            dto.PaymentMethodID = entity.PAYMENT_METHOD_ID;
            dto.PaymentDocomentRef = entity.PAYMENT_DOCUMENT_REF;
            dto.Remarks = entity.REMARKS;
            dto.IsActive = entity.IS_ACTIVE == 1; 
            entity.OnCDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CustomerPaymentDTO"/> to an instance of <see cref="CUSTOMER_PAYMENT"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CUSTOMER_PAYMENT> ToEntities(this IEnumerable<CustomerPaymentDTO> dtos)
        {
            return LinqExtension.ToEntity<CUSTOMER_PAYMENT, CustomerPaymentDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CUSTOMER_PAYMENT"/> to an instance of <see cref="CustomerPaymentDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CustomerPaymentDTO> ToDTOs(this IEnumerable<CTCustomerPayment> entities)
        {
            return LinqExtension.ToDTO<CTCustomerPayment, CustomerPaymentDTO>(entities, ToDTO);
        }

    }
}
