using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;

namespace Teleperformance.Registration.Domain.Ports.UseCases
{
    public interface IUpdateCompanyUseCase : IUseCaseRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
    {
    }
}
