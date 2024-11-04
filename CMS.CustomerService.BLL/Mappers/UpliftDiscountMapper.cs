using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.BLL.Mappers
{
    public static partial class UpliftDiscountMapper
    {
        public static UpliftDiscountDTO ToDTO(this CTUpliftCustomerProduct dto)
        {
            if (dto == null) return null;

            var entity = new UpliftDiscountDTO();
            
            entity.UpLiftID = dto.UPLIFTID;
            entity.PriceUpliftDiscount = dto.PriceUpLiftDiscount;
            entity.ProductID = dto.ProductID;
            entity.ProductName = dto.ProductName;
            entity.ProductNameAr = dto.ProductNameAR;
            entity.Quantity = dto.Quantity;

            return entity;
        }

        public static List<UpliftDiscountDTO> ToDTOs(this IEnumerable<CTUpliftCustomerProduct> entities)
        {
            return LinqExtension.ToDTO<CTUpliftCustomerProduct, UpliftDiscountDTO>(entities, ToDTO);
        }
    }
}
