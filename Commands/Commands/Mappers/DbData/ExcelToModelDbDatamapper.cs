using System.Collections.Generic;
using AutoMapper;

namespace AcceleratedTool.Commands.Mappers.DbData
{
    public class ExcelToModelDbDataMapper<TModel, TExcel>
    {
        public List<TModel> Map(List<TExcel> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TExcel, TModel>();
            });

            return Mapper.Map<List<TExcel>, List<TModel>>(data);
        }

        public List<TExcel> Map(List<TModel> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TExcel, TModel>().ReverseMap();
            });

            return Mapper.Map<List<TModel>, List<TExcel>>(data);
        }
    }
}
