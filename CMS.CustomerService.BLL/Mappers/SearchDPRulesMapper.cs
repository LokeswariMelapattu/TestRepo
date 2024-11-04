using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.DAL;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using System;

namespace DUC.CMS.CustomerService.BLL.Mappers
{

    public static partial class SearchDPRulesMapper
    {
        static partial void OnDTO(this CTSearchDPRulesResultDTO entity, SearchDPRulesResultDTO dto);

        public static SearchDPRulesResultDTO ToDTO(this CTSearchDPRulesResultDTO entity)
        {
            if (entity == null) return null;

            var dto = new SearchDPRulesResultDTO();
            dto.RuleID = entity.RuleID;
            dto.RuleName = entity.RuleName;
            dto.RuleType = entity.RuleType;
            dto.RuleTypeID = entity.RuleTypeID;
            dto.ValidFromDate = entity.ValidFromDate;
            dto.ValidToDate = entity.ValidToDate;
            dto.Description = entity.Description;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<SearchDPRulesResultDTO> ToDTOs(this IEnumerable<CTSearchDPRulesResultDTO> entities)
        {
            return LinqExtension.ToDTO<CTSearchDPRulesResultDTO, SearchDPRulesResultDTO>(entities, ToDTO);
        }




        static partial void OnEntity(this SearchDPRulesDTO dto, CTSearchDPRulesDTO entity);

        public static CTSearchDPRulesDTO ToEntity(this SearchDPRulesDTO dto)
        {
            if (dto == null) return null;

            var entity = new CTSearchDPRulesDTO();           
            entity.RuleName = dto.RuleName;           
            entity.RuleTypeID = dto.RuleTypeID;
            
            //entity.ProductID = dto.ValidFromDate;
            //entity.StationID = dto.ValidToDate;

            dto.OnEntity(entity);
            return entity;

        }

        public static List<CTSearchDPRulesDTO> ToEntities(this IEnumerable<SearchDPRulesDTO> dtos)
        {
            return LinqExtension.ToEntity<CTSearchDPRulesDTO, SearchDPRulesDTO>(dtos, ToEntity);
        }





        //static partial void OnDTO(this CTProperty entity, PropertyDTO dto);

        //public static PropertyDTO ToDTO(this CTProperty entity)
        //{
        //    if (entity == null) return null;

        //    var dto = new PropertyDTO();
        //    dto.ID = entity.ID;
        //    dto.EnName = entity.EN_NAME;
        //    dto.ArName = entity.AR_NAME;

        //    entity.OnDTO(dto);

        //    return dto;
        //}


        //public static List<PropertyDTO> ToDTOs(this IEnumerable<CTProperty> entities)
        //{
        //    return LinqExtension.ToDTO<CTProperty, PropertyDTO>(entities, ToDTO);
        //}



        //static partial void OnEntity(this PropertyDTO dto, CTProperty entity);



        //public static CTProperty ToEntity(this PropertyDTO dto)
        //{
        //    if (dto == null) return null;

        //    var entity = new CTProperty();
        //    entity.ID = dto.ID;
        //    entity.EN_NAME = dto.EnName;
        //    entity.AR_NAME = dto.ArName;
        //    dto.OnEntity(entity);
        //    return entity;
        //}




        //public static List<CTProperty> ToEntities(this IEnumerable<PropertyDTO> dtos)
        //{
        //    return LinqExtension.ToEntity<CTProperty, PropertyDTO>(dtos, ToEntity);
        //}



    }
}
