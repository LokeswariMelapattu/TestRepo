using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CPS.BLL.Mappers
{
    public static partial class CustomerTagSearchMapper
    {
        static partial void OnDTO(this CTCustomerTagSearch entity, CustomerTagSearchDTO dto);

        public static CustomerTagSearchDTO ToDTO(this CTCustomerTagSearch entity)
        {
            if (entity == null) return null;

            var dto = new CustomerTagSearchDTO();

            dto.Token_ID = entity.Token_ID;
            dto.TagNumberOpt = entity.TagNumberOpt;
            dto.TagSerialOpt = entity.TagSerialOpt;
            dto.TagNumber = entity.TagNumber;
            dto.TagSerial = entity.TagSerial;
            dto.TOKENNAME = entity.TOKENNAME;
            dto.TOKENCODE = entity.TOKENCODE;
            dto.DepotCentreID = entity.DepotCentreID;
            dto.TOKEN_STATUS_ID = entity.TOKEN_STATUS_ID;
            dto.CUSTOMER_ID = entity.CUSTOMER_ID;
            dto.BENEFICIARY_ID = entity.BENEFICIARY_ID;
            dto.CustomerTypeID = entity.CustomerTypeID;
            dto.WORK_ORDER_ID = entity.WORK_ORDER_ID;
            dto.WORK_ORDER_TYPE_ID = entity.WORK_ORDER_TYPE_ID;
            dto.WORK_ORDER_REASON_ID = entity.WORK_ORDER_REASON_ID;
            dto.VehicleYear = entity.VehicleYear;
            dto.FUEL_INLET = entity.FUEL_INLET;
            dto.BenefiicaryCode = entity.BenefiicaryCode;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.BenefiicaryName = entity.BenefiicaryName;
            dto.CustomerTypeAR = entity.CustomerTypeAR;
            dto.CustomerType = entity.CustomerType;
            dto.VehiclePlate = entity.VehiclePlate;
            dto.VEHICLEMAKE = entity.VEHICLEMAKE;
            dto.VehicleModel = entity.VehicleModel;
            dto.VehicleColor = entity.VehicleColor;
            dto.Emirate = entity.Emirate;
            dto.WorkOrderReason = entity.WorkOrderReason;
            dto.RFIDTYPEAR = entity.RFIDTYPEAR;
            dto.RFIDTYPEEN = entity.RFIDTYPEEN;
            dto.VehicleCategory = entity.VehicleCategory;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<CustomerTagSearchDTO> ToDTOs(this IEnumerable<CTCustomerTagSearch> entities)
        {
            return LinqExtension.ToDTO<CTCustomerTagSearch, CustomerTagSearchDTO>(entities, ToDTO);
        }
    }
}
