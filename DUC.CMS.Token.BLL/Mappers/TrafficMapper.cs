using System;
using DUC.CMS.Token.BLL.DTO;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using TrafficData.DAL;

namespace DUC.CMS.Token.BLL.Mappers
{

    public static partial class TrafficMapper
    {
        //TrafficvehicleSearchDTO entiti
        //TrafficvehicleSearchResultDTO

        static partial void OnDTO(this CTData entity, GetVehicleInfoDTO dto);
        static partial void OnEntity(this TrafficvehicleSearchDTO dto, CTData entity);

        public static CTData ToEntity(this TrafficvehicleSearchDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTData();
            entity.i_tcfno = dto.i_tcfno;
            entity.i_pno = dto.i_pno;
            entity.i_porg_no = dto.i_porg_no;
            entity.i_pcolor_code = dto.i_pcolor_code;
            entity.i_pkind_code = dto.i_pkind_code;
            entity.i_ptype_code = dto.i_ptype_code;
            entity.i_psource_code = dto.i_psource_code;
            entity.i_chassis_no = dto.i_chassis_no;
            entity.i_user_IPAddress = dto.i_user_IPAddress;
            entity.i_user_code = dto.i_user_code;
            entity.i_appl_name = dto.i_appl_name;
            entity.o_owner_tcfno = dto.o_owner_tcfno;
            entity.o_owner_name = dto.o_owner_name;
            entity.o_owner_name_Ar = dto.o_owner_name_Ar;
            entity.o_color_code = dto.o_color_code;
            entity.o_color_desc_ar = dto.o_color_desc_ar;
            entity.o_color_desc = dto.o_color_desc;
            entity.o_type_code = dto.o_type_code;
            entity.o_type_desc_ar = dto.o_type_desc_ar;
            entity.o_type_desc = dto.o_type_desc;
            entity.o_nat_code = dto.o_nat_code;
            entity.o_nat_desc_ar = dto.o_nat_desc_ar;
            entity.o_nat_desc = dto.o_nat_desc;
            entity.o_year = dto.o_year;
            entity.o_chairs = dto.o_chairs;
            entity.o_make_code = dto.o_make_code;
            entity.o_make_desc_ar = dto.o_make_desc_ar;
            entity.o_make_desc = dto.o_make_desc;
            entity.o_model_code = dto.o_model_code;
            entity.o_model_desc_ar = dto.o_model_desc_ar;
            entity.o_model_desc = dto.o_model_desc;
            entity.o_kind_code = dto.o_kind_code;
            entity.o_kind_desc_ar = dto.o_kind_desc_ar;
            entity.o_kind_desc = dto.o_kind_desc;
            entity.o_weight_empty = dto.o_weight_empty;
            entity.o_weight_full = dto.o_weight_full;
            entity.o_reg_date = dto.o_reg_date;
            entity.o_reg_expiry_date = dto.o_reg_expiry_date;
            entity.o_engine_no = dto.o_engine_no;
            entity.o_chassis_no = dto.o_chassis_no;
            entity.o_gear_code = dto.o_gear_code;
            entity.o_gear_desc_ar = dto.o_gear_desc_ar;
            entity.o_gear_desc = dto.o_gear_desc;
            entity.o_fuel_code = dto.o_fuel_code;
            entity.o_fuel_desc_ar = dto.o_fuel_desc_ar;
            entity.o_fuel_desc = dto.o_fuel_desc;
            entity.o_weight_code = dto.o_weight_code;
            entity.o_weight_desc_ar = dto.o_weight_desc_ar;
            entity.o_weight_desc = dto.o_weight_desc;
            entity.o_steering_code = dto.o_steering_code;
            entity.o_steering_desc_ar = dto.o_steering_desc_ar;
            entity.o_steering_desc = dto.o_steering_desc;
            entity.o_cylinder = dto.o_cylinder;
            entity.o_axels_count = dto.o_axis_count;
            entity.o_door_count = dto.o_door_count;
            entity.o_horse_power = dto.o_horse_power;
            entity.o_wheels_count = dto.o_wheels_count;
            entity.o_reg_remarks = dto.o_reg_remarks;
            entity.o_wanted = dto.o_wanted;
            entity.o_accident = dto.o_accident;
            entity.o_fine_auh = dto.o_fine_auh;
            entity.o_fine_ne = dto.o_fine_ne;
            entity.o_fine_auh_amt = dto.o_fine_auh_amt;
            entity.o_fine_ne_amt = dto.o_fine_ne_amt;
            entity.o_cubic_capacity_cc = dto.o_cubic_capacity_cc;
            entity.o_mileage_count = dto.o_mileage_count;
            entity.O_ERR_CODE = dto.O_ERR_CODE;
            entity.O_ERR_MSG = dto.O_ERR_MSG;

            dto.OnEntity(entity);

            return entity;
        }

        public static GetVehicleInfoDTO ToDTO(this CTData entity)
        {
            if (entity == null) return null;

            var dto = new GetVehicleInfoDTO();
            dto.Category = entity.o_kind_desc;
            dto.CC = entity.o_cubic_capacity_cc;
            dto.ChassisNumber = entity.o_chassis_no;
            dto.Color = entity.o_color_desc;
            dto.FuelCapacity = null;
            dto.FuelInlet = null;
           // dto.MakeId = entity.o_make_code;
            dto.MakeName = entity.o_make_desc;
            //dto.ModelId = entity.o_model_code;
            dto.ModelName = entity.o_model_desc;
            dto.Plate = entity.i_pno;
            dto.TrafficNumber = entity.o_owner_tcfno;
            //dto.VehicleEmirateId = entity.i_psource_code;
            dto.Year = entity.o_year.ToString();
            //dto.YearId = entity.o_year;

            entity.OnDTO(dto);
            return dto;
        }
        /*
    public static TrafficvehicleSearchResultDTO ToDTO(this CTData entity)
    {
        if (entity == null) return null;

        var dto = new TrafficvehicleSearchResultDTO();
        dto.i_tcfno = entity.i_tcfno;
        dto.i_pno = entity.i_pno;
        dto.i_porg_no = entity.i_porg_no;
        dto.i_pcolor_code = entity.i_pcolor_code;
        dto.i_pkind_code = entity.i_pkind_code;
        dto.i_ptype_code = entity.i_ptype_code;
        dto.i_psource_code = entity.i_psource_code;
        dto.i_chassis_no = entity.i_chassis_no;
        dto.i_user_IPAddress = entity.i_user_IPAddress;
        dto.i_user_code = entity.i_user_code;
        dto.i_appl_name = entity.i_appl_name;
        dto.o_owner_tcfno = entity.o_owner_tcfno;
        dto.o_owner_name = entity.o_owner_name;
        dto.o_owner_name_Ar = entity.o_owner_name_Ar;
        dto.o_color_code = entity.o_color_code;
        dto.o_color_desc_ar = entity.o_color_desc_ar;
        dto.o_color_desc = entity.o_color_desc;
        dto.o_type_code = entity.o_type_code;
        dto.o_type_desc_ar = entity.o_type_desc_ar;
        dto.o_type_desc = entity.o_type_desc;
        dto.o_nat_code = entity.o_nat_code;
        dto.o_nat_desc_ar = entity.o_nat_desc_ar;
        dto.o_nat_desc = entity.o_nat_desc;
        dto.o_year = entity.o_year;
        dto.o_chairs = entity.o_chairs;
        dto.o_make_code = entity.o_make_code;
        dto.o_make_desc_ar = entity.o_make_desc_ar;
        dto.o_make_desc = entity.o_make_desc;
        dto.o_model_code = entity.o_model_code;
        dto.o_model_desc_ar = entity.o_model_desc_ar;
        dto.o_model_desc = entity.o_model_desc;
        dto.o_kind_code = entity.o_kind_code;
        dto.o_kind_desc_ar = entity.o_kind_desc_ar;
        dto.o_kind_desc = entity.o_kind_desc;
        dto.o_weight_empty = entity.o_weight_empty;
        dto.o_weight_full = entity.o_weight_full;
        dto.o_reg_date = entity.o_reg_date;
        dto.o_reg_expiry_date = entity.o_reg_expiry_date;
        dto.o_engine_no = entity.o_engine_no;
        dto.o_chassis_no = entity.o_chassis_no;
        dto.o_gear_code = entity.o_gear_code;
        dto.o_gear_desc_ar = entity.o_gear_desc_ar;
        dto.o_gear_desc = entity.o_gear_desc;
        dto.o_fuel_code = entity.o_fuel_code;
        dto.o_fuel_desc_ar = entity.o_fuel_desc_ar;
        dto.o_fuel_desc = entity.o_fuel_desc;
        dto.o_weight_code = entity.o_weight_code;
        dto.o_weight_desc_ar = entity.o_weight_desc_ar;
        dto.o_weight_desc = entity.o_weight_desc;
        dto.o_steering_code = entity.o_steering_code;
        dto.o_steering_desc_ar = entity.o_steering_desc_ar;
        dto.o_steering_desc = entity.o_steering_desc;
        dto.o_cylinder = entity.o_cylinder;
        dto.o_axis_count = entity.o_axis_count;
        dto.o_door_count = entity.o_door_count;
        dto.o_horse_power = entity.o_horse_power;
        dto.o_wheels_count = entity.o_wheels_count;
        dto.o_reg_remarks = entity.o_reg_remarks;
        dto.o_wanted = entity.o_wanted;
        dto.o_accident = entity.o_accident;
        dto.o_fine_auh = entity.o_fine_auh;
        dto.o_fine_ne = entity.o_fine_ne;
        dto.o_fine_auh_amt = entity.o_fine_auh_amt;
        dto.o_fine_ne_amt = entity.o_fine_ne_amt;
        dto.o_cubic_capacity_cc = entity.o_cubic_capacity_cc;
        dto.o_mileage_count = entity.o_mileage_count;
        dto.O_ERR_CODE = entity.O_ERR_CODE;
        dto.O_ERR_MSG = entity.O_ERR_MSG;


        entity.OnDTO(dto);
        return dto;
    }

        */
    }
}




