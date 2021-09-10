
using Teleperformance.Registration.Domain.Entities;

namespace Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories
{
    public class UpdateCompanyResponse : BaseGatewayResponse
    {
        public Company Company { get; set; }

        public UpdateCompanyResponse(Company company, bool success = false, Error error = null) : base(success, error)
        {
            Company = company;
        }
    }
}
