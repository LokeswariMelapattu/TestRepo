using System;
using System.Collections.Generic;

namespace DUC.CMS.Beneficiary.BLL
{
    public class LinqExtension
    {
        public static List<TEntity> ToEntity<TEntity, TDto>(IEnumerable<TDto> dtos, Func<TDto, TEntity> delegatedFunction)
        {
            if (dtos == null) return null;
            var entities = new List<TEntity>();
            foreach (var dto in dtos)
            {
                entities.Add(delegatedFunction(dto));
            }

            return entities;
        }

        public static List<TDto> ToDTO<TEntity, TDto>(IEnumerable<TEntity> entities, Func<TEntity, TDto> delegatedFunction)
        {
            if (entities == null) return null;
            var dtos = new List<TDto>();
            foreach (var entity in entities)
            {
                dtos.Add(delegatedFunction(entity));
            }

            return dtos;
        }
    }
}