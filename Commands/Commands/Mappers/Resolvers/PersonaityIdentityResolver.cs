using AutoMapper;
using AcceleratedTool.Models.Employees;
using AcceleratedTool.XmlApi.Contracts.Requests;

namespace AcceleratedTool.Commands.Mappers.Resolvers
{
    public class PersonalityIdenitityResolver : IValueResolver<HyperFindResult, Personality, Identity>
    {
        public Identity Resolve(HyperFindResult source, Personality destination, Identity destMember, ResolutionContext context)
        {
            destMember = new Identity();
            destMember.PersonIdentity = new XmlApi.Contracts.Requests.PersonIdentity
            {
                PersonNumber = source.PersonNumber
            };
            return destMember;
        }
    }
}
