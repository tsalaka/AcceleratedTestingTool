using System.Collections.Generic;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.Mappers
{
    public class ExcelCustomDateMapper
    {
        public List<Excel.Models.EmployeeCustomDate> Map(List<CustomDate> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomDate, Excel.Models.EmployeeCustomDate>()
                    .ForMember(d => d.FirstName, s => s.MapFrom(o => o.Person.FirstName))
                    .ForMember(d => d.LastName, s => s.MapFrom(o => o.Person.LastName))
                    .ForMember(d => d.PersonNumber, s => s.MapFrom(o => o.Person.PersonNumber));
            });

            var mapData = Mapper.Map<List<CustomDate>, List<Excel.Models.EmployeeCustomDate>>(data);
            return mapData;
        }
    }
}
