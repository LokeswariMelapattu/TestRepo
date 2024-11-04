using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class CTBillToDetailsMapper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BillToDetailsDTO"/> converted from <see cref="CTBillToDetails"/>.</param>
        static partial void OnDTO(this CTBillToDetails entity, BillToDetailsDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="CTBillToDetails"/> converted from <see cref="BillToDetailsDTO"/>.</param>
        static partial void OnEntity(this BillToDetailsDTO dto, CTBillToDetails entity);

        /// <summary>
        /// Converts this instance of <see cref="BillToDetailsDTO"/> to an instance of <see cref="CTBillToDetails"/>.
        /// </summary>
        /// <param name="dto"><see cref="BillToDetailsDTO"/> to convert.</param>
        public static CTBillToDetails ToEntity(this BillToDetailsDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTBillToDetails();

            entity.BILL_TO_NUMBER = dto.BillToNumber;
            entity.BILL_TO_ADDRESS = dto.BillToAddress;
            entity.BILL_TO_FAX = dto.BillToFax;
            entity.PO_BOX = dto.PoBox;
            entity.ADDRESS_DETAILS = dto.AddressDetails;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="CTBillToDetails"/> to an instance of <see cref="BillToDetailsDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="CTCustomerDetails"/> to convert.</param>
        public static BillToDetailsDTO ToDTO(this CTBillToDetails entity)
        {
            if (entity == null) return null;

            var dto = new BillToDetailsDTO();

            dto.BillToNumber = entity.BILL_TO_NUMBER;
            dto.BillToAddress = entity.BILL_TO_ADDRESS;
            dto.BillToFax = entity.BILL_TO_FAX;
            dto.PoBox = entity.PO_BOX;
            dto.AddressDetails = entity.ADDRESS_DETAILS;
         
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="BillToDetailsDTO"/> to an instance of <see cref="CTBillToDetails"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<CTBillToDetails> ToEntities(this IEnumerable<BillToDetailsDTO> dtos)
        {
            return LinqExtension.ToEntity<CTBillToDetails, BillToDetailsDTO>(dtos, ToEntity);
        }

        /// <summary>
        /// Converts each instance of <see cref="CTBillToDetails"/> to an instance of <see cref="BillToDetailsDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<BillToDetailsDTO> ToDTOs(this IEnumerable<CTBillToDetails> entities)
        {
            return LinqExtension.ToDTO<CTBillToDetails, BillToDetailsDTO>(entities, ToDTO);
        }

    }
}
