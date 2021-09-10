using Teleperformance.Registration.Domain.Dto.UseCaseRequests;

namespace Teleperformance.Registration.Domain.Ports.UseCases
{
    public interface IFindByIdentificationCompanyUseCase : IUseCaseRequestHandler<FindByIdentificationCompanyRequest, FindByIdentificationCompanyResponse>
    {
    }
}
