using System.Collections.Generic;
using AutoMapper;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.Mappers
{
    public class HyperFindMapper
    {
        public HyperFindMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HyperFindQuery, XmlApi.Contracts.Requests.HyperFindQuery>();
                cfg.CreateMap<XmlApi.Contracts.Responses.HyperFindResult, HyperFindResult>();
            });
        }

        public XmlApi.Contracts.Requests.HyperFindQuery GetQueryWrapper(HyperFindQuery data)
        {
            return Mapper.Map<HyperFindQuery, XmlApi.Contracts.Requests.HyperFindQuery>(data);
        }

        public HyperFindResult GetResultWrapper(XmlApi.Contracts.Responses.HyperFindResult data)
        {
            return Mapper.Map<XmlApi.Contracts.Responses.HyperFindResult, HyperFindResult>(data);
        }

        public List<HyperFindResult> GetResultWrapper(List<XmlApi.Contracts.Responses.HyperFindResult> data)
        {
            return Mapper.Map<List<XmlApi.Contracts.Responses.HyperFindResult>, List<HyperFindResult>>(data);
        }
    }
}
