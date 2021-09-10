
using Teleperformance.Registration.Domain.Entities;

namespace Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories
{
    public class FindCompanyResponse : BaseGatewayResponse
    {
        public Company Company { get; set; }

        public FindCompanyResponse(Company company, bool success = false, Error error = null) : base(success, error)
        {
            Company = company;
        }
    }
}
