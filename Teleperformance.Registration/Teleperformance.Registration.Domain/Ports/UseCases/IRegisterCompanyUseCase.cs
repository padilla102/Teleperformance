using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;

namespace Teleperformance.Registration.Domain.Ports.UseCases
{
    public interface IRegisterCompanyUseCase : IUseCaseRequestHandler<RegisterCompanyRequest, RegisterCompanyResponse>
    {
    }
}
