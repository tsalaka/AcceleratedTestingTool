using System.Collections.Generic;
using AutoMapper;

namespace AcceleratedTool.Commands.Mappers.DbData
{
    public class BaseDbDataMapper<TModel, TResult, TExcel>
    {
        public List<TModel> Map(List<TResult> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TResult, TModel>();
            });

            return Mapper.Map<List<TResult>, List<TModel>>(data);
        }

        public List<TExcel> Map(List<TModel> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TModel, TExcel>();
            });

            return Mapper.Map<List<TModel>, List<TExcel>>(data);
        }
    }
}
