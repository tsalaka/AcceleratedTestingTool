using System.Collections.Generic;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.Mappers
{
    public class ExcelEmployeeMapper
    {
        public List<Excel.Models.Employee> Map(List<Employee> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, Excel.Models.Employee>();
            });

            var mapData = Mapper.Map<List<Employee>, List<Excel.Models.Employee>>(data);
            return mapData;
        }
    }
}
