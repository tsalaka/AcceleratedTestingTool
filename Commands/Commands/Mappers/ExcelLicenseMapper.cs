using System.Collections.Generic;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.Mappers
{
    public class ExcelEmployeeLicenseMapper
    {
        public List<Excel.Models.EmployeeLicense> Map(List<EmployeeLicense> data)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeeLicense, Excel.Models.EmployeeLicense>()
                    .ForMember(d => d.LicenseActiveFlag, s => s.MapFrom(o => o.ActiveFlag))
                    .ForMember(d => d.FirstName, s => s.MapFrom(o => o.Person.FirstName))
                    .ForMember(d => d.LastName, s => s.MapFrom(o => o.Person.LastName))
                    .ForMember(d => d.PersonNumber, s => s.MapFrom(o => o.Person.PersonNumber));
            });

            var mapData = Mapper.Map<List<EmployeeLicense>, List<Excel.Models.EmployeeLicense>>(data);
            return mapData;
        }
    }
}
