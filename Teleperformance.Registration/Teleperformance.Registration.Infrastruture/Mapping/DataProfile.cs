using AutoMapper;
using Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Entities;

namespace Teleperformance.Registration.Infrastruture.Mapping
{
    public class DataProfile: Profile
    {
        public DataProfile()
        {
            CreateMap<Company, RegisterCompanyRequest>().ReverseMap();
            //CreateMap<RegisterCompanyRequest, Company>().ConstructUsing(c => new Company
            //{
            //    IdentificationType = c.IdentificationType,
            //    IdentificationNumber = c.IdentificationNumber,
            //    CompanyName = c.CompanyName,
            //    FirstName = c.FirstName,
            //    SecondName = c.SecondName,
            //    FirstLastname = c.FirstLastname,
            //    SecondLastname = c.SecondLastname,
            //    Email = c.Email,
            //    SendMessage = c.SendMessage,
            //    SendEmail = c.SendEmail
            //});;
        }
    }
}
