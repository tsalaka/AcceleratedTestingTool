using System.Collections.Generic;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.Mappers
{
    public class ExcelCustomFieldMapper
    {
        public List<Excel.Models.EmployeeCustomField> Map(List<CustomData> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomData, Excel.Models.EmployeeCustomField>()
                    .ForMember(d => d.FirstName, s => s.MapFrom(o => o.Person.FirstName))
                    .ForMember(d => d.LastName, s => s.MapFrom(o => o.Person.LastName))
                    .ForMember(d => d.PersonNumber, s => s.MapFrom(o => o.Person.PersonNumber));
            });

            var mapData = Mapper.Map<List<CustomData>, List<Excel.Models.EmployeeCustomField>>(data);
            return mapData;
        }
    }
}
