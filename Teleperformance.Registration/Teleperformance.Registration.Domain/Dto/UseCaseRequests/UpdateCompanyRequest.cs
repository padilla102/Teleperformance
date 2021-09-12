

using Teleperformance.Registration.Domain.Dto.UseCaseResponse;
using Teleperformance.Registration.Domain.Entities;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseRequests
{
    public class UpdateCompanyRequest : IUseCaseRequest<UpdateCompanyResponse>
    {
        public int Id { get; set; }
        public RegisterCompanyRequest Company { get; set; }

        public UpdateCompanyRequest(int id, RegisterCompanyRequest registerCompanyRequest)
        {
            Id = id;
            Company = registerCompanyRequest;
        }
    }
}
